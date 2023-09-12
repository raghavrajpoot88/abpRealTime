using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chatterBox.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReceiverId1",
                table: "messageInfo",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "messageInfo",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_messageInfo_ReceiverId1",
                table: "messageInfo",
                column: "ReceiverId1");

            migrationBuilder.CreateIndex(
                name: "IX_messageInfo_UserId",
                table: "messageInfo",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_messageInfo_IdentityUser_ReceiverId1",
                table: "messageInfo",
                column: "ReceiverId1",
                principalTable: "IdentityUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_messageInfo_IdentityUser_UserId",
                table: "messageInfo",
                column: "UserId",
                principalTable: "IdentityUser",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_messageInfo_IdentityUser_ReceiverId1",
                table: "messageInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_messageInfo_IdentityUser_UserId",
                table: "messageInfo");

            migrationBuilder.DropTable(
                name: "IdentityUser");

            migrationBuilder.DropIndex(
                name: "IX_messageInfo_ReceiverId1",
                table: "messageInfo");

            migrationBuilder.DropIndex(
                name: "IX_messageInfo_UserId",
                table: "messageInfo");

            migrationBuilder.DropColumn(
                name: "ReceiverId1",
                table: "messageInfo");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "messageInfo");
        }
    }
}
