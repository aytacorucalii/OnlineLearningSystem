using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineLearning.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ForeginKeyCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 8, 16, 31, 25, 417, DateTimeKind.Utc).AddTicks(8098),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 8, 16, 26, 58, 63, DateTimeKind.Utc).AddTicks(4005));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a49bff59-747e-43db-b0e3-bb9379b6294f", "AQAAAAIAAYagAAAAEMS/n7FdrvOxgbyX3UPf9qd3d+AxnEUzOKv/pyMB9c1r2WMxyXSCgaMCSa/HfVgW9Q==", "edb1489d-f037-4f88-b133-371038cb5452" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 8, 16, 26, 58, 63, DateTimeKind.Utc).AddTicks(4005),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 8, 16, 31, 25, 417, DateTimeKind.Utc).AddTicks(8098));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ee3939b-a67c-41c0-9450-04bbb731797b", "AQAAAAIAAYagAAAAEF8BoSBnWFgJhOISEEoD2I+yr9DJXr8SV61IMSuphQkhjbr43dwRkIO6Tt09yrs/WQ==", "b007af90-5e9e-4c2f-8942-55b460769444" });
        }
    }
}
