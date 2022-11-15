using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepairNow.Infraestructure.Migrations
{
    public partial class Initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 13, 20, 43, 29, 742, DateTimeKind.Local).AddTicks(6703),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 6, 13, 1, 41, 449, DateTimeKind.Local).AddTicks(4435));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Reports",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 13, 20, 43, 29, 742, DateTimeKind.Local).AddTicks(7610),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 6, 13, 1, 41, 449, DateTimeKind.Local).AddTicks(5088));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Appointments",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 13, 20, 43, 29, 742, DateTimeKind.Local).AddTicks(8529),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 6, 13, 1, 41, 449, DateTimeKind.Local).AddTicks(5737));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Appliances",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 13, 20, 43, 29, 742, DateTimeKind.Local).AddTicks(9647),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 6, 13, 1, 41, 449, DateTimeKind.Local).AddTicks(6351));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 6, 13, 1, 41, 449, DateTimeKind.Local).AddTicks(4435),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 13, 20, 43, 29, 742, DateTimeKind.Local).AddTicks(6703));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Reports",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 6, 13, 1, 41, 449, DateTimeKind.Local).AddTicks(5088),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 13, 20, 43, 29, 742, DateTimeKind.Local).AddTicks(7610));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Appointments",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 6, 13, 1, 41, 449, DateTimeKind.Local).AddTicks(5737),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 13, 20, 43, 29, 742, DateTimeKind.Local).AddTicks(8529));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Appliances",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 6, 13, 1, 41, 449, DateTimeKind.Local).AddTicks(6351),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 13, 20, 43, 29, 742, DateTimeKind.Local).AddTicks(9647));
        }
    }
}
