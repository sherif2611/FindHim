using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project1.Migrations
{
    /// <inheritdoc />
    public partial class updateAddressColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "MissingPeople",
                newName: "Address_Govern");

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "MissingPeople",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "MissingPeople");

            migrationBuilder.RenameColumn(
                name: "Address_Govern",
                table: "MissingPeople",
                newName: "Address");
        }
    }
}
