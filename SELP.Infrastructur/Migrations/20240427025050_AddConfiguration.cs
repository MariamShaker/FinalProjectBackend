using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SELP.Infrastructur.Migrations
{
    /// <inheritdoc />
    public partial class AddConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ins_Subjects_instructors_InsId",
                table: "Ins_Subjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Ins_Subjects_subjects_SubId",
                table: "Ins_Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_instructors",
                table: "instructors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ins_Subjects",
                table: "Ins_Subjects");

            migrationBuilder.RenameTable(
                name: "instructors",
                newName: "Instructor");

            migrationBuilder.RenameTable(
                name: "Ins_Subjects",
                newName: "Ins_Subject");

            migrationBuilder.RenameIndex(
                name: "IX_Ins_Subjects_InsId",
                table: "Ins_Subject",
                newName: "IX_Ins_Subject_InsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instructor",
                table: "Instructor",
                column: "InsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ins_Subject",
                table: "Ins_Subject",
                columns: new[] { "SubId", "InsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Ins_Subject_Instructor_InsId",
                table: "Ins_Subject",
                column: "InsId",
                principalTable: "Instructor",
                principalColumn: "InsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ins_Subject_subjects_SubId",
                table: "Ins_Subject",
                column: "SubId",
                principalTable: "subjects",
                principalColumn: "SubID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ins_Subject_Instructor_InsId",
                table: "Ins_Subject");

            migrationBuilder.DropForeignKey(
                name: "FK_Ins_Subject_subjects_SubId",
                table: "Ins_Subject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instructor",
                table: "Instructor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ins_Subject",
                table: "Ins_Subject");

            migrationBuilder.RenameTable(
                name: "Instructor",
                newName: "instructors");

            migrationBuilder.RenameTable(
                name: "Ins_Subject",
                newName: "Ins_Subjects");

            migrationBuilder.RenameIndex(
                name: "IX_Ins_Subject_InsId",
                table: "Ins_Subjects",
                newName: "IX_Ins_Subjects_InsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_instructors",
                table: "instructors",
                column: "InsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ins_Subjects",
                table: "Ins_Subjects",
                columns: new[] { "SubId", "InsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Ins_Subjects_instructors_InsId",
                table: "Ins_Subjects",
                column: "InsId",
                principalTable: "instructors",
                principalColumn: "InsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ins_Subjects_subjects_SubId",
                table: "Ins_Subjects",
                column: "SubId",
                principalTable: "subjects",
                principalColumn: "SubID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
