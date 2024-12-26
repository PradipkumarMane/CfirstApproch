using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CfirstApproch.Migrations
{
    /// <inheritdoc />
    public partial class NewCodeFirstDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CityName",
                table: "Employees",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityName",
                table: "Employees");
        }
    }
}
