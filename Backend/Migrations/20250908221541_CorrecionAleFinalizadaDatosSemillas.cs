using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class CorrecionAleFinalizadaDatosSemillas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComprasServicios_Usuarios_UsuarioID",
                table: "ComprasServicios");

            migrationBuilder.DropForeignKey(
                name: "FK_Notificaciones_Usuarios_UsuarioID",
                table: "Notificaciones");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "UsuarioID",
                table: "Notificaciones",
                newName: "EmpleadoID");

            migrationBuilder.RenameIndex(
                name: "IX_Notificaciones_UsuarioID",
                table: "Notificaciones",
                newName: "IX_Notificaciones_EmpleadoID");

            migrationBuilder.RenameColumn(
                name: "UsuarioID",
                table: "ComprasServicios",
                newName: "EmpleadoID");

            migrationBuilder.RenameIndex(
                name: "IX_ComprasServicios_UsuarioID",
                table: "ComprasServicios",
                newName: "IX_ComprasServicios_EmpleadoID");

            migrationBuilder.AddColumn<int>(
                name: "ClienteID",
                table: "Notificaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "Notificaciones",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Notificaciones",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ComprasServicios",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "ComprasServicios",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Telefono",
                table: "Clientes",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioID",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Instagram", "Telefono", "UsuarioID" },
                values: new object[] { "Vale.macha2", "3498 474852", 1 });

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Instagram", "Telefono", "UsuarioID" },
                values: new object[] { "Fulanito.detal", "3498 474853", 2 });

            migrationBuilder.UpdateData(
                table: "ComprasServicios",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EmpleadoID", "UpdateAt" },
                values: new object[] { new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "ComprasServicios",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EmpleadoID", "UpdateAt" },
                values: new object[] { new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Notificaciones",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "ClienteID", "CreateAt", "EmpleadoID", "UpdateAt" },
                values: new object[] { 1, new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Notificaciones",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "ClienteID", "CreateAt", "EmpleadoID", "UpdateAt" },
                values: new object[] { 2, new DateTime(2025, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "DNI", "Email", "Nombre", "Password", "TipoUsuario" },
                values: new object[] { 46447189, "valemacha1805@gmail.com", "Valentino", "", 2 });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "DNI", "Email", "Nombre", "Password" },
                values: new object[] { 46447190, "martingarate0@gmail.com", "Martin", "" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "DNI", "Email", "Nombre", "Password", "TipoUsuario" },
                values: new object[] { 46997851, "martingarate100@gmail.com", "Martin G", "", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Notificaciones_ClienteID",
                table: "Notificaciones",
                column: "ClienteID");

            migrationBuilder.AddForeignKey(
                name: "FK_ComprasServicios_Usuarios_EmpleadoID",
                table: "ComprasServicios",
                column: "EmpleadoID",
                principalTable: "Usuarios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notificaciones_Clientes_ClienteID",
                table: "Notificaciones",
                column: "ClienteID",
                principalTable: "Clientes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notificaciones_Usuarios_EmpleadoID",
                table: "Notificaciones",
                column: "EmpleadoID",
                principalTable: "Usuarios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComprasServicios_Usuarios_EmpleadoID",
                table: "ComprasServicios");

            migrationBuilder.DropForeignKey(
                name: "FK_Notificaciones_Clientes_ClienteID",
                table: "Notificaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Notificaciones_Usuarios_EmpleadoID",
                table: "Notificaciones");

            migrationBuilder.DropIndex(
                name: "IX_Notificaciones_ClienteID",
                table: "Notificaciones");

            migrationBuilder.DropColumn(
                name: "ClienteID",
                table: "Notificaciones");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "Notificaciones");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Notificaciones");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ComprasServicios");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "ComprasServicios");

            migrationBuilder.DropColumn(
                name: "UsuarioID",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "EmpleadoID",
                table: "Notificaciones",
                newName: "UsuarioID");

            migrationBuilder.RenameIndex(
                name: "IX_Notificaciones_EmpleadoID",
                table: "Notificaciones",
                newName: "IX_Notificaciones_UsuarioID");

            migrationBuilder.RenameColumn(
                name: "EmpleadoID",
                table: "ComprasServicios",
                newName: "UsuarioID");

            migrationBuilder.RenameIndex(
                name: "IX_ComprasServicios_EmpleadoID",
                table: "ComprasServicios",
                newName: "IX_ComprasServicios_UsuarioID");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Usuarios",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "Telefono",
                keyValue: null,
                column: "Telefono",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Telefono",
                table: "Clientes",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Clientes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Clientes",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Clientes",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Clientes",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Clientes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Apellido", "DeleteDate", "Email", "FechaCreacion", "Instagram", "Nombre", "Telefono" },
                values: new object[] { "Machado", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "valeprivado03@gmail.com", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "vale.macha2", "Valentin", "3498000000" });

            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Apellido", "DeleteDate", "Email", "FechaCreacion", "Instagram", "Nombre", "Telefono" },
                values: new object[] { "Detal", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fulanitodetal@gmail.com", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fulanito.detal", "Fulanito", "3498000001" });

            migrationBuilder.UpdateData(
                table: "ComprasServicios",
                keyColumn: "ID",
                keyValue: 1,
                column: "UsuarioID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ComprasServicios",
                keyColumn: "ID",
                keyValue: 2,
                column: "UsuarioID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Notificaciones",
                keyColumn: "ID",
                keyValue: 1,
                column: "UsuarioID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Notificaciones",
                keyColumn: "ID",
                keyValue: 2,
                column: "UsuarioID",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "DNI", "DeleteDate", "Email", "Nombre", "Password", "TipoUsuario" },
                values: new object[] { 12345678, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "alejandro@gmail.com", "Alejandro", "qwerty12345", 0 });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "DNI", "DeleteDate", "Email", "Nombre", "Password" },
                values: new object[] { 123456789, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "empleado1@gmail.com", "Empleado1", "qwerty12345" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "DNI", "DeleteDate", "Email", "Nombre", "Password", "TipoUsuario" },
                values: new object[] { 123456790, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Usuario1@gmail.com", "UsuarioTest", "qwerty12345", 2 });

            migrationBuilder.AddForeignKey(
                name: "FK_ComprasServicios_Usuarios_UsuarioID",
                table: "ComprasServicios",
                column: "UsuarioID",
                principalTable: "Usuarios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notificaciones_Usuarios_UsuarioID",
                table: "Notificaciones",
                column: "UsuarioID",
                principalTable: "Usuarios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
