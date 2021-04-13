using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoCRUD.Migrations
{
    public partial class Llaves : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Productos_TipoProductoId",
                table: "Productos",
                column: "TipoProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_TipoProductos_TipoProductoId",
                table: "Productos",
                column: "TipoProductoId",
                principalTable: "TipoProductos",
                principalColumn: "TipoProductoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_TipoProductos_TipoProductoId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_TipoProductoId",
                table: "Productos");
        }
    }
}
