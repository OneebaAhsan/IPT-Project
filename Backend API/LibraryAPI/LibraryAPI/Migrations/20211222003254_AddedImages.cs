using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryAPI.Migrations
{
    public partial class AddedImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "31661ae1-ed0d-41a7-b7ea-b071897153ef");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e9a94d5-b593-423b-a040-9aff3bf3dd66");

            migrationBuilder.RenameColumn(
                name: "CoverPicture",
                table: "Books",
                newName: "CoverPicturePath");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "83f970de-544a-45a2-ba94-da48aad88f44", "5b3b1bc8-9d53-49e0-afa8-2250b8dc2d4f", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dc19f68d-7a3c-41d4-877d-0f9a8464a577", "eb2d5f5b-f89c-4379-98fa-b4552e138390", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83f970de-544a-45a2-ba94-da48aad88f44");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc19f68d-7a3c-41d4-877d-0f9a8464a577");

            migrationBuilder.RenameColumn(
                name: "CoverPicturePath",
                table: "Books",
                newName: "CoverPicture");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "31661ae1-ed0d-41a7-b7ea-b071897153ef", "865e8747-6ad5-4818-aeba-ed88ba95fe13", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6e9a94d5-b593-423b-a040-9aff3bf3dd66", "895ee7e2-c878-4757-ae23-277bcf4a04c9", "User", "USER" });
        }
    }
}
