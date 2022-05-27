using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KnowledgeSharing.Persistence.EFCoreFluentAPI.Migrations
{
    public partial class add_image_url_col_to_product_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "image_url",
                schema: "store",
                table: "product",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image_url",
                schema: "store",
                table: "product");
        }
    }
}
