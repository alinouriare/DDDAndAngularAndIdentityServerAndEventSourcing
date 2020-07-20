using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Migrator.Migrations.MiniProfilerDb
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MiniProfilerClientTimings",
                columns: table => new
                {
                    RowId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<Guid>(nullable: false),
                    MiniProfilerId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    Start = table.Column<decimal>(type: "decimal(9,3)", nullable: false),
                    Duration = table.Column<decimal>(type: "decimal(9,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiniProfilerClientTimings", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "MiniProfilers",
                columns: table => new
                {
                    RowId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<Guid>(nullable: false),
                    RootTimingId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    Started = table.Column<DateTime>(nullable: false),
                    DurationMilliseconds = table.Column<decimal>(type: "decimal(15,1)", nullable: false),
                    User = table.Column<string>(maxLength: 100, nullable: true),
                    HasUserViewed = table.Column<bool>(nullable: false),
                    MachineName = table.Column<string>(maxLength: 100, nullable: true),
                    CustomLinksJson = table.Column<string>(nullable: true),
                    ClientTimingsRedirectCount = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiniProfilers", x => x.RowId);
                });

            migrationBuilder.CreateTable(
                name: "MiniProfilerTimings",
                columns: table => new
                {
                    RowId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<Guid>(nullable: false),
                    MiniProfilerId = table.Column<Guid>(nullable: false),
                    ParentTimingId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    DurationMilliseconds = table.Column<decimal>(type: "decimal(15,3)", nullable: false),
                    StartMilliseconds = table.Column<decimal>(type: "decimal(15,3)", nullable: false),
                    IsRoot = table.Column<bool>(nullable: false),
                    Depth = table.Column<short>(nullable: false),
                    CustomTimingsJson = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MiniProfilerTimings", x => x.RowId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MiniProfilerClientTimings_Id",
                table: "MiniProfilerClientTimings",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MiniProfilerClientTimings_MiniProfilerId",
                table: "MiniProfilerClientTimings",
                column: "MiniProfilerId");

            migrationBuilder.CreateIndex(
                name: "IX_MiniProfilers_Id",
                table: "MiniProfilers",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MiniProfilers_User_HasUserViewed",
                table: "MiniProfilers",
                columns: new[] { "User", "HasUserViewed" })
                .Annotation("SqlServer:Include", new[] { "Id", "Started" });

            migrationBuilder.CreateIndex(
                name: "IX_MiniProfilerTimings_Id",
                table: "MiniProfilerTimings",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MiniProfilerTimings_MiniProfilerId",
                table: "MiniProfilerTimings",
                column: "MiniProfilerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MiniProfilerClientTimings");

            migrationBuilder.DropTable(
                name: "MiniProfilers");

            migrationBuilder.DropTable(
                name: "MiniProfilerTimings");
        }
    }
}
