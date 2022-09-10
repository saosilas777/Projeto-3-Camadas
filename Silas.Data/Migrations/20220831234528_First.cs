using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emails_Cliente_ClienteId",
                table: "Emails");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricoCliente_Cliente_ClienteId",
                table: "HistoricoCliente");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricoCompra_Cliente_ClienteId",
                table: "HistoricoCompra");

            migrationBuilder.DropForeignKey(
                name: "FK_Telefones_Cliente_ClienteId",
                table: "Telefones");

            migrationBuilder.DropIndex(
                name: "IX_Telefones_ClienteId",
                table: "Telefones");

            migrationBuilder.DropIndex(
                name: "IX_HistoricoCompra_ClienteId",
                table: "HistoricoCompra");

            migrationBuilder.DropIndex(
                name: "IX_HistoricoCliente_ClienteId",
                table: "HistoricoCliente");

            migrationBuilder.DropIndex(
                name: "IX_Emails_ClienteId",
                table: "Emails");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Cliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Cliente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_ClienteId",
                table: "Telefones",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoCompra_ClienteId",
                table: "HistoricoCompra",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoCliente_ClienteId",
                table: "HistoricoCliente",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_ClienteId",
                table: "Emails",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_Cliente_ClienteId",
                table: "Emails",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricoCliente_Cliente_ClienteId",
                table: "HistoricoCliente",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricoCompra_Cliente_ClienteId",
                table: "HistoricoCompra",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Telefones_Cliente_ClienteId",
                table: "Telefones",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
