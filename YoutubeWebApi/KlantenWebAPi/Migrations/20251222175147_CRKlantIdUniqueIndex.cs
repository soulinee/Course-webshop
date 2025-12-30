using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KlantenWebAPi.Migrations
{
    /// <inheritdoc />
    public partial class CRKlantIdUniqueIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Klanten_Id",
                table: "Klanten",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Klanten_Id",
                table: "Klanten");
        }
    }
}
