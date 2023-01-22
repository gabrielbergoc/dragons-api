using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DragonsApp.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dragons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dragons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Histories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DragonId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Histories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Histories_Dragons_DragonId",
                        column: x => x.DragonId,
                        principalTable: "Dragons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Dragons",
                columns: new[] { "Id", "CreatedAt", "LastModifiedAt", "Name", "Title" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2023, 1, 21, 22, 40, 33, 141, DateTimeKind.Unspecified).AddTicks(2710), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 1, 21, 22, 40, 33, 141, DateTimeKind.Unspecified).AddTicks(2751), new TimeSpan(0, -3, 0, 0, 0)), "Toothless", "The Great One Without Teeth" },
                    { 2, new DateTimeOffset(new DateTime(2023, 1, 21, 22, 40, 33, 141, DateTimeKind.Unspecified).AddTicks(2755), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 1, 21, 22, 40, 33, 141, DateTimeKind.Unspecified).AddTicks(2757), new TimeSpan(0, -3, 0, 0, 0)), "Fafnir", "The Greedy One With Riches" },
                    { 3, new DateTimeOffset(new DateTime(2023, 1, 21, 22, 40, 33, 141, DateTimeKind.Unspecified).AddTicks(2760), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 1, 21, 22, 40, 33, 141, DateTimeKind.Unspecified).AddTicks(2761), new TimeSpan(0, -3, 0, 0, 0)), "Smaug", "The Desolation of Greediness" },
                    { 4, new DateTimeOffset(new DateTime(2023, 1, 21, 22, 40, 33, 141, DateTimeKind.Unspecified).AddTicks(2764), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 1, 21, 22, 40, 33, 141, DateTimeKind.Unspecified).AddTicks(2765), new TimeSpan(0, -3, 0, 0, 0)), "Rex", "The Great Friend" },
                    { 5, new DateTimeOffset(new DateTime(2023, 1, 21, 22, 40, 33, 141, DateTimeKind.Unspecified).AddTicks(2767), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 1, 21, 22, 40, 33, 141, DateTimeKind.Unspecified).AddTicks(2769), new TimeSpan(0, -3, 0, 0, 0)), "Adaman", "The Strong One" },
                    { 6, new DateTimeOffset(new DateTime(2023, 1, 21, 22, 40, 33, 141, DateTimeKind.Unspecified).AddTicks(2771), new TimeSpan(0, -3, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 1, 21, 22, 40, 33, 141, DateTimeKind.Unspecified).AddTicks(2773), new TimeSpan(0, -3, 0, 0, 0)), "Margoneth", "The One I Invented" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Histories_DragonId",
                table: "Histories",
                column: "DragonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Histories");

            migrationBuilder.DropTable(
                name: "Dragons");
        }
    }
}
