using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SChallenge.Migrations
{
    public partial class AddingBooleanParamInUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "UserActive",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserActive",
                table: "Users");
        }
    }
}
