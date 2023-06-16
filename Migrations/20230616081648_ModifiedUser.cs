using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chat.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_StartedDialogs_DialogId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_StartedDialogs_Users_FirstUserId",
                table: "StartedDialogs");

            migrationBuilder.DropForeignKey(
                name: "FK_StartedDialogs_Users_SecondUserId",
                table: "StartedDialogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_StartedDialogs_FirstUserId",
                table: "StartedDialogs");

            migrationBuilder.DropIndex(
                name: "IX_StartedDialogs_SecondUserId",
                table: "StartedDialogs");

            migrationBuilder.DropIndex(
                name: "IX_Messages_DialogId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstUserId",
                table: "StartedDialogs");

            migrationBuilder.DropColumn(
                name: "SecondUserId",
                table: "StartedDialogs");

            migrationBuilder.DropColumn(
                name: "DialogId",
                table: "Messages");

            migrationBuilder.AlterColumn<string>(
                name: "Tag",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Tag");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Tag",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "FirstUserId",
                table: "StartedDialogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SecondUserId",
                table: "StartedDialogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DialogId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_StartedDialogs_FirstUserId",
                table: "StartedDialogs",
                column: "FirstUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StartedDialogs_SecondUserId",
                table: "StartedDialogs",
                column: "SecondUserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_StartedDialogs_Users_FirstUserId",
                table: "StartedDialogs",
                column: "FirstUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StartedDialogs_Users_SecondUserId",
                table: "StartedDialogs",
                column: "SecondUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
