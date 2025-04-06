using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentLabTrack.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrderTechnician : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Orders_OrderId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_UserId",
                table: "Notifications");

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

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "OrderTechnicians",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OrderTechnicians",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "OrderTechnicians",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderTechnicians",
                table: "OrderTechnicians",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTechnicians_OrderId",
                table: "OrderTechnicians",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Orders_OrderId",
                table: "Notifications",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_UserId",
                table: "Notifications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Orders_OrderId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_UserId",
                table: "Notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderTechnicians",
                table: "OrderTechnicians");

            migrationBuilder.DropIndex(
                name: "IX_OrderTechnicians_OrderId",
                table: "OrderTechnicians");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "OrderTechnicians");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "OrderTechnicians");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "OrderTechnicians");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "OrderTechnicians");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderTechnicians",
                table: "OrderTechnicians",
                columns: new[] { "OrderId", "TechnicianId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Orders_OrderId",
                table: "Notifications",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_UserId",
                table: "Notifications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
