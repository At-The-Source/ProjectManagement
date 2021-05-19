using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManagement.Persistence.Migrations
{
    public partial class projectWithTasks2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Projects");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TaskId",
                table: "Projects",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: new Guid("7630415c-a070-4ded-bc7f-5e51e5c60d02"),
                columns: new[] { "StartDate", "StopDate" },
                values: new object[] { new DateTime(2021, 5, 23, 10, 2, 11, 684, DateTimeKind.Local).AddTicks(5827), new DateTime(2021, 5, 31, 10, 2, 11, 684, DateTimeKind.Local).AddTicks(5858) });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: new Guid("9850415c-a070-4ded-bc7f-5e51e5c60d02"),
                columns: new[] { "StartDate", "StopDate" },
                values: new object[] { new DateTime(2021, 5, 27, 10, 2, 11, 676, DateTimeKind.Local).AddTicks(1964), new DateTime(2021, 5, 29, 10, 2, 11, 684, DateTimeKind.Local).AddTicks(2589) });
        }
    }
}
