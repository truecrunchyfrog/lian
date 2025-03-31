using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    AdministratorEmail = table.Column<string>(type: "TEXT", nullable: false),
                    Expiration = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Period",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Start = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    End = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Period", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InternshipPeriods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ApplicationPeriodId = table.Column<int>(type: "INTEGER", nullable: false),
                    PracticePeriodId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrganizationId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternshipPeriods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InternshipPeriods_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InternshipPeriods_Period_ApplicationPeriodId",
                        column: x => x.ApplicationPeriodId,
                        principalTable: "Period",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternshipPeriods_Period_PracticePeriodId",
                        column: x => x.PracticePeriodId,
                        principalTable: "Period",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Method = table.Column<int>(type: "INTEGER", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    InternshipPeriodId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contact_InternshipPeriods_InternshipPeriodId",
                        column: x => x.InternshipPeriodId,
                        principalTable: "InternshipPeriods",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contact_InternshipPeriodId",
                table: "Contact",
                column: "InternshipPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_InternshipPeriods_ApplicationPeriodId",
                table: "InternshipPeriods",
                column: "ApplicationPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_InternshipPeriods_OrganizationId",
                table: "InternshipPeriods",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_InternshipPeriods_PracticePeriodId",
                table: "InternshipPeriods",
                column: "PracticePeriodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "InternshipPeriods");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "Period");
        }
    }
}
