using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chat.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedUser2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Tag",
                table: "Users",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "FirstUserTag",
                table: "StartedDialogs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecondUserTag",
                table: "StartedDialogs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReceiverTag",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SenderTag",
                table: "Messages",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_StartedDialogs_FirstUserTag",
                table: "StartedDialogs",
                column: "FirstUserTag");

            migrationBuilder.CreateIndex(
                name: "IX_StartedDialogs_SecondUserTag",
                table: "StartedDialogs",
                column: "SecondUserTag");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ReceiverTag",
                table: "Messages",
                column: "ReceiverTag");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderTag",
                table: "Messages",
                column: "SenderTag");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_ReceiverTag",
                table: "Messages",
                column: "ReceiverTag",
                principalTable: "Users",
                principalColumn: "Tag",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_SenderTag",
                table: "Messages",
                column: "SenderTag",
                principalTable: "Users",
                principalColumn: "Tag",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_StartedDialogs_Users_FirstUserTag",
                table: "StartedDialogs",
                column: "FirstUserTag",
                principalTable: "Users",
                principalColumn: "Tag",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_StartedDialogs_Users_SecondUserTag",
                table: "StartedDialogs",
                column: "SecondUserTag",
                principalTable: "Users",
                principalColumn: "Tag",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_ReceiverTag",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Users_SenderTag",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_StartedDialogs_Users_FirstUserTag",
                table: "StartedDialogs");

            migrationBuilder.DropForeignKey(
                name: "FK_StartedDialogs_Users_SecondUserTag",
                table: "StartedDialogs");

            migrationBuilder.DropIndex(
                name: "IX_StartedDialogs_FirstUserTag",
                table: "StartedDialogs");

            migrationBuilder.DropIndex(
                name: "IX_StartedDialogs_SecondUserTag",
                table: "StartedDialogs");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ReceiverTag",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_SenderTag",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "FirstUserTag",
                table: "StartedDialogs");

            migrationBuilder.DropColumn(
                name: "SecondUserTag",
                table: "StartedDialogs");

            migrationBuilder.DropColumn(
                name: "ReceiverTag",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "SenderTag",
                table: "Messages");
        }
    }
}
