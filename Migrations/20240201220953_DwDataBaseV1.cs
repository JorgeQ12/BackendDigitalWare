using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamblingBackDW.Migrations
{
    /// <inheritdoc />
    public partial class DwDataBaseV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTeamA = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdTeamB = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScoreTeamA = table.Column<int>(type: "int", nullable: false),
                    ScoreTeamB = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_IdTeamA",
                        column: x => x.IdTeamA,
                        principalTable: "Teams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_IdTeamB",
                        column: x => x.IdTeamB,
                        principalTable: "Teams",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SessionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdMatches = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SessionCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Session_Matches_IdMatches",
                        column: x => x.IdMatches,
                        principalTable: "Matches",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SessionPerson",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonIdentification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdSession = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionPerson", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SessionPerson_Session_IdSession",
                        column: x => x.IdSession,
                        principalTable: "Session",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gamblings",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSession = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdSessionPerson = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScoreTeamA = table.Column<int>(type: "int", nullable: false),
                    ScoreTeamB = table.Column<int>(type: "int", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gamblings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Gamblings_SessionPerson_IdSessionPerson",
                        column: x => x.IdSessionPerson,
                        principalTable: "SessionPerson",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Gamblings_Session_IdSession",
                        column: x => x.IdSession,
                        principalTable: "Session",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gamblings_IdSession",
                table: "Gamblings",
                column: "IdSession");

            migrationBuilder.CreateIndex(
                name: "IX_Gamblings_IdSessionPerson",
                table: "Gamblings",
                column: "IdSessionPerson");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_IdTeamA",
                table: "Matches",
                column: "IdTeamA");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_IdTeamB",
                table: "Matches",
                column: "IdTeamB");

            migrationBuilder.CreateIndex(
                name: "IX_Session_IdMatches",
                table: "Session",
                column: "IdMatches");

            migrationBuilder.CreateIndex(
                name: "IX_SessionPerson_IdSession",
                table: "SessionPerson",
                column: "IdSession");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gamblings");

            migrationBuilder.DropTable(
                name: "SessionPerson");

            migrationBuilder.DropTable(
                name: "Session");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
