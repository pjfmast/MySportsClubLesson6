using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MySportsClubLesson6.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    StartMembership = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Workout",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instructor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CapacityLeft = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workout", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberID = table.Column<int>(type: "int", nullable: false),
                    WorkoutID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Enrollment_Member_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Member",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollment_Workout_WorkoutID",
                        column: x => x.WorkoutID,
                        principalTable: "Workout",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Member",
                columns: new[] { "ID", "Name", "StartMembership" },
                values: new object[,]
                {
                    { 1, "Esther", new DateTime(2014, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Anton", new DateTime(2018, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Manon", new DateTime(2016, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Joke", new DateTime(2019, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Jeroen", new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Ellen", new DateTime(2010, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Eva", new DateTime(2012, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Anke", new DateTime(2015, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "Koen", new DateTime(2015, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Workout",
                columns: new[] { "ID", "CapacityLeft", "EndTime", "Instructor", "Location", "StartTime", "Title" },
                values: new object[,]
                {
                    { 12, 8, new DateTime(2021, 3, 12, 19, 15, 0, 0, DateTimeKind.Local), null, "Cycle Area", new DateTime(2021, 3, 12, 18, 15, 0, 0, DateTimeKind.Local), "Cycle Interval" },
                    { 11, 12, new DateTime(2021, 3, 12, 11, 15, 0, 0, DateTimeKind.Local), null, "Room 2", new DateTime(2021, 3, 12, 10, 30, 0, 0, DateTimeKind.Local), "Shred and Burn" },
                    { 10, 35, new DateTime(2021, 3, 12, 11, 0, 0, 0, DateTimeKind.Local), null, "Room 1", new DateTime(2021, 3, 12, 10, 15, 0, 0, DateTimeKind.Local), "TBW" },
                    { 9, 30, new DateTime(2021, 3, 11, 18, 15, 0, 0, DateTimeKind.Local), null, "Yoga studio", new DateTime(2021, 3, 11, 17, 15, 0, 0, DateTimeKind.Local), "Vinyasa Yoga" },
                    { 8, 18, new DateTime(2021, 3, 11, 11, 15, 0, 0, DateTimeKind.Local), null, "Room 4", new DateTime(2021, 3, 11, 10, 15, 0, 0, DateTimeKind.Local), "Spinning" },
                    { 7, 35, new DateTime(2021, 3, 17, 20, 0, 0, 0, DateTimeKind.Local), null, "Room 1", new DateTime(2021, 3, 17, 19, 15, 0, 0, DateTimeKind.Local), "Callanetics" },
                    { 3, 35, new DateTime(2021, 3, 16, 11, 15, 0, 0, DateTimeKind.Local), null, "Yoga studio", new DateTime(2021, 3, 16, 10, 15, 0, 0, DateTimeKind.Local), "Hot Yoga" },
                    { 5, 25, new DateTime(2021, 3, 17, 10, 15, 0, 0, DateTimeKind.Local), null, "Room 2", new DateTime(2021, 3, 17, 9, 15, 0, 0, DateTimeKind.Local), "XCO" },
                    { 4, 30, new DateTime(2021, 3, 16, 20, 15, 0, 0, DateTimeKind.Local), null, "Room 1", new DateTime(2021, 3, 16, 19, 15, 0, 0, DateTimeKind.Local), "Club Power" },
                    { 13, 12, new DateTime(2021, 3, 13, 10, 15, 0, 0, DateTimeKind.Local), null, "Cycle Area", new DateTime(2021, 3, 13, 9, 15, 0, 0, DateTimeKind.Local), "Spinning" },
                    { 2, 30, new DateTime(2021, 3, 15, 18, 0, 0, 0, DateTimeKind.Local), null, "Yoga studio", new DateTime(2021, 3, 15, 17, 0, 0, 0, DateTimeKind.Local), "Pilates" },
                    { 1, 35, new DateTime(2021, 3, 15, 11, 0, 0, 0, DateTimeKind.Local), null, "Yoga studio", new DateTime(2021, 3, 15, 10, 15, 0, 0, DateTimeKind.Local), "Yin Yoga" },
                    { 6, 16, new DateTime(2021, 3, 17, 11, 15, 0, 0, DateTimeKind.Local), null, "Boxing Area", new DateTime(2021, 3, 17, 10, 15, 0, 0, DateTimeKind.Local), "B&K Training" },
                    { 14, 6, new DateTime(2021, 3, 14, 11, 15, 0, 0, DateTimeKind.Local), null, "Cycle Area", new DateTime(2021, 3, 14, 10, 15, 0, 0, DateTimeKind.Local), "Cycle & Abs" }
                });

            migrationBuilder.InsertData(
                table: "Enrollment",
                columns: new[] { "ID", "MemberID", "WorkoutID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 8, 4, 1 },
                    { 3, 2, 2 },
                    { 2, 1, 4 },
                    { 6, 3, 4 },
                    { 9, 4, 4 },
                    { 4, 2, 5 },
                    { 7, 3, 8 },
                    { 10, 4, 10 },
                    { 11, 4, 13 },
                    { 5, 2, 14 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_MemberID",
                table: "Enrollment",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_WorkoutID",
                table: "Enrollment",
                column: "WorkoutID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Workout");
        }
    }
}
