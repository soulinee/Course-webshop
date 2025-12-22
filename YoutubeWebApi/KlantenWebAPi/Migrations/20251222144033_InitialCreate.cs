using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KlantenWebAPi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klanten",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VolledigeNaam = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Emailadres = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Wachtwoord = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klanten", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Klanten");
        }
    }
}
