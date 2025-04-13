using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class ContinueRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InternshipPositionTag_InternshipPositions_InternshipTermsId",
                table: "InternshipPositionTag");

            migrationBuilder.RenameColumn(
                name: "InternshipTermsId",
                table: "InternshipPositionTag",
                newName: "InternshipPositionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_InternshipPositionTag_InternshipPositions_InternshipPositionsId",
                table: "InternshipPositionTag",
                column: "InternshipPositionsId",
                principalTable: "InternshipPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InternshipPositionTag_InternshipPositions_InternshipPositionsId",
                table: "InternshipPositionTag");

            migrationBuilder.RenameColumn(
                name: "InternshipPositionsId",
                table: "InternshipPositionTag",
                newName: "InternshipTermsId");

            migrationBuilder.AddForeignKey(
                name: "FK_InternshipPositionTag_InternshipPositions_InternshipTermsId",
                table: "InternshipPositionTag",
                column: "InternshipTermsId",
                principalTable: "InternshipPositions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
