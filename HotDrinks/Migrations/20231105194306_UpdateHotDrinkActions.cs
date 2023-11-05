using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotDrinks.Migrations
{
    /// <inheritdoc />
    public partial class UpdateHotDrinkActions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HotDrinkActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotDrinkActions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HotDrinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotDrinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HotDrinkHotDrinkAction",
                columns: table => new
                {
                    ActionsId = table.Column<int>(type: "INTEGER", nullable: false),
                    DrinksId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotDrinkHotDrinkAction", x => new { x.ActionsId, x.DrinksId });
                    table.ForeignKey(
                        name: "FK_HotDrinkHotDrinkAction_HotDrinkActions_ActionsId",
                        column: x => x.ActionsId,
                        principalTable: "HotDrinkActions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotDrinkHotDrinkAction_HotDrinks_DrinksId",
                        column: x => x.DrinksId,
                        principalTable: "HotDrinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotDrinkActions_Name",
                table: "HotDrinkActions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HotDrinkHotDrinkAction_DrinksId",
                table: "HotDrinkHotDrinkAction",
                column: "DrinksId");

            migrationBuilder.CreateIndex(
                name: "IX_HotDrinks_Name",
                table: "HotDrinks",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotDrinkHotDrinkAction");

            migrationBuilder.DropTable(
                name: "HotDrinkActions");

            migrationBuilder.DropTable(
                name: "HotDrinks");
        }
    }
}
