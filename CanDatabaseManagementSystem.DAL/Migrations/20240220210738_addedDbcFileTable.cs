using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CanDatabaseManagementSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addedDbcFileTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MessageId",
                table: "Signals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DbcFileId",
                table: "NetworkNodes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DbcFileId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DbcFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbcFiles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Signals_MessageId",
                table: "Signals",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_NetworkNodes_DbcFileId",
                table: "NetworkNodes",
                column: "DbcFileId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_DbcFileId",
                table: "Messages",
                column: "DbcFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_DbcFiles_DbcFileId",
                table: "Messages",
                column: "DbcFileId",
                principalTable: "DbcFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NetworkNodes_DbcFiles_DbcFileId",
                table: "NetworkNodes",
                column: "DbcFileId",
                principalTable: "DbcFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Signals_Messages_MessageId",
                table: "Signals",
                column: "MessageId",
                principalTable: "Messages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_DbcFiles_DbcFileId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_NetworkNodes_DbcFiles_DbcFileId",
                table: "NetworkNodes");

            migrationBuilder.DropForeignKey(
                name: "FK_Signals_Messages_MessageId",
                table: "Signals");

            migrationBuilder.DropTable(
                name: "DbcFiles");

            migrationBuilder.DropIndex(
                name: "IX_Signals_MessageId",
                table: "Signals");

            migrationBuilder.DropIndex(
                name: "IX_NetworkNodes_DbcFileId",
                table: "NetworkNodes");

            migrationBuilder.DropIndex(
                name: "IX_Messages_DbcFileId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "MessageId",
                table: "Signals");

            migrationBuilder.DropColumn(
                name: "DbcFileId",
                table: "NetworkNodes");

            migrationBuilder.DropColumn(
                name: "DbcFileId",
                table: "Messages");
        }
    }
}
