using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Commerce_Api.Migrations
{
    public partial class tableAddressUser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderModel_userAddresses_UserAddressId",
                table: "OrderModel");

            migrationBuilder.AlterColumn<int>(
                name: "UserAddressId",
                table: "OrderModel",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderModel_userAddresses_UserAddressId",
                table: "OrderModel",
                column: "UserAddressId",
                principalTable: "userAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderModel_userAddresses_UserAddressId",
                table: "OrderModel");

            migrationBuilder.AlterColumn<int>(
                name: "UserAddressId",
                table: "OrderModel",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderModel_userAddresses_UserAddressId",
                table: "OrderModel",
                column: "UserAddressId",
                principalTable: "userAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
