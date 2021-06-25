using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace XPTOChallenge.Migrations
{
    public partial class Testando : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CNPJClient",
                table: "OrdemServico");

            migrationBuilder.DropColumn(
                name: "nomeCliente",
                table: "OrdemServico");

            migrationBuilder.AlterColumn<string>(
                name: "CPFPrestador",
                table: "OrdemServico",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "clienteId",
                table: "OrdemServico",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    CNPJClient = table.Column<int>(maxLength: 14, nullable: false),
                    nomeCliente = table.Column<string>(nullable: true),
                    CEP = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdemServico_clienteId",
                table: "OrdemServico",
                column: "clienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdemServico_Cliente_clienteId",
                table: "OrdemServico",
                column: "clienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdemServico_Cliente_clienteId",
                table: "OrdemServico");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_OrdemServico_clienteId",
                table: "OrdemServico");

            migrationBuilder.DropColumn(
                name: "clienteId",
                table: "OrdemServico");

            migrationBuilder.AlterColumn<string>(
                name: "CPFPrestador",
                table: "OrdemServico",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CNPJClient",
                table: "OrdemServico",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nomeCliente",
                table: "OrdemServico",
                nullable: true);
        }
    }
}
