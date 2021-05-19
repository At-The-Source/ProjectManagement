using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectManagement.Persistence.Migrations
{
    public partial class projectWithTasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Projects_ProjectId",
                table: "Tasks");

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: new Guid("2860415c-a070-4ded-bc9f-5e51e5c60d02"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: new Guid("510e161f-7e06-4f6a-bf11-ee03c3d526b2"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ProjectId",
                table: "Tasks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "CreatedBy", "CreatedDate", "Description", "LastModifiedBy", "LastModifiedDate", "ProjectName", "TaskId", "UserId" },
                values: new object[] { new Guid("44affb1e-06a8-4524-a2ce-544c81524382"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "project containing task.", null, null, "TestProject w task", new Guid("00000000-0000-0000-0000-000000000000"), null });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskId", "CreatedBy", "CreatedDate", "Description", "LastModifiedBy", "LastModifiedDate", "ProjectId", "StartDate", "StopDate", "TaskName" },
                values: new object[] { new Guid("9850415c-a070-4ded-bc7f-5e51e5c60d02"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "this task belong to a project.", null, null, new Guid("44affb1e-06a8-4524-a2ce-544c81524382"), new DateTime(2021, 5, 27, 10, 2, 11, 676, DateTimeKind.Local).AddTicks(1964), new DateTime(2021, 5, 29, 10, 2, 11, 684, DateTimeKind.Local).AddTicks(2589), "TestTask part of project" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskId", "CreatedBy", "CreatedDate", "Description", "LastModifiedBy", "LastModifiedDate", "ProjectId", "StartDate", "StopDate", "TaskName" },
                values: new object[] { new Guid("7630415c-a070-4ded-bc7f-5e51e5c60d02"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "this task belong to a project 2.", null, null, new Guid("44affb1e-06a8-4524-a2ce-544c81524382"), new DateTime(2021, 5, 23, 10, 2, 11, 684, DateTimeKind.Local).AddTicks(5827), new DateTime(2021, 5, 31, 10, 2, 11, 684, DateTimeKind.Local).AddTicks(5858), "TestTask part of project 2" });

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Projects_ProjectId",
                table: "Tasks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Projects_ProjectId",
                table: "Tasks");

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: new Guid("7630415c-a070-4ded-bc7f-5e51e5c60d02"));

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "TaskId",
                keyValue: new Guid("9850415c-a070-4ded-bc7f-5e51e5c60d02"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: new Guid("44affb1e-06a8-4524-a2ce-544c81524382"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ProjectId",
                table: "Tasks",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskId", "CreatedBy", "CreatedDate", "Description", "LastModifiedBy", "LastModifiedDate", "ProjectId", "StartDate", "StopDate", "TaskName" },
                values: new object[] { new Guid("510e161f-7e06-4f6a-bf11-ee03c3d526b2"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Do test stuff 1.", null, null, null, new DateTime(2021, 5, 15, 10, 27, 1, 266, DateTimeKind.Local).AddTicks(3192), new DateTime(2021, 6, 2, 10, 27, 1, 272, DateTimeKind.Local).AddTicks(3475), "TestTask 1" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TaskId", "CreatedBy", "CreatedDate", "Description", "LastModifiedBy", "LastModifiedDate", "ProjectId", "StartDate", "StopDate", "TaskName" },
                values: new object[] { new Guid("2860415c-a070-4ded-bc9f-5e51e5c60d02"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Do test stuff 2.", null, null, null, new DateTime(2021, 5, 21, 10, 27, 1, 272, DateTimeKind.Local).AddTicks(5021), new DateTime(2021, 5, 23, 10, 27, 1, 272, DateTimeKind.Local).AddTicks(5044), "TestTask 2" });

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Projects_ProjectId",
                table: "Tasks",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
