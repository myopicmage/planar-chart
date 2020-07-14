using Microsoft.EntityFrameworkCore.Migrations;

namespace planar.server.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    locked = table.Column<bool>(type: "INTEGER", nullable: false),
                    revealed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PlaneId = table.Column<long>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "planes",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    locked = table.Column<bool>(type: "INTEGER", nullable: false),
                    revealed = table.Column<bool>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    ring = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_planes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "characters",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    locked = table.Column<bool>(type: "INTEGER", nullable: false),
                    revealed = table.Column<bool>(type: "INTEGER", nullable: false),
                    LocationId = table.Column<long>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    race = table.Column<string>(type: "TEXT", nullable: true),
                    description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_characters", x => x.id);
                    table.ForeignKey(
                        name: "FK_characters_locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "locations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "buffs",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    locked = table.Column<bool>(type: "INTEGER", nullable: false),
                    revealed = table.Column<bool>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    Locationid = table.Column<long>(type: "INTEGER", nullable: true),
                    Planeid = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buffs", x => x.id);
                    table.ForeignKey(
                        name: "FK_buffs_locations_Locationid",
                        column: x => x.Locationid,
                        principalTable: "locations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_buffs_planes_Planeid",
                        column: x => x.Planeid,
                        principalTable: "planes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "quests",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    locked = table.Column<bool>(type: "INTEGER", nullable: false),
                    revealed = table.Column<bool>(type: "INTEGER", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: true),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    giverid = table.Column<long>(type: "INTEGER", nullable: true),
                    status = table.Column<int>(type: "INTEGER", nullable: false),
                    reward = table.Column<string>(type: "TEXT", nullable: true),
                    Locationid = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quests", x => x.id);
                    table.ForeignKey(
                        name: "FK_quests_characters_giverid",
                        column: x => x.giverid,
                        principalTable: "characters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_quests_locations_Locationid",
                        column: x => x.Locationid,
                        principalTable: "locations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_buffs_Locationid",
                table: "buffs",
                column: "Locationid");

            migrationBuilder.CreateIndex(
                name: "IX_buffs_Planeid",
                table: "buffs",
                column: "Planeid");

            migrationBuilder.CreateIndex(
                name: "IX_characters_LocationId",
                table: "characters",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_quests_giverid",
                table: "quests",
                column: "giverid");

            migrationBuilder.CreateIndex(
                name: "IX_quests_Locationid",
                table: "quests",
                column: "Locationid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "buffs");

            migrationBuilder.DropTable(
                name: "quests");

            migrationBuilder.DropTable(
                name: "planes");

            migrationBuilder.DropTable(
                name: "characters");

            migrationBuilder.DropTable(
                name: "locations");
        }
    }
}
