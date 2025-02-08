using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineLearning.DAL.Migrations
{
    /// <inheritdoc />
    public partial class StudentCourseAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 8, 16, 43, 45, 407, DateTimeKind.Utc).AddTicks(8269),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 8, 16, 32, 42, 347, DateTimeKind.Utc).AddTicks(4455));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "73f75f70-d587-4cc8-b1c4-08175e18821d", "AQAAAAIAAYagAAAAEMMinLTwz597svRXJxgjsoKUVBgs6SNE0xL9E9ZWFvclcP50Ud5hoUG6w5dO9stXRg==", "2ff2e7e5-9f91-4f79-b89e-ce9d6f56a56d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 8, 16, 32, 42, 347, DateTimeKind.Utc).AddTicks(4455),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 8, 16, 43, 45, 407, DateTimeKind.Utc).AddTicks(8269));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9be0c322-f4f3-405e-86c4-f59cb53bb253", "AQAAAAIAAYagAAAAEDVqbgZWyzJxHL+0ZqJdKhzo+BLgnBad+5g9pUbTzIMOqMnFSbXgfQ1fydrE3T0meQ==", "50d6ea4c-3b5f-4941-b9e0-968cd7a5994a" });
        }
    }
}
