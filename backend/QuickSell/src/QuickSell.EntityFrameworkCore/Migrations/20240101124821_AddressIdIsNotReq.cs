﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuickSell.Migrations
{
    /// <inheritdoc />
    public partial class AddressIdIsNotReq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovementHeaders_CustomerCards_AddressID",
                table: "MovementHeaders");

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressID",
                table: "MovementHeaders",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_MovementHeaders_CustomerCards_AddressID",
                table: "MovementHeaders",
                column: "AddressID",
                principalTable: "CustomerCards",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovementHeaders_CustomerCards_AddressID",
                table: "MovementHeaders");

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressID",
                table: "MovementHeaders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MovementHeaders_CustomerCards_AddressID",
                table: "MovementHeaders",
                column: "AddressID",
                principalTable: "CustomerCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
