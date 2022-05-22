using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KnowledgeSharing.Persistence.EFCoreFluentAPI.Migrations
{
    public partial class addcolumntousertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                schema: "user",
                table: "user",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                schema: "user",
                table: "user");
        }
    }
}
