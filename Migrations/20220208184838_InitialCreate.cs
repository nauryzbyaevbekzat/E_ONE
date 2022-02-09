using Microsoft.EntityFrameworkCore.Migrations;

namespace Eventum.One2.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "h_color",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    name = table.Column<string>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_h_color", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "car",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    brand_name = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    model_name = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    h_color_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_car", x => x.id);
                    table.ForeignKey(
                        name: "FK__car__h_color_id__38996AB5",
                        column: x => x.h_color_id,
                        principalTable: "h_color",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_car_h_color_id",
                table: "car",
                column: "h_color_id");

            migrationBuilder.InsertData(
            table: "h_color",
            columns: new[] { "id", "name" },
            values: new object[,]
            {
                { 1, "Black" } ,
                { 2, "Red" } ,
                { 3, "Pink" } ,
                { 4, "Blue" } ,
                { 5, "Yellow" }
            });
            migrationBuilder.InsertData(
            table: "car",
            columns: new[] { "id", "brand_name", "model_name", "h_color_id" },
            values: new object[,]
            {
                { 1, "Toyoto" , "Toyoto" , 1 } ,
                { 2, "Porshe" , "Porshe" , 2 } ,

            });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "car");

            migrationBuilder.DropTable(
                name: "h_color");
        }
    }
}
