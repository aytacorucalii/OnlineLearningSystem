using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineLearning.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Statistics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 11, 10, 41, 4, 213, DateTimeKind.Utc).AddTicks(9853),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 9, 20, 36, 33, 452, DateTimeKind.Utc).AddTicks(3289));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "45d60682-b174-4bf6-9557-851bed87cb2e", "AQAAAAIAAYagAAAAEDoaxYhfBd0E5KayljOOCgGka0sA8m0JxohYtKrCnAQ1WnoTkgMzxzf/5t93eM4M9Q==", "06d0625e-ce83-49c1-b974-0f5846112a7f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 9, 20, 36, 33, 452, DateTimeKind.Utc).AddTicks(3289),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 11, 10, 41, 4, 213, DateTimeKind.Utc).AddTicks(9853));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4c125bb8-4c90-45d2-a50d-076d2284db15", "AQAAAAIAAYagAAAAEMRTAynBsSNLwxNZqGbGnAbnxMvhpzIOOs1rGz2JZEKsjhFEWRg9NKw2onGkrz3AkQ==", "af210070-9d3d-49e3-abfa-5e8d4d4248ea" });
        }
    }
}
