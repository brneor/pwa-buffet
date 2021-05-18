using Microsoft.EntityFrameworkCore.Migrations;

namespace Buffet.Migrations
{
    public partial class UpdateClienteAndContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_TipoClienteEntity_TipoClienteId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Convidados_SituacaoConvidadoEntity_SituacaoConvidadoId",
                table: "Convidados");

            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_SituacaoEventoEntity_SituacaoEventoId",
                table: "Eventos");

            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_TipoEventoEntity_TipoEventoId",
                table: "Eventos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoEventoEntity",
                table: "TipoEventoEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoClienteEntity",
                table: "TipoClienteEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SituacaoEventoEntity",
                table: "SituacaoEventoEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SituacaoConvidadoEntity",
                table: "SituacaoConvidadoEntity");

            migrationBuilder.RenameTable(
                name: "TipoEventoEntity",
                newName: "TipoEvento");

            migrationBuilder.RenameTable(
                name: "TipoClienteEntity",
                newName: "TipoCliente");

            migrationBuilder.RenameTable(
                name: "SituacaoEventoEntity",
                newName: "SituacaoEvento");

            migrationBuilder.RenameTable(
                name: "SituacaoConvidadoEntity",
                newName: "SituacaoConvidado");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoEvento",
                table: "TipoEvento",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoCliente",
                table: "TipoCliente",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SituacaoEvento",
                table: "SituacaoEvento",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SituacaoConvidado",
                table: "SituacaoConvidado",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_TipoCliente_TipoClienteId",
                table: "Clientes",
                column: "TipoClienteId",
                principalTable: "TipoCliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Convidados_SituacaoConvidado_SituacaoConvidadoId",
                table: "Convidados",
                column: "SituacaoConvidadoId",
                principalTable: "SituacaoConvidado",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_SituacaoEvento_SituacaoEventoId",
                table: "Eventos",
                column: "SituacaoEventoId",
                principalTable: "SituacaoEvento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_TipoEvento_TipoEventoId",
                table: "Eventos",
                column: "TipoEventoId",
                principalTable: "TipoEvento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_TipoCliente_TipoClienteId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Convidados_SituacaoConvidado_SituacaoConvidadoId",
                table: "Convidados");

            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_SituacaoEvento_SituacaoEventoId",
                table: "Eventos");

            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_TipoEvento_TipoEventoId",
                table: "Eventos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoEvento",
                table: "TipoEvento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoCliente",
                table: "TipoCliente");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SituacaoEvento",
                table: "SituacaoEvento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SituacaoConvidado",
                table: "SituacaoConvidado");

            migrationBuilder.RenameTable(
                name: "TipoEvento",
                newName: "TipoEventoEntity");

            migrationBuilder.RenameTable(
                name: "TipoCliente",
                newName: "TipoClienteEntity");

            migrationBuilder.RenameTable(
                name: "SituacaoEvento",
                newName: "SituacaoEventoEntity");

            migrationBuilder.RenameTable(
                name: "SituacaoConvidado",
                newName: "SituacaoConvidadoEntity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoEventoEntity",
                table: "TipoEventoEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoClienteEntity",
                table: "TipoClienteEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SituacaoEventoEntity",
                table: "SituacaoEventoEntity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SituacaoConvidadoEntity",
                table: "SituacaoConvidadoEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_TipoClienteEntity_TipoClienteId",
                table: "Clientes",
                column: "TipoClienteId",
                principalTable: "TipoClienteEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Convidados_SituacaoConvidadoEntity_SituacaoConvidadoId",
                table: "Convidados",
                column: "SituacaoConvidadoId",
                principalTable: "SituacaoConvidadoEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_SituacaoEventoEntity_SituacaoEventoId",
                table: "Eventos",
                column: "SituacaoEventoId",
                principalTable: "SituacaoEventoEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_TipoEventoEntity_TipoEventoId",
                table: "Eventos",
                column: "TipoEventoId",
                principalTable: "TipoEventoEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
