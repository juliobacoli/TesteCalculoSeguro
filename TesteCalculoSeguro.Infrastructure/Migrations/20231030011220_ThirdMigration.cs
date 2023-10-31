using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteCalculoSeguro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Segurado_Seguro_SeguroId",
                table: "Segurado");

            migrationBuilder.DropForeignKey(
                name: "FK_Veiculo_Seguro_SeguroId",
                table: "Veiculo");

            migrationBuilder.DropIndex(
                name: "IX_Veiculo_SeguroId",
                table: "Veiculo");

            migrationBuilder.DropIndex(
                name: "IX_Segurado_SeguroId",
                table: "Segurado");

            migrationBuilder.DropColumn(
                name: "SeguroId",
                table: "Veiculo");

            migrationBuilder.DropColumn(
                name: "SeguroId",
                table: "Segurado");

            migrationBuilder.AddColumn<string>(
                name: "SeguradoCpf",
                table: "Seguro",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "VeiculoId",
                table: "Seguro",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Seguro_SeguradoCpf",
                table: "Seguro",
                column: "SeguradoCpf");

            migrationBuilder.CreateIndex(
                name: "IX_Seguro_VeiculoId",
                table: "Seguro",
                column: "VeiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seguro_Segurado_SeguradoCpf",
                table: "Seguro",
                column: "SeguradoCpf",
                principalTable: "Segurado",
                principalColumn: "Cpf",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seguro_Veiculo_VeiculoId",
                table: "Seguro",
                column: "VeiculoId",
                principalTable: "Veiculo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seguro_Segurado_SeguradoCpf",
                table: "Seguro");

            migrationBuilder.DropForeignKey(
                name: "FK_Seguro_Veiculo_VeiculoId",
                table: "Seguro");

            migrationBuilder.DropIndex(
                name: "IX_Seguro_SeguradoCpf",
                table: "Seguro");

            migrationBuilder.DropIndex(
                name: "IX_Seguro_VeiculoId",
                table: "Seguro");

            migrationBuilder.DropColumn(
                name: "SeguradoCpf",
                table: "Seguro");

            migrationBuilder.DropColumn(
                name: "VeiculoId",
                table: "Seguro");

            migrationBuilder.AddColumn<int>(
                name: "SeguroId",
                table: "Veiculo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SeguroId",
                table: "Segurado",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Veiculo_SeguroId",
                table: "Veiculo",
                column: "SeguroId");

            migrationBuilder.CreateIndex(
                name: "IX_Segurado_SeguroId",
                table: "Segurado",
                column: "SeguroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Segurado_Seguro_SeguroId",
                table: "Segurado",
                column: "SeguroId",
                principalTable: "Seguro",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculo_Seguro_SeguroId",
                table: "Veiculo",
                column: "SeguroId",
                principalTable: "Seguro",
                principalColumn: "Id");
        }
    }
}
