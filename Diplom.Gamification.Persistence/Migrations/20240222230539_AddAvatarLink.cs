using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diplom.Gamification.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddAvatarLink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AvatarLink",
                table: "User",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("3e7688d0-be96-4e3c-9450-432710b31c7b"),
                column: "CreatedAt",
                value: new DateTime(2024, 2, 22, 23, 5, 38, 918, DateTimeKind.Utc).AddTicks(4200));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("7a975ea2-ee10-45b7-85d7-d5c646e828fd"),
                column: "CreatedAt",
                value: new DateTime(2024, 2, 22, 23, 5, 38, 918, DateTimeKind.Utc).AddTicks(4197));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("e8de9c11-44b5-42d6-baee-0f04f3638047"),
                column: "CreatedAt",
                value: new DateTime(2024, 2, 22, 23, 5, 38, 918, DateTimeKind.Utc).AddTicks(4194));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("d33027fc-4b48-4b54-a77d-8931d270257c"),
                column: "CreatedAt",
                value: new DateTime(2024, 2, 22, 23, 5, 38, 918, DateTimeKind.Utc).AddTicks(5203));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("f9554ddd-897a-4c7e-8840-e89d1075c053"),
                column: "CreatedAt",
                value: new DateTime(2024, 2, 22, 23, 5, 38, 918, DateTimeKind.Utc).AddTicks(5205));

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("0ca39402-5d58-42e4-b354-6d66723b449e"),
                column: "CreatedAt",
                value: new DateTime(2024, 2, 22, 23, 5, 38, 918, DateTimeKind.Utc).AddTicks(5869));

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("c004c26e-3be6-4581-8989-a4478e8065e2"),
                column: "CreatedAt",
                value: new DateTime(2024, 2, 22, 23, 5, 38, 918, DateTimeKind.Utc).AddTicks(5871));

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("e02186a7-4b2e-4206-a076-2ccdd41fc4fb"),
                column: "CreatedAt",
                value: new DateTime(2024, 2, 22, 23, 5, 38, 918, DateTimeKind.Utc).AddTicks(5867));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "8a8670b4-afb9-4734-a596-ffc3d2156e50",
                columns: new[] { "AvatarLink", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "f44a0811-ca61-4444-bcdd-6cfaf8c37f3d", "AQAAAAIAAYagAAAAEAvktL9QlM4shRe/rmv+WG06shzp/RYCti/aZpmtCCJTqtWIotLoMg4WR1PeA3tXxw==", "10767935-0e4f-4f9b-bf31-458a0e29bafe" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarLink",
                table: "User");

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("3e7688d0-be96-4e3c-9450-432710b31c7b"),
                column: "CreatedAt",
                value: new DateTime(2024, 2, 8, 17, 53, 36, 343, DateTimeKind.Utc).AddTicks(5477));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("7a975ea2-ee10-45b7-85d7-d5c646e828fd"),
                column: "CreatedAt",
                value: new DateTime(2024, 2, 8, 17, 53, 36, 343, DateTimeKind.Utc).AddTicks(5474));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("e8de9c11-44b5-42d6-baee-0f04f3638047"),
                column: "CreatedAt",
                value: new DateTime(2024, 2, 8, 17, 53, 36, 343, DateTimeKind.Utc).AddTicks(5471));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("d33027fc-4b48-4b54-a77d-8931d270257c"),
                column: "CreatedAt",
                value: new DateTime(2024, 2, 8, 17, 53, 36, 343, DateTimeKind.Utc).AddTicks(6458));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("f9554ddd-897a-4c7e-8840-e89d1075c053"),
                column: "CreatedAt",
                value: new DateTime(2024, 2, 8, 17, 53, 36, 343, DateTimeKind.Utc).AddTicks(6460));

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("0ca39402-5d58-42e4-b354-6d66723b449e"),
                column: "CreatedAt",
                value: new DateTime(2024, 2, 8, 17, 53, 36, 343, DateTimeKind.Utc).AddTicks(7049));

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("c004c26e-3be6-4581-8989-a4478e8065e2"),
                column: "CreatedAt",
                value: new DateTime(2024, 2, 8, 17, 53, 36, 343, DateTimeKind.Utc).AddTicks(7051));

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("e02186a7-4b2e-4206-a076-2ccdd41fc4fb"),
                column: "CreatedAt",
                value: new DateTime(2024, 2, 8, 17, 53, 36, 343, DateTimeKind.Utc).AddTicks(7047));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "8a8670b4-afb9-4734-a596-ffc3d2156e50",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c38388f4-5449-4aa9-af72-99860932d9e5", "AQAAAAIAAYagAAAAEGcuOl4g65Ih5zlz7gmoBELSi+uU7tB0iidMyN51cNCMOXpAug21yL8uwovO9PBbrA==", "adf4d573-e950-4b00-837e-9bc03348b327" });
        }
    }
}
