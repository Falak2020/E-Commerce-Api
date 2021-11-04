using Microsoft.EntityFrameworkCore.Migrations;

namespace E_Commerce_Api.Migrations
{
    public partial class addAddresstoORder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "OrderModel",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderModel_AddressId",
                table: "OrderModel",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderModel_Addresses_AddressId",
                table: "OrderModel",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderModel_Addresses_AddressId",
                table: "OrderModel");

            migrationBuilder.DropIndex(
                name: "IX_OrderModel_AddressId",
                table: "OrderModel");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "OrderModel");
        }
    }
}
