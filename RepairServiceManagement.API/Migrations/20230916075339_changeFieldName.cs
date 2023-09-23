using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepairServiceManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class changeFieldName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeviceType",
                table: "RepairRequests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RepairRequests_CustomerId",
                table: "RepairRequests",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_RepairRequests_Customers_CustomerId",
                table: "RepairRequests",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepairRequests_Customers_CustomerId",
                table: "RepairRequests");

            migrationBuilder.DropIndex(
                name: "IX_RepairRequests_CustomerId",
                table: "RepairRequests");

            migrationBuilder.DropColumn(
                name: "DeviceType",
                table: "RepairRequests");
        }
    }
}
