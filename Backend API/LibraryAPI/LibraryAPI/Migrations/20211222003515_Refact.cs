using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryAPI.Migrations
{
    public partial class Refact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83f970de-544a-45a2-ba94-da48aad88f44");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc19f68d-7a3c-41d4-877d-0f9a8464a577");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4189d759-59d0-45f9-9395-1c449d27e7a7", "f9adb0db-f320-4990-b07a-b303a4402eed", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f5353b9a-b1d8-40c2-8705-e69025981467", "dae3f284-034f-4642-8d3c-7b948e6266b9", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4189d759-59d0-45f9-9395-1c449d27e7a7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f5353b9a-b1d8-40c2-8705-e69025981467");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "83f970de-544a-45a2-ba94-da48aad88f44", "5b3b1bc8-9d53-49e0-afa8-2250b8dc2d4f", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dc19f68d-7a3c-41d4-877d-0f9a8464a577", "eb2d5f5b-f89c-4379-98fa-b4552e138390", "Administrator", "ADMINISTRATOR" });
        }
    }
}
