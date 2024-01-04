using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickSell.Migrations
{
    /// <inheritdoc />
    public partial class updatedTaxNo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovementHeaders_CustomerCards_AddressID",
                table: "MovementHeaders");

            migrationBuilder.DropIndex(
                name: "IX_MovementHeaders_AddressID",
                table: "MovementHeaders");

            migrationBuilder.DropColumn(
                name: "AddressID",
                table: "MovementHeaders");

            migrationBuilder.AlterColumn<string>(
                name: "TaxNo",
                table: "CustomerCards",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AddressID",
                table: "MovementHeaders",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TaxNo",
                table: "CustomerCards",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_MovementHeaders_AddressID",
                table: "MovementHeaders",
                column: "AddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_MovementHeaders_CustomerCards_AddressID",
                table: "MovementHeaders",
                column: "AddressID",
                principalTable: "CustomerCards",
                principalColumn: "Id");
        }
    }
}
