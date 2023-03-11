using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeTask.Migrations
{
    /// <inheritdoc />
    public partial class FixTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_Employees_EmployeeId",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "Assignee",
                table: "Task");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Task",
                newName: "AssignedEmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Task_EmployeeId",
                table: "Task",
                newName: "IX_Task_AssignedEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Employees_AssignedEmployeeId",
                table: "Task",
                column: "AssignedEmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_Employees_AssignedEmployeeId",
                table: "Task");

            migrationBuilder.RenameColumn(
                name: "AssignedEmployeeId",
                table: "Task",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_Task_AssignedEmployeeId",
                table: "Task",
                newName: "IX_Task_EmployeeId");

            migrationBuilder.AddColumn<string>(
                name: "Assignee",
                table: "Task",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Employees_EmployeeId",
                table: "Task",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
