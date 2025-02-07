using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineLearning.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddNewPropForTeacher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "Teachers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3553015a-45ba-4867-8e28-b63ed2f0ec40", "AQAAAAIAAYagAAAAEI0feud+JWl9Hpggaf9u5e/hzkhBYT+/lqf/8C7+3WfYyVuVYVELUzrOap6nK6VmUA==", "8716f9d0-e11d-4165-ae3b-8a5cb2a17be4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Courses");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c523a8f-32c7-4c5b-99a1-d0f902241362", "AQAAAAIAAYagAAAAEBlzanDPl3F4FB2T+lIT6CWcqqOHEPvfa/fBGr7dRmUx5H4eV61+zxXQ9BLZPN2VSg==", "ef35b3e1-bf74-4f3a-b754-9e4d1d505581" });
        }
    }
}
