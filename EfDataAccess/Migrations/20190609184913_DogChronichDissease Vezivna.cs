using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EfDataAccess.Migrations
{
    public partial class DogChronichDisseaseVezivna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChronicDiseases_Dogs_DogId",
                table: "ChronicDiseases");

            migrationBuilder.DropIndex(
                name: "IX_ChronicDiseases_DogId",
                table: "ChronicDiseases");

            migrationBuilder.DropColumn(
                name: "DogId",
                table: "ChronicDiseases");

            migrationBuilder.DropColumn(
                name: "Therapy",
                table: "ChronicDiseases");

            migrationBuilder.CreateTable(
                name: "DogChronichDiseases",
                columns: table => new
                {
                    DogId = table.Column<int>(nullable: false),
                    ChronicDiseaseId = table.Column<int>(nullable: false),
                    Therapy = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogChronichDiseases", x => new { x.DogId, x.ChronicDiseaseId });
                    table.ForeignKey(
                        name: "FK_DogChronichDiseases_ChronicDiseases_ChronicDiseaseId",
                        column: x => x.ChronicDiseaseId,
                        principalTable: "ChronicDiseases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DogChronichDiseases_Dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "Dogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DogChronichDiseases_ChronicDiseaseId",
                table: "DogChronichDiseases",
                column: "ChronicDiseaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DogChronichDiseases");

            migrationBuilder.AddColumn<int>(
                name: "DogId",
                table: "ChronicDiseases",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Therapy",
                table: "ChronicDiseases",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ChronicDiseases_DogId",
                table: "ChronicDiseases",
                column: "DogId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChronicDiseases_Dogs_DogId",
                table: "ChronicDiseases",
                column: "DogId",
                principalTable: "Dogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
