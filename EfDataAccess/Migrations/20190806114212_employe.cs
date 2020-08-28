using Microsoft.EntityFrameworkCore.Migrations;

namespace EfDataAccess.Migrations
{
    public partial class employe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DogEducator_Users_EducatorId",
                table: "DogEducator");

            migrationBuilder.DropIndex(
                name: "IX_DogEducator_EducatorId",
                table: "DogEducator");

            migrationBuilder.AddColumn<int>(
                name: "EmployeId",
                table: "DogEducator",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "DogEducator",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DogEducator_EmployeId",
                table: "DogEducator",
                column: "EmployeId");

            migrationBuilder.CreateIndex(
                name: "IX_DogEducator_UserId",
                table: "DogEducator",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DogEducator_Employes_EmployeId",
                table: "DogEducator",
                column: "EmployeId",
                principalTable: "Employes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DogEducator_Users_UserId",
                table: "DogEducator",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DogEducator_Employes_EmployeId",
                table: "DogEducator");

            migrationBuilder.DropForeignKey(
                name: "FK_DogEducator_Users_UserId",
                table: "DogEducator");

            migrationBuilder.DropIndex(
                name: "IX_DogEducator_EmployeId",
                table: "DogEducator");

            migrationBuilder.DropIndex(
                name: "IX_DogEducator_UserId",
                table: "DogEducator");

            migrationBuilder.DropColumn(
                name: "EmployeId",
                table: "DogEducator");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "DogEducator");

            migrationBuilder.CreateIndex(
                name: "IX_DogEducator_EducatorId",
                table: "DogEducator",
                column: "EducatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_DogEducator_Users_EducatorId",
                table: "DogEducator",
                column: "EducatorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
