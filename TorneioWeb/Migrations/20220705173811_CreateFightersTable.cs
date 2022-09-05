using Microsoft.EntityFrameworkCore.Migrations;

namespace TorneioWeb.Migrations
{
    public partial class CreateFightersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fighters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    QtyMartialArts = table.Column<int>(type: "int", nullable: false),
                    QtyFights = table.Column<int>(type: "int", nullable: false),
                    QtyDefeats = table.Column<int>(type: "int", nullable: false),
                    QtyVictories = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fighters", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fighters");
        }
    }
}
