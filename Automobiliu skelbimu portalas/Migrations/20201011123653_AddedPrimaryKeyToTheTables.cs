using Microsoft.EntityFrameworkCore.Migrations;

namespace Automobiliu_skelbimu_portalas.Migrations
{
    public partial class AddedPrimaryKeyToTheTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_Ads_AdId",
                table: "Models");

            migrationBuilder.DropIndex(
                name: "IX_Models_AdId",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "AdId",
                table: "Models");

            migrationBuilder.AddColumn<int>(
                name: "AdId",
                table: "SearchesList",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SearchesList_AdId",
                table: "SearchesList",
                column: "AdId");

            migrationBuilder.CreateIndex(
                name: "IX_Ads_ModelId",
                table: "Ads",
                column: "ModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ads_Models_ModelId",
                table: "Ads",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SearchesList_Ads_AdId",
                table: "SearchesList",
                column: "AdId",
                principalTable: "Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ads_Models_ModelId",
                table: "Ads");

            migrationBuilder.DropForeignKey(
                name: "FK_SearchesList_Ads_AdId",
                table: "SearchesList");

            migrationBuilder.DropIndex(
                name: "IX_SearchesList_AdId",
                table: "SearchesList");

            migrationBuilder.DropIndex(
                name: "IX_Ads_ModelId",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "AdId",
                table: "SearchesList");

            migrationBuilder.AddColumn<int>(
                name: "AdId",
                table: "Models",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Models_AdId",
                table: "Models",
                column: "AdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Ads_AdId",
                table: "Models",
                column: "AdId",
                principalTable: "Ads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
