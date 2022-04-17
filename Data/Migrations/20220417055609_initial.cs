using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DemoModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemoModel", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DemoModel",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "DemoModel 1" });

            migrationBuilder.InsertData(
                table: "DemoModel",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "DemoModel 2" });

            migrationBuilder.InsertData(
                table: "DemoModel",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "DemoModel 3" });

            migrationBuilder.InsertData(
                table: "DemoModel",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "DemoModel 4" });

            migrationBuilder.InsertData(
                table: "DemoModel",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "DemoModel 6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DemoModel");
        }
    }
}
