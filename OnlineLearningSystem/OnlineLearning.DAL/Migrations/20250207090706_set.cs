using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineLearning.DAL.Migrations
{
    /// <inheritdoc />
    public partial class set : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ce28d7ca-9007-4eb9-893f-cc140348c40f", "AQAAAAIAAYagAAAAEDe1PvysfXiubiN5VOl1r4pqIZ0nLwM3jcQnUz35yNEgK6OJDeJv6xSRQr+wW0S1rA==", "d551ff25-f1de-45fc-b56c-dbd35d01a323" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3553015a-45ba-4867-8e28-b63ed2f0ec40", "AQAAAAIAAYagAAAAEI0feud+JWl9Hpggaf9u5e/hzkhBYT+/lqf/8C7+3WfYyVuVYVELUzrOap6nK6VmUA==", "8716f9d0-e11d-4165-ae3b-8a5cb2a17be4" });
        }
    }
}
