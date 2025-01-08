using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConferenceManager.Migrations
{
    /// <inheritdoc />
    public partial class AddJunctionTableConnections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Speakers_EventId",
                table: "Speakers",
                column: "EventId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attendees_EventId",
                table: "Attendees",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendees_Events_EventId",
                table: "Attendees",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Speakers_Events_EventId",
                table: "Speakers",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendees_Events_EventId",
                table: "Attendees");

            migrationBuilder.DropForeignKey(
                name: "FK_Speakers_Events_EventId",
                table: "Speakers");

            migrationBuilder.DropIndex(
                name: "IX_Speakers_EventId",
                table: "Speakers");

            migrationBuilder.DropIndex(
                name: "IX_Attendees_EventId",
                table: "Attendees");
        }
    }
}
