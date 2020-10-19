using Microsoft.EntityFrameworkCore.Migrations;

namespace Automobiliu_skelbimu_portalas.Migrations
{
    public partial class AddedImagesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BodyTypeVM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyTypeVM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ColorVM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorVM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DamageVM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DamageVM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuelTypeVM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelTypeVM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GearBoxVM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GearBoxVM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MakeVM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MakeVM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModelVM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    MakeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelVM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelVM_MakeVM_MakeId",
                        column: x => x.MakeId,
                        principalTable: "MakeVM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdVM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarMakeId = table.Column<int>(nullable: false),
                    CarModelId = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    FuelTypeId = table.Column<int>(nullable: false),
                    BodyTypeId = table.Column<int>(nullable: false),
                    EngineCapacity = table.Column<int>(nullable: false),
                    Kilometrage = table.Column<int>(nullable: false),
                    DamageId = table.Column<int>(nullable: false),
                    ColorId = table.Column<int>(nullable: false),
                    NumberOfSeats = table.Column<int>(nullable: false),
                    GearBoxId = table.Column<int>(nullable: false),
                    SteeringWheel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdVM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdVM_BodyTypeVM_BodyTypeId",
                        column: x => x.BodyTypeId,
                        principalTable: "BodyTypeVM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdVM_MakeVM_CarMakeId",
                        column: x => x.CarMakeId,
                        principalTable: "MakeVM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdVM_ModelVM_CarModelId",
                        column: x => x.CarModelId,
                        principalTable: "ModelVM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdVM_ColorVM_ColorId",
                        column: x => x.ColorId,
                        principalTable: "ColorVM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdVM_DamageVM_DamageId",
                        column: x => x.DamageId,
                        principalTable: "DamageVM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdVM_FuelTypeVM_FuelTypeId",
                        column: x => x.FuelTypeId,
                        principalTable: "FuelTypeVM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdVM_GearBoxVM_GearBoxId",
                        column: x => x.GearBoxId,
                        principalTable: "GearBoxVM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdVM_BodyTypeId",
                table: "AdVM",
                column: "BodyTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AdVM_CarMakeId",
                table: "AdVM",
                column: "CarMakeId");

            migrationBuilder.CreateIndex(
                name: "IX_AdVM_CarModelId",
                table: "AdVM",
                column: "CarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_AdVM_ColorId",
                table: "AdVM",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_AdVM_DamageId",
                table: "AdVM",
                column: "DamageId");

            migrationBuilder.CreateIndex(
                name: "IX_AdVM_FuelTypeId",
                table: "AdVM",
                column: "FuelTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AdVM_GearBoxId",
                table: "AdVM",
                column: "GearBoxId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelVM_MakeId",
                table: "ModelVM",
                column: "MakeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdVM");

            migrationBuilder.DropTable(
                name: "BodyTypeVM");

            migrationBuilder.DropTable(
                name: "ModelVM");

            migrationBuilder.DropTable(
                name: "ColorVM");

            migrationBuilder.DropTable(
                name: "DamageVM");

            migrationBuilder.DropTable(
                name: "FuelTypeVM");

            migrationBuilder.DropTable(
                name: "GearBoxVM");

            migrationBuilder.DropTable(
                name: "MakeVM");
        }
    }
}
