using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mandatum.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Term = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BoardRecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Boards_BoardRecordId",
                        column: x => x.BoardRecordId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoardRecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Boards_BoardRecordId",
                        column: x => x.BoardRecordId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Boards",
                column: "Id",
                value: new Guid("96cc1e82-b59f-43cf-ab61-244585f2c662"));

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardRecordId", "Description", "Status", "Term", "Name" },
                values: new object[] { new Guid("578181d8-e7bf-4a38-8cde-c9671e5efe58"), null, "1", 1, new DateTime(2021, 11, 29, 14, 37, 10, 870, DateTimeKind.Local).AddTicks(8915), "1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BoardRecordId", "Email", "Password" },
                values: new object[] { new Guid("62486d13-c455-43f8-8ea6-c1b44c0804a8"), null, "1@gmail.com", "1" });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardRecordId",
                table: "Tasks",
                column: "BoardRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_BoardRecordId",
                table: "Users",
                column: "BoardRecordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Boards");
        }
    }
}
