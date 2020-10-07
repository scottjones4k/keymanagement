using Microsoft.EntityFrameworkCore.Migrations;

namespace KeyManagement.Repository.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KeyEvents",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    KeyId = table.Column<string>(maxLength: 50, nullable: true),
                    KeySetId = table.Column<string>(maxLength: 50, nullable: true),
                    KeyEventType = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Assignee = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Keys",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    KeySetId = table.Column<string>(maxLength: 50, nullable: true),
                    KeyType = table.Column<int>(nullable: false),
                    AssignedTo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KeySets",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeySets", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeyEvents");

            migrationBuilder.DropTable(
                name: "Keys");

            migrationBuilder.DropTable(
                name: "KeySets");
        }
    }
}
