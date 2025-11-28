using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPrimerAPI.Migrations
{
    /// <inheritdoc />
    public partial class CorrectClassificationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Movies",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "Clasification",
                table: "Movies",
                newName: "Classification");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Movies",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "Classification",
                table: "Movies",
                newName: "Clasification");
        }
    }
}
