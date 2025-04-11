using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_InternshipPeriods_InternshipPeriodId",
                table: "Contact");

            migrationBuilder.DropTable(
                name: "InternshipPeriods");

            migrationBuilder.RenameColumn(
                name: "InternshipPeriodId",
                table: "Contact",
                newName: "InternshipTermId");

            migrationBuilder.RenameIndex(
                name: "IX_Contact_InternshipPeriodId",
                table: "Contact",
                newName: "IX_Contact_InternshipTermId");

            migrationBuilder.CreateTable(
                name: "InternshipTerms",
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
                    table.PrimaryKey("PK_InternshipTerms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InternshipTerms_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id");
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
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_InternshipTerms_InternshipTermId",
                table: "Contact");

            migrationBuilder.DropTable(
                name: "InternshipTermTag");

            migrationBuilder.DropTable(
                name: "InternshipTerms");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.RenameColumn(
                name: "InternshipTermId",
                table: "Contact",
                newName: "InternshipPeriodId");

            migrationBuilder.RenameIndex(
                name: "IX_Contact_InternshipTermId",
                table: "Contact",
                newName: "IX_Contact_InternshipPeriodId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_InternshipPeriods_InternshipPeriodId",
                table: "Contact",
                column: "InternshipPeriodId",
                principalTable: "InternshipPeriods",
                principalColumn: "Id");
        }
    }
}
