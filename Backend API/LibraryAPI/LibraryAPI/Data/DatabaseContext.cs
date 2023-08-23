using LibraryAPI.Configurations.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Data
{
    public class DatabaseContext: IdentityDbContext<ApiUser>
    {
        public DatabaseContext(DbContextOptions options) : base(options) 
        {}

        public DbSet<Book> Books { get; set; }

        //public DbSet<Favorite> Favorites { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());

            builder.Entity<Book>().HasData(
                new Book
                {
                    BookId = 1,
                    Title = "Book 1",
                    Category = "Category 1",
                    author = "Author 1",
                    Complexity = "Beginner",
                    Description = "Description 1",
                    Price = 23.99f
                },
                new Book
                {
                    BookId = 2,
                    Title = "Book 2",
                    Category = "Category 2",
                    author = "Author 2",
                    Complexity = "Beginner",
                    Description = "Description 2",
                    Price = 19.99f
                },
                new Book
                {
                    BookId = 3,
                    Title = "Book 3",
                    Category = "Category 3",
                    author = "Author 3",
                    Complexity = "Beginner",
                    Description = "Description 3",
                    Price = 99.99f
                }
            );
        }
    }
}
