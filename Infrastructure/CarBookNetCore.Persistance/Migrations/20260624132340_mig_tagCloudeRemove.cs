using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBookNetCore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_tagCloudeRemove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TagCloudes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TagCloudes",
                columns: table => new
                {
                    TagCloudeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagCloudes", x => x.TagCloudeId);
                    table.ForeignKey(
                        name: "FK_TagCloudes_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "BlogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TagCloudes_BlogId",
                table: "TagCloudes",
                column: "BlogId");
        }
    }
}
