using Microsoft.EntityFrameworkCore.Migrations;

namespace Buffet.Migrations
{
    public partial class EventoRelationshipUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Convidados_Eventos_EventoId",
                table: "Convidados");

            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Locais_LocalId",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_LocalId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "LocalId",
                table: "Eventos");

            migrationBuilder.AddColumn<int>(
                name: "LocalEntityId",
                table: "Eventos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "EventoId",
                table: "Convidados",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_LocalEntityId",
                table: "Eventos",
                column: "LocalEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Convidados_Eventos_EventoId",
                table: "Convidados",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Locais_LocalEntityId",
                table: "Eventos",
                column: "LocalEntityId",
                principalTable: "Locais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Convidados_Eventos_EventoId",
                table: "Convidados");

            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Locais_LocalEntityId",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_LocalEntityId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "LocalEntityId",
                table: "Eventos");

            migrationBuilder.AddColumn<int>(
                name: "LocalId",
                table: "Eventos",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EventoId",
                table: "Convidados",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_LocalId",
                table: "Eventos",
                column: "LocalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Convidados_Eventos_EventoId",
                table: "Convidados",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Locais_LocalId",
                table: "Eventos",
                column: "LocalId",
                principalTable: "Locais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
