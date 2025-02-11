using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineLearning.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Payment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 9, 20, 36, 33, 452, DateTimeKind.Utc).AddTicks(3289),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 9, 12, 50, 6, 110, DateTimeKind.Utc).AddTicks(6304));

            migrationBuilder.CreateTable(
                name: "PaymentResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsSuccess = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ErrorMessage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsSuccessful = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4c125bb8-4c90-45d2-a50d-076d2284db15", "AQAAAAIAAYagAAAAEMRTAynBsSNLwxNZqGbGnAbnxMvhpzIOOs1rGz2JZEKsjhFEWRg9NKw2onGkrz3AkQ==", "af210070-9d3d-49e3-abfa-5e8d4d4248ea" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentResults");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 9, 12, 50, 6, 110, DateTimeKind.Utc).AddTicks(6304),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 9, 20, 36, 33, 452, DateTimeKind.Utc).AddTicks(3289));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "280fb379-f744-4827-a873-50ad642f1a18", "AQAAAAIAAYagAAAAEBNvnsrWWrKBEZI+ag8dW1hhhkUNZCRGGHzSWi4Y99FfpD+Lwsf0NWvpzEOsOm/zDQ==", "4fb9a6cb-45a4-450e-b7de-cc1334c0cf0b" });
        }
    }
}
