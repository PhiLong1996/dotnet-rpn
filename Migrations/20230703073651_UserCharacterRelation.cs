using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_rpn.Migrations
{
    /// <inheritdoc />
    public partial class UserCharacterRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_UsersId",
                table: "Characters",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Users_UsersId",
                table: "Characters",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Users_UsersId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_UsersId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Characters");
        }
    }
}
