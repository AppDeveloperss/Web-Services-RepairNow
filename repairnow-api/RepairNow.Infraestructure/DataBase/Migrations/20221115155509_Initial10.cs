using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepairNow.Infraestructure.Migrations
{
    public partial class Initial10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Users_Userid",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_Userid",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "Userid",
                table: "Reports");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 15, 10, 55, 9, 677, DateTimeKind.Local).AddTicks(5034),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 15, 10, 14, 54, 201, DateTimeKind.Local).AddTicks(9257));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Reports",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 15, 10, 55, 9, 677, DateTimeKind.Local).AddTicks(5886),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 15, 10, 14, 54, 201, DateTimeKind.Local).AddTicks(9979));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Appointments",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 15, 10, 55, 9, 677, DateTimeKind.Local).AddTicks(6457),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 15, 10, 14, 54, 202, DateTimeKind.Local).AddTicks(570));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Appliances",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 15, 10, 55, 9, 677, DateTimeKind.Local).AddTicks(7014),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 15, 10, 14, 54, 202, DateTimeKind.Local).AddTicks(1138));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 15, 10, 14, 54, 201, DateTimeKind.Local).AddTicks(9257),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 15, 10, 55, 9, 677, DateTimeKind.Local).AddTicks(5034));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Reports",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 15, 10, 14, 54, 201, DateTimeKind.Local).AddTicks(9979),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 15, 10, 55, 9, 677, DateTimeKind.Local).AddTicks(5886));

            migrationBuilder.AddColumn<int>(
                name: "Userid",
                table: "Reports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Appointments",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 15, 10, 14, 54, 202, DateTimeKind.Local).AddTicks(570),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 15, 10, 55, 9, 677, DateTimeKind.Local).AddTicks(6457));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Appliances",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 15, 10, 14, 54, 202, DateTimeKind.Local).AddTicks(1138),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 15, 10, 55, 9, 677, DateTimeKind.Local).AddTicks(7014));

            migrationBuilder.CreateIndex(
                name: "IX_Reports_Userid",
                table: "Reports",
                column: "Userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Users_Userid",
                table: "Reports",
                column: "Userid",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
