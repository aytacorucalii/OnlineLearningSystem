using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineLearning.DAL.Migrations
{
    /// <inheritdoc />
    public partial class VMAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 8, 17, 52, 26, 547, DateTimeKind.Utc).AddTicks(9071),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 8, 17, 24, 18, 302, DateTimeKind.Utc).AddTicks(5475));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "168981ca-8d71-4351-ad59-1168e1669e22", "AQAAAAIAAYagAAAAECAXBXYQTiXn1YDdEvehF/mRrtaM2M+MA+d9lJ85ESQEVp9/4gc/RzMNppn80vhV9A==", "d998e5f3-2836-4b12-9c21-82e165d8dd03" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 8, 17, 24, 18, 302, DateTimeKind.Utc).AddTicks(5475),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 8, 17, 52, 26, 547, DateTimeKind.Utc).AddTicks(9071));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "588dcd48-e306-4451-8f08-727f336e4a0b", "AQAAAAIAAYagAAAAEEeap81URO+1T/W5Pb+WnQJYZoe9dOs+9LeN1l7dRK6A0IMYRy6zy9FwRD9h5gcrhQ==", "a9b6af10-df25-4635-b05d-0b95de7b469d" });
        }
    }
}
