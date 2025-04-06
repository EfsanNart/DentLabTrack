using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentLabTrack.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrderTechnicianConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderTechnicians",
                table: "OrderTechnicians");

            migrationBuilder.DropIndex(
                name: "IX_OrderTechnicians_OrderId",
                table: "OrderTechnicians");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "OrderTechnicians");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderTechnicians",
                table: "OrderTechnicians",
                columns: new[] { "OrderId", "TechnicianId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderTechnicians",
                table: "OrderTechnicians");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "OrderTechnicians",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderTechnicians",
                table: "OrderTechnicians",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTechnicians_OrderId",
                table: "OrderTechnicians",
                column: "OrderId");
        }
    }
}
