using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetManager.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Device",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchaseDate = table.Column<DateOnly>(type: "date", nullable: false),
                    PriceCrowns = table.Column<int>(type: "int", nullable: false),
                    PriceEuros = table.Column<float>(type: "real", nullable: false),
                    PriceDollars = table.Column<float>(type: "real", nullable: false),
                    PricePounds = table.Column<float>(type: "real", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Office = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Device");
        }
    }
}
