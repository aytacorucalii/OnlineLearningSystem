using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineLearning.DAL.Migrations
{
    /// <inheritdoc />
    public partial class MigrationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 8, 17, 24, 18, 302, DateTimeKind.Utc).AddTicks(5475),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 8, 17, 15, 10, 411, DateTimeKind.Utc).AddTicks(960));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "588dcd48-e306-4451-8f08-727f336e4a0b", "AQAAAAIAAYagAAAAEEeap81URO+1T/W5Pb+WnQJYZoe9dOs+9LeN1l7dRK6A0IMYRy6zy9FwRD9h5gcrhQ==", "a9b6af10-df25-4635-b05d-0b95de7b469d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 8, 17, 15, 10, 411, DateTimeKind.Utc).AddTicks(960),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 8, 17, 24, 18, 302, DateTimeKind.Utc).AddTicks(5475));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01d8cf9f-7a63-463e-99c5-cb2ba94e577a", "AQAAAAIAAYagAAAAENJUnMMmuMc/BKN84KY3ZaplrUUizcNfGOwYdcM1PAE4+PRW9UYiltn7NEnUc1t2Pw==", "12657e8a-b9e9-4b7b-b3ec-6a12766b5529" });
        }
    }
}
