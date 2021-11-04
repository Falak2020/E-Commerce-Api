﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Commerce_Api.Migrations
{
    public partial class tableAddressUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Addresses_AddressId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AddressId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserAddressId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserAddressId",
                table: "Addresses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "userAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userAddresses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserAddressId",
                table: "Users",
                column: "UserAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserAddressId",
                table: "Addresses",
                column: "UserAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_userAddresses_UserAddressId",
                table: "Addresses",
                column: "UserAddressId",
                principalTable: "userAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_userAddresses_UserAddressId",
                table: "Users",
                column: "UserAddressId",
                principalTable: "userAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_userAddresses_UserAddressId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_userAddresses_UserAddressId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "userAddresses");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserAddressId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_UserAddressId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "UserAddressId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserAddressId",
                table: "Addresses");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddressId",
                table: "Users",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Addresses_AddressId",
                table: "Users",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
