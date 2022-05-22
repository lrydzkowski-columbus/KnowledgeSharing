using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KnowledgeSharing.Persistence.EFCoreFluentAPI.Migrations
{
    public partial class correctcolumnname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FinalizedAt",
                schema: "store",
                table: "order",
                newName: "finalized_at");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "finalized_at",
                schema: "store",
                table: "order",
                newName: "FinalizedAt");
        }
    }
}
