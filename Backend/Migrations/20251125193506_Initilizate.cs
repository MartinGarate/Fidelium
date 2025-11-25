using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class Initilizate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DNI = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoUsuario = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UsuarioID = table.Column<int>(type: "int", nullable: false),
                    Telefono = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Instagram = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Clientes_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ComprasServicios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClienteID = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descripcion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCompra = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ComentarioFeedback = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmpleadoID = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprasServicios", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ComprasServicios_Clientes_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComprasServicios_Usuarios_EmpleadoID",
                        column: x => x.EmpleadoID,
                        principalTable: "Usuarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Notificaciones",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ComentarioEmpleado = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DiasParaRecordatorio = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    FechaGenerada = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaRecordatorio = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CompraServicioID = table.Column<int>(type: "int", nullable: false),
                    ClienteID = table.Column<int>(type: "int", nullable: false),
                    EmpleadoID = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificaciones", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Notificaciones_Clientes_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notificaciones_ComprasServicios_CompraServicioID",
                        column: x => x.CompraServicioID,
                        principalTable: "ComprasServicios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notificaciones_Usuarios_EmpleadoID",
                        column: x => x.EmpleadoID,
                        principalTable: "Usuarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "ID", "DNI", "DeleteDate", "Email", "IsDeleted", "Nombre", "TipoUsuario" },
                values: new object[,]
                {
                    { 1, "46997850", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "martingarate0@gmail.com", false, "Martin Garte", 0 },
                    { 2, "39144832", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "leonelarrieta@gmail.com", false, "Leonel Arrieta", 0 },
                    { 3, "46447189", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "valentinomachado@gmail.com", false, "Valentino Machado", 0 },
                    { 4, "123456789", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "testdelete@gmail.com", true, "Test Delete", 0 },
                    { 5, "41287827", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "corradicande@gmail.com", false, "Candela Agustina Corradi", 1 },
                    { 6, "40317292", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ximenagorosito0@gmail.com", false, "Ximena Gorosito", 1 },
                    { 7, "123456781", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "testdelete2@gmail.com", true, "Test2 Delete", 1 },
                    { 8, "46133497", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "danielobregon621@gmail.com", false, "Daniel Alejandro Obregon", 2 },
                    { 9, "45641614", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "lucilencina6@gmail.com", false, "Lucia Lencina", 2 },
                    { 10, "123456782", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "testdelete3@gmail.com", true, "Test3 Delete", 2 }
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "ID", "DeleteDate", "Instagram", "IsDeleted", "Telefono", "UsuarioID" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "@danielobregon02", false, "+54 9 3498 455605", 8 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "@lucia.nwn_", false, "+54 9 3498 416195", 9 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "@test", true, "+12 3 4567 890123", 10 }
                });

            migrationBuilder.InsertData(
                table: "ComprasServicios",
                columns: new[] { "ID", "ClienteID", "ComentarioFeedback", "CreatedAt", "DeleteDate", "Descripcion", "EmpleadoID", "FechaCompra", "IsDeleted", "Nombre", "UpdateAt" },
                values: new object[,]
                {
                    { 1, 1, "Excelente producto y muy buena atención al público. Muy recomendado.", new DateTime(2025, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Upgrade de GPU para mejorar rendimiento en gaming y rendering", 1, new DateTime(2025, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Compra de Tarjeta Gráfica Gigabyte RTX 3050Ti", new DateTime(2025, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, "Trabajo muy profesional, PC corriendo perfectamente", new DateTime(2025, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Instalación limpia de Windows 11 Pro con drivers actualizados", 5, new DateTime(2025, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Servicio de Instalación de SO Windows 11 Pro", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, "Excelente servicio, la PC ahora funciona mucho más rápido", new DateTime(2025, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Limpieza a fondo interna y externa, cambio de pasta térmica", 2, new DateTime(2025, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Servicio de Limpieza Profesional de PC", new DateTime(2025, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 2, "Proceso rápido y eficiente. Ahora puedo correr múltiples aplicaciones sin lag", new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Instalación de módulos RAM Corsair Vengeance para multitarea", 6, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Upgrade de RAM a 32GB DDR4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 2, "Muy útil, ahora tengo mi red segura y optimizada", new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Asesoramiento en configuración de red doméstica y seguridad", 3, new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Consultoría de Configuración de Red", new DateTime(2025, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 3, "Servicio eliminado - prueba de soft delete", new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Instalación de unidad SSD rápida para sistema operativo", 2, new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Compra de SSD NVMe 1TB", new DateTime(2025, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Notificaciones",
                columns: new[] { "ID", "ClienteID", "ComentarioEmpleado", "CompraServicioID", "CreateAt", "DeleteDate", "DiasParaRecordatorio", "EmpleadoID", "Estado", "FechaGenerada", "FechaRecordatorio", "IsDeleted", "UpdateAt" },
                values: new object[,]
                {
                    { 1, 1, "Seguimiento post-venta de GPU, verificar compatibilidad y rendimiento", 1, new DateTime(2025, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 1, 0, new DateTime(2025, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, "Verificar que la instalación de Windows 11 Pro se completó correctamente", 2, new DateTime(2025, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 5, 1, new DateTime(2025, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2025, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, "Follow-up de limpieza de PC, preguntar si hay mejora en temperatura", 3, new DateTime(2025, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, 2, 1, new DateTime(2025, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2025, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 2, "Verificación del upgrade de RAM, evaluar satisfacción del cliente", 4, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 6, 0, new DateTime(2025, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 2, "Evaluación de satisfacción post-consultoría de configuración de red", 5, new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, 3, 0, new DateTime(2025, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 3, "Notificación eliminada - prueba de soft delete", 6, new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 2, 0, new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_UsuarioID",
                table: "Clientes",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_ComprasServicios_ClienteID",
                table: "ComprasServicios",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_ComprasServicios_EmpleadoID",
                table: "ComprasServicios",
                column: "EmpleadoID");

            migrationBuilder.CreateIndex(
                name: "IX_Notificaciones_ClienteID",
                table: "Notificaciones",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Notificaciones_CompraServicioID",
                table: "Notificaciones",
                column: "CompraServicioID");

            migrationBuilder.CreateIndex(
                name: "IX_Notificaciones_EmpleadoID",
                table: "Notificaciones",
                column: "EmpleadoID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notificaciones");

            migrationBuilder.DropTable(
                name: "ComprasServicios");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
