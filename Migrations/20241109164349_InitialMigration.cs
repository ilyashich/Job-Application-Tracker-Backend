using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JobApplicationTracker.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    Email = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    PasswordHash = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    LastName = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "JobApplications",
                columns: table => new
                {
                    JobApplicationId = table.Column<Guid>(type: "char(36)", nullable: false),
                    JobTitle = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    CompanyName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    JobApplicationStatus = table.Column<int>(type: "int", nullable: false),
                    ApplicationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    JobPostingUrl = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Notes = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplications", x => x.JobApplicationId);
                    table.ForeignKey(
                        name: "FK_JobApplications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName", "PasswordHash", "UserName" },
                values: new object[,]
                {
                    { new Guid("2762580d-543e-4bdf-89bb-f43cc329066e"), "illia@gmail.com", "Illia", "Yatskevich", "$2a$11$ChChWKfnCukVSfypFdXcsukH9o.VRHn74Gi0BpdrZL0.3AZXrUhmy", "illia" },
                    { new Guid("aaee2115-9e9c-4ac7-972d-8a82dbdb446a"), "alex@gmail.com", "Alex", "Huts", "$2a$11$aNprsJfhwKeeVpzYolfx8u4YuYnikDIgnkqkeeU3OtsKaIK55Jt1G", "alex" }
                });

            migrationBuilder.InsertData(
                table: "JobApplications",
                columns: new[] { "JobApplicationId", "ApplicationDate", "CompanyName", "JobApplicationStatus", "JobPostingUrl", "JobTitle", "Notes", "UserId" },
                values: new object[] { new Guid("369af106-4c08-437c-8130-1dffdedd0d4c"), new DateOnly(2024, 11, 9), "Samsung", 2, "https://www.samsung.com/careers", "Junior Java Developer", "Super cool job application", new Guid("2762580d-543e-4bdf-89bb-f43cc329066e") });

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_UserId",
                table: "JobApplications",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobApplications");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
