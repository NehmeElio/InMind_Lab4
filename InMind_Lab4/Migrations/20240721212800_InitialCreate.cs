using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InMind_Lab4.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Location = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("class_pk", x => x.ClassId);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "integer", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("student_pk", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "integer", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Department = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("teacher_pk", x => x.TeacherId);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    TeacherId = table.Column<int>(type: "integer", nullable: true),
                    ClassId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("course_pk", x => x.CourseId);
                    table.ForeignKey(
                        name: "course_course_courseid_fk",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "ClassId");
                    table.ForeignKey(
                        name: "course_teacher_teacherid_fk",
                        column: x => x.TeacherId,
                        principalTable: "Teacher",
                        principalColumn: "TeacherId");
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    EnrollmentId = table.Column<int>(type: "integer", nullable: false),
                    StudentId = table.Column<int>(type: "integer", nullable: true),
                    CourseId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("enrollment_pk", x => x.EnrollmentId);
                    table.ForeignKey(
                        name: "enrollment_course_courseid_fk",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseId");
                    table.ForeignKey(
                        name: "enrollment_student_studentid_fk",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentId");
                });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "ClassId", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "Room 101", "Math 101" },
                    { 2, "Room 102", "Science 102" },
                    { 3, "Room 201", "History 201" },
                    { 4, "Room 202", "Art 202" },
                    { 5, "Room 301", "Music 301" }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "StudentId", "DateOfBirth", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateOnly(2000, 5, 15), "Michael", "Jordan" },
                    { 2, new DateOnly(1999, 3, 22), "Sarah", "Connor" },
                    { 3, new DateOnly(2001, 7, 11), "David", "Beckham" },
                    { 4, new DateOnly(2002, 1, 5), "Emma", "Watson" },
                    { 5, new DateOnly(1998, 11, 30), "James", "Bond" }
                });

            migrationBuilder.InsertData(
                table: "Teacher",
                columns: new[] { "TeacherId", "Department", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Mathematics", "John", "Smith" },
                    { 2, "Science", "Jane", "Doe" },
                    { 3, "History", "Alice", "Johnson" },
                    { 4, "Art", "Bob", "Brown" },
                    { 5, "Music", "Charlie", "Davis" }
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "CourseId", "ClassId", "Description", "TeacherId", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Basic Algebra Course", 1, "Algebra" },
                    { 2, 2, "Introduction to Physics", 2, "Physics" },
                    { 3, 3, "History of the World", 3, "World History" },
                    { 4, 4, "Basics of Painting", 4, "Painting" },
                    { 5, 5, "Introduction to Piano", 5, "Piano" }
                });

            migrationBuilder.InsertData(
                table: "Enrollment",
                columns: new[] { "EnrollmentId", "CourseId", "StudentId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 4 },
                    { 5, 5, 5 },
                    { 6, 2, 1 },
                    { 7, 3, 2 },
                    { 8, 4, 3 },
                    { 9, 5, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_ClassId",
                table: "Course",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_TeacherId",
                table: "Course",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_CourseId",
                table: "Enrollment",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_StudentId",
                table: "Enrollment",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Teacher");
        }
    }
}
