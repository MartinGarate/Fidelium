using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class InicioProyecto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellido = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefono = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Instagram = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ComprasServicios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClienteID = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCompra = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ComentarioFeedback = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprasServicios", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Notificaciones",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CompraServicioID = table.Column<int>(type: "int", nullable: false),
                    FechaGenerada = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DiasParaRecordatorio = table.Column<int>(type: "int", nullable: false),
                    FechaRecordatorio = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    ComentarioEmpleado = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificaciones", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoUsuario = table.Column<int>(type: "int", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "ID", "Apellido", "DeleteDate", "Email", "FechaCreacion", "Instagram", "IsDeleted", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "Machado", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "valeprivado03@gmail.com", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "vale.macha2", false, "Valentin", "3498000000" },
                    { 2, "Detal", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fulanitodetal@gmail.com", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "fulanito.detal", false, "Fulanito", "3498000001" }
                });

            migrationBuilder.InsertData(
                table: "ComprasServicios",
                columns: new[] { "ID", "ClienteID", "ComentarioFeedback", "DeleteDate", "Descripcion", "FechaCompra", "IsDeleted" },
                values: new object[,]
                {
                    { 1, 1, "Muy conforme con el servicio", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Compra de PC Gamer", new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 2, 2, "Buen servicio, pero podría mejorar la atención", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Servicio Tecnico de PC", new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false }
                });

            migrationBuilder.InsertData(
                table: "Notificaciones",
                columns: new[] { "ID", "ComentarioEmpleado", "CompraServicioID", "DiasParaRecordatorio", "Estado", "FechaGenerada", "FechaRecordatorio", "IsDeleted" },
                values: new object[,]
                {
                    { 1, "Recordatorio programado para seguimiento.", 1, 7, 0, new DateTime(2025, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 2, null, 2, 3, 1, new DateTime(2025, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "ID", "DeleteDate", "Email", "IsDeleted", "Nombre", "PasswordHash", "TipoUsuario" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "alejandro@gmail.com", false, "Alejandro", "qwerty12345", 0 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "empleado1@gmail.com", false, "Empleado1", "qwerty12345", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "ComprasServicios");

            migrationBuilder.DropTable(
                name: "Notificaciones");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
