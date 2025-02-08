using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineLearning.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ForeginKeyNoAction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 8, 16, 32, 42, 347, DateTimeKind.Utc).AddTicks(4455),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 8, 16, 31, 25, 417, DateTimeKind.Utc).AddTicks(8098));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9be0c322-f4f3-405e-86c4-f59cb53bb253", "AQAAAAIAAYagAAAAEDVqbgZWyzJxHL+0ZqJdKhzo+BLgnBad+5g9pUbTzIMOqMnFSbXgfQ1fydrE3T0meQ==", "50d6ea4c-3b5f-4941-b9e0-968cd7a5994a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 8, 16, 31, 25, 417, DateTimeKind.Utc).AddTicks(8098),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 8, 16, 32, 42, 347, DateTimeKind.Utc).AddTicks(4455));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a49bff59-747e-43db-b0e3-bb9379b6294f", "AQAAAAIAAYagAAAAEMS/n7FdrvOxgbyX3UPf9qd3d+AxnEUzOKv/pyMB9c1r2WMxyXSCgaMCSa/HfVgW9Q==", "edb1489d-f037-4f88-b133-371038cb5452" });
        }
    }
}
