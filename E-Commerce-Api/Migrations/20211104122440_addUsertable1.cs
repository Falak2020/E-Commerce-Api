using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Commerce_Api.Migrations
{
    public partial class addUsertable1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderModel_UserAddresses_AdressId",
                table: "OrderModel");

            migrationBuilder.AlterColumn<int>(
                name: "AdressId",
                table: "OrderModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DeliveryAddressId",
                table: "OrderModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderModel_UserAddresses_AdressId",
                table: "OrderModel",
                column: "AdressId",
                principalTable: "UserAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderModel_UserAddresses_AdressId",
                table: "OrderModel");

            migrationBuilder.DropColumn(
                name: "DeliveryAddressId",
                table: "OrderModel");

            migrationBuilder.AlterColumn<int>(
                name: "AdressId",
                table: "OrderModel",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderModel_UserAddresses_AdressId",
                table: "OrderModel",
                column: "AdressId",
                principalTable: "UserAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
