using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SELP.Infrastructur.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_studentsStudents_students_StudID",
                table: "studentsStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_studentsStudents_subjects_SubID",
                table: "studentsStudents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_studentsStudents",
                table: "studentsStudents");

            migrationBuilder.RenameTable(
                name: "studentsStudents",
                newName: "SubjectStudent");

            migrationBuilder.RenameIndex(
                name: "IX_studentsStudents_SubID",
                table: "SubjectStudent",
                newName: "IX_SubjectStudent_SubID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectStudent",
                table: "SubjectStudent",
                columns: new[] { "StudID", "SubID" });

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectStudent_students_StudID",
                table: "SubjectStudent",
                column: "StudID",
                principalTable: "students",
                principalColumn: "StudID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectStudent_subjects_SubID",
                table: "SubjectStudent",
                column: "SubID",
                principalTable: "subjects",
                principalColumn: "SubID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubjectStudent_students_StudID",
                table: "SubjectStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectStudent_subjects_SubID",
                table: "SubjectStudent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectStudent",
                table: "SubjectStudent");

            migrationBuilder.RenameTable(
                name: "SubjectStudent",
                newName: "studentsStudents");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectStudent_SubID",
                table: "studentsStudents",
                newName: "IX_studentsStudents_SubID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_studentsStudents",
                table: "studentsStudents",
                columns: new[] { "StudID", "SubID" });

            migrationBuilder.AddForeignKey(
                name: "FK_studentsStudents_students_StudID",
                table: "studentsStudents",
                column: "StudID",
                principalTable: "students",
                principalColumn: "StudID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_studentsStudents_subjects_SubID",
                table: "studentsStudents",
                column: "SubID",
                principalTable: "subjects",
                principalColumn: "SubID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
