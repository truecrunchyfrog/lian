using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class HardLinkTermToOrganization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InternshipTerms_Organizations_OrganizationId",
                table: "InternshipTerms");

            migrationBuilder.AlterColumn<int>(
                name: "OrganizationId",
                table: "InternshipTerms",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InternshipTerms_Organizations_OrganizationId",
                table: "InternshipTerms",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InternshipTerms_Organizations_OrganizationId",
                table: "InternshipTerms");

            migrationBuilder.AlterColumn<int>(
                name: "OrganizationId",
                table: "InternshipTerms",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_InternshipTerms_Organizations_OrganizationId",
                table: "InternshipTerms",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id");
        }
    }
}
