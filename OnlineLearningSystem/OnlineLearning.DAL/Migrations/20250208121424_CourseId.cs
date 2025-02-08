using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineLearning.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CourseId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Teachers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CourseId1",
                table: "Teachers",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 8, 12, 14, 24, 180, DateTimeKind.Utc).AddTicks(9652),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 8, 9, 29, 3, 574, DateTimeKind.Utc).AddTicks(1874));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "afb59220-ab71-4e7a-95bb-79320f6d0e59", "AQAAAAIAAYagAAAAEPXvPItj2SMHDWFNX+gDJMoHQWhmswhMD1pijtGmuB/QcNppXWRl7srz/+dX+VEWWA==", "6b968764-6b61-4fab-b8e1-92aa98f5d9fa" });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_CourseId1",
                table: "Teachers",
                column: "CourseId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Courses_CourseId1",
                table: "Teachers",
                column: "CourseId1",
                principalTable: "Courses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Courses_CourseId1",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_CourseId1",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "CourseId1",
                table: "Teachers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 8, 9, 29, 3, 574, DateTimeKind.Utc).AddTicks(1874),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 8, 12, 14, 24, 180, DateTimeKind.Utc).AddTicks(9652));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e843fc4d-6fa5-4c9a-bbba-79c0b911c4a8", "AQAAAAIAAYagAAAAEMSoZ8UTecuatAr2CT90fcTSLsF69noyihir9a4K6Sd62ZebluVEKEqWAC0XhplIdA==", "99bb23b1-3756-47a9-89db-d305786359a0" });
        }
    }
}
