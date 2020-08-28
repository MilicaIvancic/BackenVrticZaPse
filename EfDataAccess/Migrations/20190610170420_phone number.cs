using Microsoft.EntityFrameworkCore.Migrations;

namespace EfDataAccess.Migrations
{
    public partial class phonenumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumer",
                table: "Phones",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 15);

            migrationBuilder.CreateIndex(
                name: "IX_Phones_PhoneNumer",
                table: "Phones",
                column: "PhoneNumer",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Phones_PhoneNumer",
                table: "Phones");

            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumer",
                table: "Phones",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 15);
        }
    }
}
