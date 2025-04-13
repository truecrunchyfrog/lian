using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class Rename_InternshipTerm_InternshipPosition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_InternshipTerms_InternshipTermId",
                table: "Contact");

            migrationBuilder.DropTable(
                name: "InternshipTermTag");

            migrationBuilder.DropTable(
                name: "InternshipTerms");

            migrationBuilder.RenameColumn(
                name: "InternshipTermId",
                table: "Contact",
                newName: "InternshipPositionId");

            migrationBuilder.RenameIndex(
                name: "IX_Contact_InternshipTermId",
                table: "Contact",
                newName: "IX_Contact_InternshipPositionId");

            migrationBuilder.CreateTable(
                name: "InternshipPositions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrganizationId = table.Column<int>(type: "INTEGER", nullable: false),
                    ApplicationPeriodId = table.Column<int>(type: "INTEGER", nullable: false),
                    PracticePeriodId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternshipPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InternshipPositions_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternshipPositions_Period_ApplicationPeriodId",
                        column: x => x.ApplicationPeriodId,
                        principalTable: "Period",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternshipPositions_Period_PracticePeriodId",
                        column: x => x.PracticePeriodId,
                        principalTable: "Period",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InternshipPositionTag",
                columns: table => new
                {
                    InternshipTermsId = table.Column<int>(type: "INTEGER", nullable: false),
                    TagsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternshipPositionTag", x => new { x.InternshipTermsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_InternshipPositionTag_InternshipPositions_InternshipTermsId",
                        column: x => x.InternshipTermsId,
                        principalTable: "InternshipPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternshipPositionTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InternshipPositions_ApplicationPeriodId",
                table: "InternshipPositions",
                column: "ApplicationPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_InternshipPositions_OrganizationId",
                table: "InternshipPositions",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_InternshipPositions_PracticePeriodId",
                table: "InternshipPositions",
                column: "PracticePeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_InternshipPositionTag_TagsId",
                table: "InternshipPositionTag",
                column: "TagsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_InternshipPositions_InternshipPositionId",
                table: "Contact",
                column: "InternshipPositionId",
                principalTable: "InternshipPositions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_InternshipPositions_InternshipPositionId",
                table: "Contact");

            migrationBuilder.DropTable(
                name: "InternshipPositionTag");

            migrationBuilder.DropTable(
                name: "InternshipPositions");

            migrationBuilder.RenameColumn(
                name: "InternshipPositionId",
                table: "Contact",
                newName: "InternshipTermId");

            migrationBuilder.RenameIndex(
                name: "IX_Contact_InternshipPositionId",
                table: "Contact",
                newName: "IX_Contact_InternshipTermId");

            migrationBuilder.CreateTable(
                name: "InternshipTerms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ApplicationPeriodId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrganizationId = table.Column<int>(type: "INTEGER", nullable: false),
                    PracticePeriodId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternshipTerms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InternshipTerms_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternshipTerms_Period_ApplicationPeriodId",
                        column: x => x.ApplicationPeriodId,
                        principalTable: "Period",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternshipTerms_Period_PracticePeriodId",
                        column: x => x.PracticePeriodId,
                        principalTable: "Period",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InternshipTermTag",
                columns: table => new
                {
                    InternshipTermsId = table.Column<int>(type: "INTEGER", nullable: false),
                    TagsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternshipTermTag", x => new { x.InternshipTermsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_InternshipTermTag_InternshipTerms_InternshipTermsId",
                        column: x => x.InternshipTermsId,
                        principalTable: "InternshipTerms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InternshipTermTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InternshipTerms_ApplicationPeriodId",
                table: "InternshipTerms",
                column: "ApplicationPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_InternshipTerms_OrganizationId",
                table: "InternshipTerms",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_InternshipTerms_PracticePeriodId",
                table: "InternshipTerms",
                column: "PracticePeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_InternshipTermTag_TagsId",
                table: "InternshipTermTag",
                column: "TagsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_InternshipTerms_InternshipTermId",
                table: "Contact",
                column: "InternshipTermId",
                principalTable: "InternshipTerms",
                principalColumn: "Id");
        }
    }
}
