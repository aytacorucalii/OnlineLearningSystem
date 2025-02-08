using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineLearning.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RelationChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 8, 17, 15, 10, 411, DateTimeKind.Utc).AddTicks(960),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 8, 16, 43, 45, 407, DateTimeKind.Utc).AddTicks(8269));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01d8cf9f-7a63-463e-99c5-cb2ba94e577a", "AQAAAAIAAYagAAAAENJUnMMmuMc/BKN84KY3ZaplrUUizcNfGOwYdcM1PAE4+PRW9UYiltn7NEnUc1t2Pw==", "12657e8a-b9e9-4b7b-b3ec-6a12766b5529" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 8, 16, 43, 45, 407, DateTimeKind.Utc).AddTicks(8269),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 8, 17, 15, 10, 411, DateTimeKind.Utc).AddTicks(960));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "73f75f70-d587-4cc8-b1c4-08175e18821d", "AQAAAAIAAYagAAAAEMMinLTwz597svRXJxgjsoKUVBgs6SNE0xL9E9ZWFvclcP50Ud5hoUG6w5dO9stXRg==", "2ff2e7e5-9f91-4f79-b89e-ce9d6f56a56d" });
        }
    }
}
