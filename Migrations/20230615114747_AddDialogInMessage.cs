using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chat.Migrations
{
    /// <inheritdoc />
    public partial class AddDialogInMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DialogId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_DialogId",
                table: "Messages",
                column: "DialogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_StartedDialogs_DialogId",
                table: "Messages",
                column: "DialogId",
                principalTable: "StartedDialogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_StartedDialogs_DialogId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_DialogId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "DialogId",
                table: "Messages");
        }
    }
}
