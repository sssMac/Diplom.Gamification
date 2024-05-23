using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diplom.Gamification.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddLearningProgress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LearningProgress",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LessonId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    CompletionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningProgress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LearningProgress_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LearningProgress_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_LearningProgress_LessonId",
                table: "LearningProgress",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_LearningProgress_UserId",
                table: "LearningProgress",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LearningProgress");

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("3e7688d0-be96-4e3c-9450-432710b31c7b"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 20, 53, 22, 753, DateTimeKind.Utc).AddTicks(5137));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("7a975ea2-ee10-45b7-85d7-d5c646e828fd"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 20, 53, 22, 753, DateTimeKind.Utc).AddTicks(5135));

            migrationBuilder.UpdateData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("e8de9c11-44b5-42d6-baee-0f04f3638047"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 20, 53, 22, 753, DateTimeKind.Utc).AddTicks(5132));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("d33027fc-4b48-4b54-a77d-8931d270257c"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 20, 53, 22, 753, DateTimeKind.Utc).AddTicks(6034));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("f9554ddd-897a-4c7e-8840-e89d1075c053"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 20, 53, 22, 753, DateTimeKind.Utc).AddTicks(6037));

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("0ca39402-5d58-42e4-b354-6d66723b449e"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 20, 53, 22, 753, DateTimeKind.Utc).AddTicks(6555));

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("c004c26e-3be6-4581-8989-a4478e8065e2"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 20, 53, 22, 753, DateTimeKind.Utc).AddTicks(6557));

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("e02186a7-4b2e-4206-a076-2ccdd41fc4fb"),
                column: "CreatedAt",
                value: new DateTime(2024, 3, 2, 20, 53, 22, 753, DateTimeKind.Utc).AddTicks(6553));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "8a8670b4-afb9-4734-a596-ffc3d2156e50",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cec91ee6-ea68-44b5-aec4-c65ddd91c508", "AQAAAAIAAYagAAAAEDrnIKwtumrk/jsWN+1N3F8rfc/Rw68nzNMkXoMajxZvU6JsstArVvJgsKB9NGlraw==", "591fdb84-fba0-4b43-89a3-f5d0de9f7315" });
        }
    }
}
