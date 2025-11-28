using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPrimerAPI.Migrations
{
    /// <inheritdoc />
    public partial class ImplementAuditBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Movies",
                newName: "ModifiedDate");

            migrationBuilder.AlterColumn<string>(
                name: "Classification",
                table: "Movies",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 10);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Movies",
                newName: "UpdatedDate");

            migrationBuilder.AlterColumn<int>(
                name: "Classification",
                table: "Movies",
                type: "int",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);
        }
    }
}
