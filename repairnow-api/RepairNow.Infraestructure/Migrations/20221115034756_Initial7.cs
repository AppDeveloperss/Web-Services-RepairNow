using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepairNow.Infraestructure.Migrations
{
    public partial class Initial7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 14, 22, 47, 56, 821, DateTimeKind.Local).AddTicks(8154),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 14, 22, 6, 57, 283, DateTimeKind.Local).AddTicks(7073));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Reports",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 14, 22, 47, 56, 821, DateTimeKind.Local).AddTicks(8876),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 14, 22, 6, 57, 283, DateTimeKind.Local).AddTicks(7804));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Appointments",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 14, 22, 47, 56, 821, DateTimeKind.Local).AddTicks(9475),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 14, 22, 6, 57, 283, DateTimeKind.Local).AddTicks(8403));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Appliances",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 14, 22, 47, 56, 822, DateTimeKind.Local).AddTicks(115),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 14, 22, 6, 57, 283, DateTimeKind.Local).AddTicks(9062));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 14, 22, 6, 57, 283, DateTimeKind.Local).AddTicks(7073),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 14, 22, 47, 56, 821, DateTimeKind.Local).AddTicks(8154));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Reports",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 14, 22, 6, 57, 283, DateTimeKind.Local).AddTicks(7804),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 14, 22, 47, 56, 821, DateTimeKind.Local).AddTicks(8876));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Appointments",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 14, 22, 6, 57, 283, DateTimeKind.Local).AddTicks(8403),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 14, 22, 47, 56, 821, DateTimeKind.Local).AddTicks(9475));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Appliances",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 14, 22, 6, 57, 283, DateTimeKind.Local).AddTicks(9062),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 14, 22, 47, 56, 822, DateTimeKind.Local).AddTicks(115));
        }
    }
}
