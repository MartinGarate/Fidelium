using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitializeProject : Migration
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
                    NotasVentaInternas = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaCompra = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FeedbackRecibido = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ComentarioFeedback = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmpleadoID = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
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
                    CompraServicioID = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    FechaGenerada = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificaciones", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Notificaciones_ComprasServicios_CompraServicioID",
                        column: x => x.CompraServicioID,
                        principalTable: "ComprasServicios",
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
                columns: new[] { "ID", "ClienteID", "ComentarioFeedback", "CreatedAt", "Descripcion", "EmpleadoID", "FechaCompra", "FeedbackRecibido", "IsDeleted", "Nombre", "NotasVentaInternas" },
                values: new object[,]
                {
                    { 1, 1, "Excelente producto.", new DateTime(2025, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Upgrade de GPU", 1, new DateTime(2025, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, "Gigabyte RTX 3050Ti", "Buscaba jugar CSGO, se llevó esta por presupuesto." },
                    { 2, 1, "", new DateTime(2025, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Instalación limpia", 5, new DateTime(2025, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false, false, "Instalación Windows 11", "PC vieja, chequear que no tire BSOD." },
                    { 6, 3, "", new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 2, new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, "SSD NVMe 1TB", "Test de borrado" }
                });

            migrationBuilder.InsertData(
                table: "Notificaciones",
                columns: new[] { "ID", "CompraServicioID", "Estado", "FechaGenerada", "IsDeleted" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2025, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 2, 2, 0, new DateTime(2025, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 6, 6, 0, new DateTime(2025, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true }
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
                name: "IX_Notificaciones_CompraServicioID",
                table: "Notificaciones",
                column: "CompraServicioID");
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
