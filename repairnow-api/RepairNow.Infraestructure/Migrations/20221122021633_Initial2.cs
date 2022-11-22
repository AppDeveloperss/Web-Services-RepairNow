using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepairNow.Infraestructure.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 21, 21, 16, 33, 724, DateTimeKind.Local).AddTicks(1137),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 21, 20, 14, 56, 506, DateTimeKind.Local).AddTicks(1348));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Reports",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 21, 21, 16, 33, 724, DateTimeKind.Local).AddTicks(2164),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 21, 20, 14, 56, 506, DateTimeKind.Local).AddTicks(2344));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Appointments",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 21, 21, 16, 33, 724, DateTimeKind.Local).AddTicks(2760),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 21, 20, 14, 56, 506, DateTimeKind.Local).AddTicks(2872));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Appliances",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 21, 21, 16, 33, 724, DateTimeKind.Local).AddTicks(3293),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 21, 20, 14, 56, 506, DateTimeKind.Local).AddTicks(3396));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 21, 20, 14, 56, 506, DateTimeKind.Local).AddTicks(1348),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 21, 21, 16, 33, 724, DateTimeKind.Local).AddTicks(1137));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Reports",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 21, 20, 14, 56, 506, DateTimeKind.Local).AddTicks(2344),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 21, 21, 16, 33, 724, DateTimeKind.Local).AddTicks(2164));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Appointments",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 21, 20, 14, 56, 506, DateTimeKind.Local).AddTicks(2872),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 21, 21, 16, 33, 724, DateTimeKind.Local).AddTicks(2760));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "Appliances",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 21, 20, 14, 56, 506, DateTimeKind.Local).AddTicks(3396),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldDefaultValue: new DateTime(2022, 11, 21, 21, 16, 33, 724, DateTimeKind.Local).AddTicks(3293));
        }
    }
}
