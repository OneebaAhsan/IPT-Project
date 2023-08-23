using LibraryAPI.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;
using AutoMapper;
using LibraryAPI.Configurations;
using LibraryAPI.IRepository;
using LibraryAPI.Repository;
using Microsoft.AspNetCore.Identity;
using LibraryAPI;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.FileProviders;

Log.Logger = new LoggerConfiguration().WriteTo.File(
        path: @"C:\Games\Courses\IPT Project\logs\log-.txt",
        outputTemplate: "{TimeStamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:1j}{NewLine}{Exception}",
        rollingInterval: RollingInterval.Day,
        restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information
    ).CreateLogger();

try
{
    Log.Information("Application is starting");
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddCors(o =>
    {
        o.AddPolicy(name: "CorsPolicy", builder =>
        {
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
    });

    builder.Services.AddAutoMapper(typeof(MapperInitializer));

    builder.Services.AddDbContext<DatabaseContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection")));

    builder.Services.AddAuthentication();

    builder.Services.ConfigureIdentity();

    builder.Services.ConfigureJWT(builder.Configuration);

    builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
    builder.Services.AddScoped<IAuthManager, AuthManager>();

    builder.Services.AddControllers().AddNewtonsoftJson(o=>o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

    builder.Host.UseSerilog();

    var app = builder.Build();

    app.UseSerilogRequestLogging();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCors("CorsPolicy");

    app.UseHttpsRedirection();

    app.UseStaticFiles();
    app.UseStaticFiles(new StaticFileOptions()
    {
        FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "Resources", "Images")),
        RequestPath = new PathString("/Resources/Images")
    });

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}
