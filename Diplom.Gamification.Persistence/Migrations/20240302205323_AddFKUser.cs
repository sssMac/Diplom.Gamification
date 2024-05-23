using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Diplom.Gamification.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddFKUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Forums_CourseId",
                table: "Forums",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Forums_UserId",
                table: "Forums",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_UserId",
                table: "Achievements",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Achievements_User_UserId",
                table: "Achievements",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Forums_Courses_CourseId",
                table: "Forums",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Forums_User_UserId",
                table: "Forums",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_User_UserId",
                table: "Messages",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achievements_User_UserId",
                table: "Achievements");

            migrationBuilder.DropForeignKey(
                name: "FK_Forums_Courses_CourseId",
                table: "Forums");

            migrationBuilder.DropForeignKey(
                name: "FK_Forums_User_UserId",
                table: "Forums");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_User_UserId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_UserId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Forums_CourseId",
                table: "Forums");

            migrationBuilder.DropIndex(
                name: "IX_Forums_UserId",
                table: "Forums");

            migrationBuilder.DropIndex(
                name: "IX_Achievements_UserId",
                table: "Achievements");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f44a0811-ca61-4444-bcdd-6cfaf8c37f3d", "AQAAAAIAAYagAAAAEAvktL9QlM4shRe/rmv+WG06shzp/RYCti/aZpmtCCJTqtWIotLoMg4WR1PeA3tXxw==", "10767935-0e4f-4f9b-bf31-458a0e29bafe" });
        }
    }
}
