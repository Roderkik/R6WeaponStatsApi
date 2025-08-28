using Microsoft.EntityFrameworkCore.Migrations;

namespace RainbowStatsAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Operators",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operators", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: true),
                    Action = table.Column<string>(type: "TEXT", nullable: true),
                    Slot = table.Column<string>(type: "TEXT", nullable: true),
                    Rpm = table.Column<int>(type: "INTEGER", nullable: false),
                    SerializedDamageRanges = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "OperatorWeapon",
                columns: table => new
                {
                    OperatorsName = table.Column<string>(type: "TEXT", nullable: false),
                    WeaponsName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatorWeapon", x => new { x.OperatorsName, x.WeaponsName });
                    table.ForeignKey(
                        name: "FK_OperatorWeapon_Operators_OperatorsName",
                        column: x => x.OperatorsName,
                        principalTable: "Operators",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperatorWeapon_Weapons_WeaponsName",
                        column: x => x.WeaponsName,
                        principalTable: "Weapons",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OperatorWeapon_WeaponsName",
                table: "OperatorWeapon",
                column: "WeaponsName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OperatorWeapon");

            migrationBuilder.DropTable(
                name: "Operators");

            migrationBuilder.DropTable(
                name: "Weapons");
        }
    }
}
