using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD2.Migrations
{
    /// <inheritdoc />
    public partial class createdepartmentandrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "employeees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    empId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_employeees_DepartmentId",
                table: "employeees",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_employeees_departments_DepartmentId",
                table: "employeees",
                column: "DepartmentId",
                principalTable: "departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employeees_departments_DepartmentId",
                table: "employeees");

            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropIndex(
                name: "IX_employeees_DepartmentId",
                table: "employeees");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "employeees");
        }
    }
}
