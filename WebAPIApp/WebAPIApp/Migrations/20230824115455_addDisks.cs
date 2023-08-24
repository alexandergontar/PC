using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPIApp.Migrations
{
    /// <inheritdoc />
    public partial class addDisks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disk_PCs_PCId",
                table: "Disk");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Disk",
                table: "Disk");

            migrationBuilder.RenameTable(
                name: "Disk",
                newName: "Disks");

            migrationBuilder.RenameIndex(
                name: "IX_Disk_PCId",
                table: "Disks",
                newName: "IX_Disks_PCId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Disks",
                table: "Disks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Disks_PCs_PCId",
                table: "Disks",
                column: "PCId",
                principalTable: "PCs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disks_PCs_PCId",
                table: "Disks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Disks",
                table: "Disks");

            migrationBuilder.RenameTable(
                name: "Disks",
                newName: "Disk");

            migrationBuilder.RenameIndex(
                name: "IX_Disks_PCId",
                table: "Disk",
                newName: "IX_Disk_PCId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Disk",
                table: "Disk",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Disk_PCs_PCId",
                table: "Disk",
                column: "PCId",
                principalTable: "PCs",
                principalColumn: "Id");
        }
    }
}
