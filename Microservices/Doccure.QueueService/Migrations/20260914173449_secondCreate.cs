using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Doccure.QueueService.Migrations
{
    /// <inheritdoc />
    public partial class secondCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QueueTime",
                table: "Queues",
                newName: "AppointmentTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AppointmentTime",
                table: "Queues",
                newName: "QueueTime");
        }
    }
}
