using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryAPI.Migrations
{
    public partial class RemovedImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[,]
                {
                    { "80595d7e-cc54-469f-b20d-5f9baed9ee1e", "b4274c7f-365f-483f-bbd8-54975ad666f6", "Administrator", "ADMINISTRATOR" },
                    { "8fc817da-f1be-439b-a546-ee596102aab0", "21b80439-d25e-49c9-96db-1c6c9b8491af", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1,
                column: "CoverPicturePath",
                value: "4771691.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2,
                column: "CoverPicturePath",
                value: "4824032.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3,
                column: "CoverPicturePath",
                value: "Book_Cover_Mockup.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80595d7e-cc54-469f-b20d-5f9baed9ee1e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8fc817da-f1be-439b-a546-ee596102aab0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4189d759-59d0-45f9-9395-1c449d27e7a7", "f9adb0db-f320-4990-b07a-b303a4402eed", "Administrator", "ADMINISTRATOR" },
                    { "f5353b9a-b1d8-40c2-8705-e69025981467", "dae3f284-034f-4642-8d3c-7b948e6266b9", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1,
                column: "CoverPicturePath",
                value: "Resources\\Images\\4771691.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 2,
                column: "CoverPicturePath",
                value: "Resources\\Images\\4824032.jpg");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 3,
                column: "CoverPicturePath",
                value: "Resources\\Images\\Book_Cover_Mockup.jpg");
        }
    }
}
