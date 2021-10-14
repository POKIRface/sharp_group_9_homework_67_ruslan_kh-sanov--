using Microsoft.EntityFrameworkCore.Migrations;

namespace task1.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countriess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Capital = table.Column<string>(type: "TEXT", nullable: true),
                    Numberpeople = table.Column<string>(type: "TEXT", nullable: true),
                    Territory = table.Column<string>(type: "TEXT", nullable: true),
                    VVP = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countriess", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countriess");
        }
    }
}
