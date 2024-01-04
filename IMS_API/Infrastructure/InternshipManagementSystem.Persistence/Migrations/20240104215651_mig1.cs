using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternshipManagementSystem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advisors",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    AdviserID = table.Column<string>(type: "text", nullable: false),
                    AdviserName = table.Column<string>(type: "text", nullable: true),
                    AdviserSurname = table.Column<string>(type: "text", nullable: true),
                    TC_ID = table.Column<string>(type: "text", nullable: true),
                    DepartmentName = table.Column<string>(type: "text", nullable: true),
                    AdviserGSMNumber = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advisors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentID = table.Column<string>(type: "text", nullable: false),
                    AdviserID = table.Column<string>(type: "text", nullable: true),
                    StudentName = table.Column<string>(type: "text", nullable: true),
                    StudentSurname = table.Column<string>(type: "text", nullable: true),
                    TC_ID = table.Column<string>(type: "text", nullable: true),
                    DepartmentName = table.Column<string>(type: "text", nullable: true),
                    ProgramName = table.Column<string>(type: "text", nullable: true),
                    GPA = table.Column<float>(type: "real", nullable: true),
                    StudentGSMNumber = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Advisorid = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.id);
                    table.ForeignKey(
                        name: "FK_Students_Advisors_Advisorid",
                        column: x => x.Advisorid,
                        principalTable: "Advisors",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "FileData",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    InternshipId = table.Column<string>(type: "text", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    FileType = table.Column<string>(type: "text", nullable: false),
                    ContentID = table.Column<string>(type: "text", nullable: false),
                    Internshipid = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileData", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Internships",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    InternshipId = table.Column<string>(type: "text", nullable: false),
                    AdviserID = table.Column<string>(type: "text", nullable: false),
                    StudentID = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    InternshipBookid = table.Column<Guid>(type: "uuid", nullable: false),
                    SPASid = table.Column<Guid>(type: "uuid", nullable: false),
                    AttendanceScheduleid = table.Column<Guid>(type: "uuid", nullable: false),
                    WeeklyWorkPlanid = table.Column<Guid>(type: "uuid", nullable: false),
                    Studentid = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Internships", x => x.id);
                    table.ForeignKey(
                        name: "FK_Internships_FileData_AttendanceScheduleid",
                        column: x => x.AttendanceScheduleid,
                        principalTable: "FileData",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Internships_FileData_InternshipBookid",
                        column: x => x.InternshipBookid,
                        principalTable: "FileData",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Internships_FileData_SPASid",
                        column: x => x.SPASid,
                        principalTable: "FileData",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Internships_FileData_WeeklyWorkPlanid",
                        column: x => x.WeeklyWorkPlanid,
                        principalTable: "FileData",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Internships_Students_Studentid",
                        column: x => x.Studentid,
                        principalTable: "Students",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileData_Internshipid",
                table: "FileData",
                column: "Internshipid");

            migrationBuilder.CreateIndex(
                name: "IX_Internships_AttendanceScheduleid",
                table: "Internships",
                column: "AttendanceScheduleid");

            migrationBuilder.CreateIndex(
                name: "IX_Internships_InternshipBookid",
                table: "Internships",
                column: "InternshipBookid");

            migrationBuilder.CreateIndex(
                name: "IX_Internships_SPASid",
                table: "Internships",
                column: "SPASid");

            migrationBuilder.CreateIndex(
                name: "IX_Internships_Studentid",
                table: "Internships",
                column: "Studentid");

            migrationBuilder.CreateIndex(
                name: "IX_Internships_WeeklyWorkPlanid",
                table: "Internships",
                column: "WeeklyWorkPlanid");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Advisorid",
                table: "Students",
                column: "Advisorid");

            migrationBuilder.AddForeignKey(
                name: "FK_FileData_Internships_Internshipid",
                table: "FileData",
                column: "Internshipid",
                principalTable: "Internships",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileData_Internships_Internshipid",
                table: "FileData");

            migrationBuilder.DropTable(
                name: "Internships");

            migrationBuilder.DropTable(
                name: "FileData");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Advisors");
        }
    }
}
