using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TBSExam.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Folios",
                columns: table => new
                {
                    folio_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    disponible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folios", x => x.folio_id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    usuario_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cveUsuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    nombreUsuario = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    usuPwd = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    numAcceso = table.Column<long>(type: "bigint", nullable: true),
                    ultimoAcceso = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.usuario_id);
                });

            migrationBuilder.CreateTable(
                name: "Bitacoras",
                columns: table => new
                {
                    shipment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    accion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shipment_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    usuario_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bitacoras", x => x.shipment_id);
                    table.ForeignKey(
                        name: "FK_Bitacoras_Usuarios_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "Usuarios",
                        principalColumn: "usuario_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    pedido_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    articulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    correo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    folio_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    usuario_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.pedido_id);
                    table.ForeignKey(
                        name: "FK_Pedidos_Folios_folio_id",
                        column: x => x.folio_id,
                        principalTable: "Folios",
                        principalColumn: "folio_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedidos_Usuarios_usuario_id",
                        column: x => x.usuario_id,
                        principalTable: "Usuarios",
                        principalColumn: "usuario_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bitacoras_usuario_id",
                table: "Bitacoras",
                column: "usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_folio_id",
                table: "Pedidos",
                column: "folio_id");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_usuario_id",
                table: "Pedidos",
                column: "usuario_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bitacoras");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Folios");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
