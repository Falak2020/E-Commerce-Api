using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Commerce_Api.Migrations
{
    public partial class addUsertable3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderModel_UserAddresses_AdressId",
                table: "OrderModel");

            migrationBuilder.DropIndex(
                name: "IX_OrderModel_AdressId",
                table: "OrderModel");

            migrationBuilder.DropColumn(
                name: "AdressId",
                table: "OrderModel");

            migrationBuilder.RenameColumn(
                name: "DeliveryAddressId",
                table: "OrderModel",
                newName: "UserAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderModel_UserAddressId",
                table: "OrderModel",
                column: "UserAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderModel_UserAddresses_UserAddressId",
                table: "OrderModel",
                column: "UserAddressId",
                principalTable: "UserAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderModel_UserAddresses_UserAddressId",
                table: "OrderModel");

            migrationBuilder.DropIndex(
                name: "IX_OrderModel_UserAddressId",
                table: "OrderModel");

            migrationBuilder.RenameColumn(
                name: "UserAddressId",
                table: "OrderModel",
                newName: "DeliveryAddressId");

            migrationBuilder.AddColumn<int>(
                name: "AdressId",
                table: "OrderModel",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderModel_AdressId",
                table: "OrderModel",
                column: "AdressId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderModel_UserAddresses_AdressId",
                table: "OrderModel",
                column: "AdressId",
                principalTable: "UserAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
