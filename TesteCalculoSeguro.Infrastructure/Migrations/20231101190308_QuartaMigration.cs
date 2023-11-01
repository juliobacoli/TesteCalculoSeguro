using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteCalculoSeguro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class QuartaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ValorSeguro",
                table: "Seguro",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorSeguro",
                table: "Seguro");
        }
    }
}
