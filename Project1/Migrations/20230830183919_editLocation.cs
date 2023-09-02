using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project1.Migrations
{
    /// <inheritdoc />
    public partial class editLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "State",
                table: "Users",
                newName: "Govern");

            migrationBuilder.RenameColumn(
                name: "FoundLocation",
                table: "MissingPeople",
                newName: "FoundGovern");

            migrationBuilder.AddColumn<string>(
                name: "FoundCity",
                table: "MissingPeople",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoundCity",
                table: "MissingPeople");

            migrationBuilder.RenameColumn(
                name: "Govern",
                table: "Users",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "FoundGovern",
                table: "MissingPeople",
                newName: "FoundLocation");
        }
    }
}
