using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Commerce_Api.Migrations
{
    public partial class delete8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderModel_Addresses_AddressId",
                table: "OrderModel");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "OrderModel",
                newName: "AdressId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderModel_AddressId",
                table: "OrderModel",
                newName: "IX_OrderModel_AdressId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderModel_Addresses_AdressId",
                table: "OrderModel",
                column: "AdressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderModel_Addresses_AdressId",
                table: "OrderModel");

            migrationBuilder.RenameColumn(
                name: "AdressId",
                table: "OrderModel",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderModel_AdressId",
                table: "OrderModel",
                newName: "IX_OrderModel_AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderModel_Addresses_AddressId",
                table: "OrderModel",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
