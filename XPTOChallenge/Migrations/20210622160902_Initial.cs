using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace XPTOChallenge.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrdemServico",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tituloServico = table.Column<string>(nullable: true),
                    nomeCliente = table.Column<string>(nullable: true),
                    valorServico = table.Column<double>(nullable: false),
                    dataExecucao = table.Column<DateTime>(nullable: false),
                    CNPJClient = table.Column<string>(nullable: true),
                    CPFPrestador = table.Column<string>(nullable: true),
                    nomePrestador = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdemServico", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdemServico");
        }
    }
}
