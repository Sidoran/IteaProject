using Microsoft.EntityFrameworkCore.Migrations;

namespace IteaProject.Migrations
{
    public partial class FixRunBookTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RunbookOreder",
                table: "RunTasks",
                newName: "RunbookOrder");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RunbookOrder",
                table: "RunTasks",
                newName: "RunbookOreder");
        }
    }
}
