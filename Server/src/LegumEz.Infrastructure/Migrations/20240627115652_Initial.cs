using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LegumEz.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Culture",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Culture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConditionCroissance",
                columns: table => new
                {
                    CultureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TemperatureMinimale_Valeur = table.Column<double>(type: "float", nullable: false),
                    TemperatureMinimale_Unite = table.Column<int>(type: "int", nullable: false),
                    TemperatureOptimale_Valeur = table.Column<double>(type: "float", nullable: false),
                    TemperatureOptimale_Unite = table.Column<int>(type: "int", nullable: false),
                    TempsDeCroissance_Valeur = table.Column<int>(type: "int", nullable: false),
                    TempsDeCroissance_Unite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConditionCroissance", x => x.CultureId);
                    table.ForeignKey(
                        name: "FK_ConditionCroissance_Culture_CultureId",
                        column: x => x.CultureId,
                        principalTable: "Culture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConditionGermination",
                columns: table => new
                {
                    CultureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TemperatureMinimale_Valeur = table.Column<double>(type: "float", nullable: false),
                    TemperatureMinimale_Unite = table.Column<int>(type: "int", nullable: false),
                    TemperatureOptimale_Valeur = table.Column<double>(type: "float", nullable: false),
                    TemperatureOptimale_Unite = table.Column<int>(type: "int", nullable: false),
                    TempsDeLevee_Valeur = table.Column<int>(type: "int", nullable: false),
                    TempsDeLevee_Unite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConditionGermination", x => x.CultureId);
                    table.ForeignKey(
                        name: "FK_ConditionGermination_Culture_CultureId",
                        column: x => x.CultureId,
                        principalTable: "Culture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConditionCroissance");

            migrationBuilder.DropTable(
                name: "ConditionGermination");

            migrationBuilder.DropTable(
                name: "Culture");
        }
    }
}
