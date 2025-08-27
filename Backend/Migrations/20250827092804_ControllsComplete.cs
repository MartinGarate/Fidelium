using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class ControllsComplete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Notificaciones_CompraServicioID",
                table: "Notificaciones",
                column: "CompraServicioID");

            migrationBuilder.CreateIndex(
                name: "IX_ComprasServicios_ClienteID",
                table: "ComprasServicios",
                column: "ClienteID");

            migrationBuilder.AddForeignKey(
                name: "FK_ComprasServicios_Clientes_ClienteID",
                table: "ComprasServicios",
                column: "ClienteID",
                principalTable: "Clientes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notificaciones_ComprasServicios_CompraServicioID",
                table: "Notificaciones",
                column: "CompraServicioID",
                principalTable: "ComprasServicios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComprasServicios_Clientes_ClienteID",
                table: "ComprasServicios");

            migrationBuilder.DropForeignKey(
                name: "FK_Notificaciones_ComprasServicios_CompraServicioID",
                table: "Notificaciones");

            migrationBuilder.DropIndex(
                name: "IX_Notificaciones_CompraServicioID",
                table: "Notificaciones");

            migrationBuilder.DropIndex(
                name: "IX_ComprasServicios_ClienteID",
                table: "ComprasServicios");
        }
    }
}
