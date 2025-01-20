using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestPO.Migrations
{
    /// <inheritdoc />
    public partial class Migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Customers_ClientCustomerId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_ClientCustomerId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "ClientCustomerId",
                table: "Sales");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Sales",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CustomerId",
                table: "Sales",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Customers_CustomerId",
                table: "Sales",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Customers_CustomerId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_CustomerId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Sales");

            migrationBuilder.AddColumn<int>(
                name: "ClientCustomerId",
                table: "Sales",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ClientCustomerId",
                table: "Sales",
                column: "ClientCustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Customers_ClientCustomerId",
                table: "Sales",
                column: "ClientCustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId");
        }
    }
}
