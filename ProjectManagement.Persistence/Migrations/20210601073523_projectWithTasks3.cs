using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManagement.Persistence.Migrations
{
    public partial class projectWithTasks3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: new Guid("7630415c-a070-4ded-bc7f-5e51e5c60d02"),
                columns: new[] { "StartDate", "StopDate" },
                values: new object[] { new DateTime(2021, 6, 5, 9, 35, 21, 999, DateTimeKind.Local).AddTicks(9228), new DateTime(2021, 6, 13, 9, 35, 21, 999, DateTimeKind.Local).AddTicks(9270) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: new Guid("9850415c-a070-4ded-bc7f-5e51e5c60d02"),
                columns: new[] { "StartDate", "StopDate" },
                values: new object[] { new DateTime(2021, 6, 9, 9, 35, 21, 993, DateTimeKind.Local).AddTicks(3945), new DateTime(2021, 6, 11, 9, 35, 21, 999, DateTimeKind.Local).AddTicks(5932) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: new Guid("7630415c-a070-4ded-bc7f-5e51e5c60d02"),
                columns: new[] { "StartDate", "StopDate" },
                values: new object[] { new DateTime(2021, 5, 23, 10, 19, 10, 550, DateTimeKind.Local).AddTicks(6603), new DateTime(2021, 5, 31, 10, 19, 10, 550, DateTimeKind.Local).AddTicks(6629) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: new Guid("9850415c-a070-4ded-bc7f-5e51e5c60d02"),
                columns: new[] { "StartDate", "StopDate" },
                values: new object[] { new DateTime(2021, 5, 27, 10, 19, 10, 545, DateTimeKind.Local).AddTicks(8984), new DateTime(2021, 5, 29, 10, 19, 10, 550, DateTimeKind.Local).AddTicks(3828) });
        }
    }
}
