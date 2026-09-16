using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniHub.Core.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(name: "core");

            migrationBuilder.CreateTable(
                name: "departments",
                schema: "core",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    faculty_id = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    short_title = table.Column<string>(type: "text", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.id);
                }
            );

            migrationBuilder.CreateTable(
                name: "faculties",
                schema: "core",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    short_title = table.Column<string>(type: "text", nullable: false),
                    number = table.Column<int>(type: "integer", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_faculties", x => x.id);
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "departments", schema: "core");

            migrationBuilder.DropTable(name: "faculties", schema: "core");
        }
    }
}
