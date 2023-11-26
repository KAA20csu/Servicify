using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Servicify.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedCostForService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Cost",
                table: "Services",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Services");
        }
    }
}
