using Microsoft.EntityFrameworkCore.Migrations;

namespace XPTOChallenge.Migrations
{
    public partial class tentandoir : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdemServico_Cliente_clienteId",
                table: "OrdemServico");

            migrationBuilder.RenameColumn(
                name: "clienteId",
                table: "OrdemServico",
                newName: "ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_OrdemServico_clienteId",
                table: "OrdemServico",
                newName: "IX_OrdemServico_ClienteId");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "OrdemServico",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdemServico_Cliente_ClienteId",
                table: "OrdemServico",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdemServico_Cliente_ClienteId",
                table: "OrdemServico");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "OrdemServico",
                newName: "clienteId");

            migrationBuilder.RenameIndex(
                name: "IX_OrdemServico_ClienteId",
                table: "OrdemServico",
                newName: "IX_OrdemServico_clienteId");

            migrationBuilder.AlterColumn<int>(
                name: "clienteId",
                table: "OrdemServico",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_OrdemServico_Cliente_clienteId",
                table: "OrdemServico",
                column: "clienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
