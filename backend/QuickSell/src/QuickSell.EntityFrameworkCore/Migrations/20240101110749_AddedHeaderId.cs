using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickSell.Migrations
{
    /// <inheritdoc />
    public partial class AddedHeaderId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AddressCode",
                table: "CustomerAddresses",
                newName: "Code");

            migrationBuilder.AddColumn<Guid>(
                name: "HeaderId",
                table: "MovementDetails",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_MovementDetails_HeaderId",
                table: "MovementDetails",
                column: "HeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovementDetails_StockCards_HeaderId",
                table: "MovementDetails",
                column: "HeaderId",
                principalTable: "StockCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovementDetails_StockCards_HeaderId",
                table: "MovementDetails");

            migrationBuilder.DropIndex(
                name: "IX_MovementDetails_HeaderId",
                table: "MovementDetails");

            migrationBuilder.DropColumn(
                name: "HeaderId",
                table: "MovementDetails");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "CustomerAddresses",
                newName: "AddressCode");
        }
    }
}
