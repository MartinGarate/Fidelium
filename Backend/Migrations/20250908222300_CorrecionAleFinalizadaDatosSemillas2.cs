using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class CorrecionAleFinalizadaDatosSemillas2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Clientes_UsuarioID",
                table: "Clientes",
                column: "UsuarioID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Usuarios_UsuarioID",
                table: "Clientes",
                column: "UsuarioID",
                principalTable: "Usuarios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Usuarios_UsuarioID",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_UsuarioID",
                table: "Clientes");
        }
    }
}
