using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApplication.Web.Migrations
{
    public partial class AddLogTimesToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LogTimesJson",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogTimesJson",
                table: "Users");
        }
    }
}
