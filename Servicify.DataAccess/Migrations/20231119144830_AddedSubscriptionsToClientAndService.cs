using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Servicify.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedSubscriptionsToClientAndService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientService",
                columns: table => new
                {
                    SubscribersId = table.Column<long>(type: "bigint", nullable: false),
                    SubscriptionsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientService", x => new { x.SubscribersId, x.SubscriptionsId });
                    table.ForeignKey(
                        name: "FK_ClientService_Clients_SubscribersId",
                        column: x => x.SubscribersId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientService_Services_SubscriptionsId",
                        column: x => x.SubscriptionsId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientService_SubscriptionsId",
                table: "ClientService",
                column: "SubscriptionsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientService");
        }
    }
}
