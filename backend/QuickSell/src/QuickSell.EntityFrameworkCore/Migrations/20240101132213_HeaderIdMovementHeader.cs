using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickSell.Migrations
{
    /// <inheritdoc />
    public partial class HeaderIdMovementHeader : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovementDetails_StockCards_HeaderId",
                table: "MovementDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_MovementDetails_MovementHeaders_HeaderId",
                table: "MovementDetails",
                column: "HeaderId",
                principalTable: "MovementHeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovementDetails_MovementHeaders_HeaderId",
                table: "MovementDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_MovementDetails_StockCards_HeaderId",
                table: "MovementDetails",
                column: "HeaderId",
                principalTable: "StockCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
