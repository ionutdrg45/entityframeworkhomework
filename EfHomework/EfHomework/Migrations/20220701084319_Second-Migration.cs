using Microsoft.EntityFrameworkCore.Migrations;

namespace EfHomework.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTask_Employees_EmployeesId",
                table: "EmployeeTask");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTask_Tasks_TasksId",
                table: "EmployeeTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeTask",
                table: "EmployeeTask");

            migrationBuilder.RenameColumn(
                name: "TasksId",
                table: "EmployeeTask",
                newName: "TaskId");

            migrationBuilder.RenameColumn(
                name: "EmployeesId",
                table: "EmployeeTask",
                newName: "EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeTask_TasksId",
                table: "EmployeeTask",
                newName: "IX_EmployeeTask_TaskId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EmployeeTask",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeTask",
                table: "EmployeeTask",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTask_EmployeeId",
                table: "EmployeeTask",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTask_Employees_EmployeeId",
                table: "EmployeeTask",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTask_Tasks_TaskId",
                table: "EmployeeTask",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTask_Employees_EmployeeId",
                table: "EmployeeTask");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTask_Tasks_TaskId",
                table: "EmployeeTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeTask",
                table: "EmployeeTask");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeTask_EmployeeId",
                table: "EmployeeTask");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EmployeeTask");

            migrationBuilder.RenameColumn(
                name: "TaskId",
                table: "EmployeeTask",
                newName: "TasksId");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "EmployeeTask",
                newName: "EmployeesId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeTask_TaskId",
                table: "EmployeeTask",
                newName: "IX_EmployeeTask_TasksId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeTask",
                table: "EmployeeTask",
                columns: new[] { "EmployeesId", "TasksId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTask_Employees_EmployeesId",
                table: "EmployeeTask",
                column: "EmployeesId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTask_Tasks_TasksId",
                table: "EmployeeTask",
                column: "TasksId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
