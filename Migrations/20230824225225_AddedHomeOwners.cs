using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeOwnersApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedHomeOwners : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HomeOwners",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Site = table.Column<string>(type: "nvarchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeOwners", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomeOwners");
        }
    }
}
