using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Commerce_Api.Migrations
{
    public partial class tableAddressUser1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderModel_Addresses_AdressId",
                table: "OrderModel");

            migrationBuilder.DropIndex(
                name: "IX_OrderModel_AdressId",
                table: "OrderModel");

            migrationBuilder.RenameColumn(
                name: "AdressId",
                table: "OrderModel",
                newName: "DeliveryAddressId");

            migrationBuilder.AddColumn<int>(
                name: "AddressModelId",
                table: "OrderModel",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserAddressId",
                table: "OrderModel",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderModel_AddressModelId",
                table: "OrderModel",
                column: "AddressModelId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderModel_UserAddressId",
                table: "OrderModel",
                column: "UserAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderModel_Addresses_AddressModelId",
                table: "OrderModel",
                column: "AddressModelId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderModel_userAddresses_UserAddressId",
                table: "OrderModel",
                column: "UserAddressId",
                principalTable: "userAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderModel_Addresses_AddressModelId",
                table: "OrderModel");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderModel_userAddresses_UserAddressId",
                table: "OrderModel");

            migrationBuilder.DropIndex(
                name: "IX_OrderModel_AddressModelId",
                table: "OrderModel");

            migrationBuilder.DropIndex(
                name: "IX_OrderModel_UserAddressId",
                table: "OrderModel");

            migrationBuilder.DropColumn(
                name: "AddressModelId",
                table: "OrderModel");

            migrationBuilder.DropColumn(
                name: "UserAddressId",
                table: "OrderModel");

            migrationBuilder.RenameColumn(
                name: "DeliveryAddressId",
                table: "OrderModel",
                newName: "AdressId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderModel_AdressId",
                table: "OrderModel",
                column: "AdressId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderModel_Addresses_AdressId",
                table: "OrderModel",
                column: "AdressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
