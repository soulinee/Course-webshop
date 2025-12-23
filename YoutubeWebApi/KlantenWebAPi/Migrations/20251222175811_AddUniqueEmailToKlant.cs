using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KlantenWebAPi.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueEmailToKlant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Klanten_Id",
                table: "Klanten");

            migrationBuilder.CreateIndex(
                name: "IX_Klanten_Emailadres",
                table: "Klanten",
                column: "Emailadres",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Klanten_Emailadres",
                table: "Klanten");

            migrationBuilder.CreateIndex(
                name: "IX_Klanten_Id",
                table: "Klanten",
                column: "Id",
                unique: true);
        }
    }
}
