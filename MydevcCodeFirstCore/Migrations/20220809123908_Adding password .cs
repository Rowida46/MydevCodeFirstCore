using Microsoft.EntityFrameworkCore.Migrations;

namespace MydevcCodeFirstCore.Migrations
{
    public partial class Addingpassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "logins",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password",
                table: "logins");
        }
    }
}
