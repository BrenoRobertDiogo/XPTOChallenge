using Microsoft.EntityFrameworkCore.Migrations;

namespace XPTOChallenge.Migrations
{
    public partial class Testando2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "CNPJClient",
                table: "Cliente",
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 14);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CNPJClient",
                table: "Cliente",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
