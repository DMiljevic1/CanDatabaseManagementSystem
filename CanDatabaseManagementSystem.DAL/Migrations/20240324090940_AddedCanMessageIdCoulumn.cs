using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CanDatabaseManagementSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedCanMessageIdCoulumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CanMessageId",
                table: "Messages",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanMessageId",
                table: "Messages");
        }
    }
}
