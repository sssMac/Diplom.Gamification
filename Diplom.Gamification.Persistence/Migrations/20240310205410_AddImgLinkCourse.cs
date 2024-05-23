﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diplom.Gamification.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddImgLinkCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgLink",
                table: "Courses",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("3e7688d0-be96-4e3c-9450-432710b31c7b"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 20, 54, 9, 904, DateTimeKind.Utc).AddTicks(5849));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("7a975ea2-ee10-45b7-85d7-d5c646e828fd"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 20, 54, 9, 904, DateTimeKind.Utc).AddTicks(5845));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("e8de9c11-44b5-42d6-baee-0f04f3638047"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 20, 54, 9, 904, DateTimeKind.Utc).AddTicks(5842));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("d33027fc-4b48-4b54-a77d-8931d270257c"),
                columns: new[] { "CreatedAt", "ImgLink" },
                values: new object[] { new DateTime(2024, 3, 10, 20, 54, 9, 904, DateTimeKind.Utc).AddTicks(6843), null });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("f9554ddd-897a-4c7e-8840-e89d1075c053"),
                columns: new[] { "CreatedAt", "ImgLink" },
                values: new object[] { new DateTime(2024, 3, 10, 20, 54, 9, 904, DateTimeKind.Utc).AddTicks(6846), null });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("0ca39402-5d58-42e4-b354-6d66723b449e"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 20, 54, 9, 904, DateTimeKind.Utc).AddTicks(7442));

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("c004c26e-3be6-4581-8989-a4478e8065e2"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 20, 54, 9, 904, DateTimeKind.Utc).AddTicks(7444));

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("e02186a7-4b2e-4206-a076-2ccdd41fc4fb"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 10, 20, 54, 9, 904, DateTimeKind.Utc).AddTicks(7439));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "8a8670b4-afb9-4734-a596-ffc3d2156e50",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cdf27331-91af-47c8-9faa-a34a07e821fa", "AQAAAAIAAYagAAAAEKNTfUDPcjj4pvmRLe0naalE7CiEzQ3jPK7HNrFrK9Tzqw3Med8Hy5c/BFYY+TldAA==", "73a055bc-c345-40b7-a8e4-37244dfef300" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgLink",
                table: "Courses");

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("3e7688d0-be96-4e3c-9450-432710b31c7b"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 3, 1, 3, 16, 260, DateTimeKind.Utc).AddTicks(6172));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("7a975ea2-ee10-45b7-85d7-d5c646e828fd"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 3, 1, 3, 16, 260, DateTimeKind.Utc).AddTicks(6169));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("e8de9c11-44b5-42d6-baee-0f04f3638047"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 3, 1, 3, 16, 260, DateTimeKind.Utc).AddTicks(6165));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("d33027fc-4b48-4b54-a77d-8931d270257c"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 3, 1, 3, 16, 260, DateTimeKind.Utc).AddTicks(7121));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("f9554ddd-897a-4c7e-8840-e89d1075c053"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 3, 1, 3, 16, 260, DateTimeKind.Utc).AddTicks(7124));

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("0ca39402-5d58-42e4-b354-6d66723b449e"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 3, 1, 3, 16, 260, DateTimeKind.Utc).AddTicks(7668));

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("c004c26e-3be6-4581-8989-a4478e8065e2"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 3, 1, 3, 16, 260, DateTimeKind.Utc).AddTicks(7671));

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("e02186a7-4b2e-4206-a076-2ccdd41fc4fb"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 3, 1, 3, 16, 260, DateTimeKind.Utc).AddTicks(7666));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "8a8670b4-afb9-4734-a596-ffc3d2156e50",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1e85b318-5253-446d-afef-0c9e7b180eae", "AQAAAAIAAYagAAAAEBovmuld8+2Ezm1dF5rVia6V1q8pyiY+Fbhl5Y+rEz05VlCPa27farWE8OIUJXj+ig==", "6659aab1-5bcb-4ac3-bbfe-9f324f319156" });
        }
    }
}
