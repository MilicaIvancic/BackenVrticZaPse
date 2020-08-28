using Microsoft.EntityFrameworkCore.Migrations;

namespace EfDataAccess.Migrations
{
    public partial class employe2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DogEducator_Employes_EmployeId",
                table: "DogEducator");

            migrationBuilder.DropIndex(
                name: "IX_DogEducator_EmployeId",
                table: "DogEducator");

            migrationBuilder.DropColumn(
                name: "EmployeId",
                table: "DogEducator");

            migrationBuilder.CreateIndex(
                name: "IX_DogEducator_EducatorId",
                table: "DogEducator",
                column: "EducatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_DogEducator_Employes_EducatorId",
                table: "DogEducator",
                column: "EducatorId",
                principalTable: "Employes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DogEducator_Employes_EducatorId",
                table: "DogEducator");

            migrationBuilder.DropIndex(
                name: "IX_DogEducator_EducatorId",
                table: "DogEducator");

            migrationBuilder.AddColumn<int>(
                name: "EmployeId",
                table: "DogEducator",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DogEducator_EmployeId",
                table: "DogEducator",
                column: "EmployeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DogEducator_Employes_EmployeId",
                table: "DogEducator",
                column: "EmployeId",
                principalTable: "Employes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
