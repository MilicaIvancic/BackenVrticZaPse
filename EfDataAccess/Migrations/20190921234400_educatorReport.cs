using Microsoft.EntityFrameworkCore.Migrations;

namespace EfDataAccess.Migrations
{
    public partial class educatorReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EducetorReport_DogEducator_DogEducatorDogId_DogEducatorEducatorId",
                table: "EducetorReport");

            migrationBuilder.DropIndex(
                name: "IX_EducetorReport_DogEducatorDogId_DogEducatorEducatorId",
                table: "EducetorReport");

            migrationBuilder.DropColumn(
                name: "DogEducatorDogId",
                table: "EducetorReport");

            migrationBuilder.DropColumn(
                name: "DogEducatorEducatorId",
                table: "EducetorReport");

            migrationBuilder.RenameColumn(
                name: "DogEducatorId",
                table: "EducetorReport",
                newName: "EmployeId");

            migrationBuilder.AddColumn<int>(
                name: "DogId",
                table: "EducetorReport",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EducetorReport_DogId",
                table: "EducetorReport",
                column: "DogId");

            migrationBuilder.CreateIndex(
                name: "IX_EducetorReport_EmployeId",
                table: "EducetorReport",
                column: "EmployeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EducetorReport_Dogs_DogId",
                table: "EducetorReport",
                column: "DogId",
                principalTable: "Dogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EducetorReport_Employes_EmployeId",
                table: "EducetorReport",
                column: "EmployeId",
                principalTable: "Employes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EducetorReport_Dogs_DogId",
                table: "EducetorReport");

            migrationBuilder.DropForeignKey(
                name: "FK_EducetorReport_Employes_EmployeId",
                table: "EducetorReport");

            migrationBuilder.DropIndex(
                name: "IX_EducetorReport_DogId",
                table: "EducetorReport");

            migrationBuilder.DropIndex(
                name: "IX_EducetorReport_EmployeId",
                table: "EducetorReport");

            migrationBuilder.DropColumn(
                name: "DogId",
                table: "EducetorReport");

            migrationBuilder.RenameColumn(
                name: "EmployeId",
                table: "EducetorReport",
                newName: "DogEducatorId");

            migrationBuilder.AddColumn<int>(
                name: "DogEducatorDogId",
                table: "EducetorReport",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DogEducatorEducatorId",
                table: "EducetorReport",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EducetorReport_DogEducatorDogId_DogEducatorEducatorId",
                table: "EducetorReport",
                columns: new[] { "DogEducatorDogId", "DogEducatorEducatorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EducetorReport_DogEducator_DogEducatorDogId_DogEducatorEducatorId",
                table: "EducetorReport",
                columns: new[] { "DogEducatorDogId", "DogEducatorEducatorId" },
                principalTable: "DogEducator",
                principalColumns: new[] { "DogId", "EducatorId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
