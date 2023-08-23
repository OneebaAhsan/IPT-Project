using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryAPI.Migrations
{
    public partial class RemovedImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80595d7e-cc54-469f-b20d-5f9baed9ee1e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8fc817da-f1be-439b-a546-ee596102aab0");

            migrationBuilder.DropColumn(
                name: "CoverPicturePath",
                table: "Books");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "611f9a6d-a280-484f-9c9c-481616344f59", "5271b5ec-2cb7-4d6c-9124-afc958b4b963", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "79cb9837-f7c0-4400-995d-95fba9eaae52", "9aa31f32-e818-4e04-bd99-4921f0287b56", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "611f9a6d-a280-484f-9c9c-481616344f59");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79cb9837-f7c0-4400-995d-95fba9eaae52");

            migrationBuilder.AddColumn<string>(
                name: "CoverPicturePath",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
    }
}
