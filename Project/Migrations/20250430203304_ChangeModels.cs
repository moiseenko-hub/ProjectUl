using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations
{
    /// <inheritdoc />
    public partial class ChangeModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_Types_TypeDataId",
                table: "Places");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Places_PlaceDataId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_UserDataId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_PlaceDataId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Places_TypeDataId",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "PlaceDataId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "TypeDataId",
                table: "Places");

            migrationBuilder.RenameColumn(
                name: "UserDataId",
                table: "Reviews",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Reviews",
                newName: "PlaceId");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Reviews",
                newName: "Text");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_UserDataId",
                table: "Reviews",
                newName: "IX_Reviews_UserId");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Places",
                newName: "ShortDescription");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Places",
                newName: "FullDescription");

            migrationBuilder.CreateTable(
                name: "PlaceDataTypeData",
                columns: table => new
                {
                    PlacesId = table.Column<int>(type: "int", nullable: false),
                    TypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceDataTypeData", x => new { x.PlacesId, x.TypesId });
                    table.ForeignKey(
                        name: "FK_PlaceDataTypeData_Places_PlacesId",
                        column: x => x.PlacesId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaceDataTypeData_Types_TypesId",
                        column: x => x.TypesId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_PlaceId",
                table: "Reviews",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceDataTypeData_TypesId",
                table: "PlaceDataTypeData",
                column: "TypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Places_PlaceId",
                table: "Reviews",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_UserId",
                table: "Reviews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Places_PlaceId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_UserId",
                table: "Reviews");

            migrationBuilder.DropTable(
                name: "PlaceDataTypeData");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_PlaceId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Reviews",
                newName: "UserDataId");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "Reviews",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "PlaceId",
                table: "Reviews",
                newName: "Rating");

            migrationBuilder.RenameIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                newName: "IX_Reviews_UserDataId");

            migrationBuilder.RenameColumn(
                name: "ShortDescription",
                table: "Places",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "FullDescription",
                table: "Places",
                newName: "Description");

            migrationBuilder.AddColumn<int>(
                name: "PlaceDataId",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeDataId",
                table: "Places",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_PlaceDataId",
                table: "Reviews",
                column: "PlaceDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Places_TypeDataId",
                table: "Places",
                column: "TypeDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Types_TypeDataId",
                table: "Places",
                column: "TypeDataId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Places_PlaceDataId",
                table: "Reviews",
                column: "PlaceDataId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_UserDataId",
                table: "Reviews",
                column: "UserDataId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
