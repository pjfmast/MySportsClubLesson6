using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MySportsClubLesson6.Migrations
{
    public partial class MemberWithEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Member",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "ID",
                keyValue: 1,
                column: "Email",
                value: "esther@gmail.com");

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "ID",
                keyValue: 2,
                column: "Email",
                value: "anton@gmail.com");

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "ID",
                keyValue: 3,
                column: "Email",
                value: "manon@avans.com");

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "ID",
                keyValue: 4,
                column: "Email",
                value: "joke@avd.com");

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "ID",
                keyValue: 5,
                column: "Email",
                value: "jeroen@gmail.com");

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "ID",
                keyValue: 6,
                column: "Email",
                value: "ellen@breda.nl");

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "ID",
                keyValue: 7,
                column: "Email",
                value: "eva@edu.org");

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "ID",
                keyValue: 8,
                column: "Email",
                value: "anke@bandw.com");

            migrationBuilder.UpdateData(
                table: "Member",
                keyColumn: "ID",
                keyValue: 9,
                column: "Email",
                value: "koen@gmail.com");

            migrationBuilder.UpdateData(
                table: "Workout",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2021, 3, 18, 11, 15, 0, 0, DateTimeKind.Local), new DateTime(2021, 3, 18, 10, 15, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Workout",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2021, 3, 18, 18, 15, 0, 0, DateTimeKind.Local), new DateTime(2021, 3, 18, 17, 15, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Workout",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2021, 3, 19, 11, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 3, 19, 10, 15, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Workout",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2021, 3, 19, 11, 15, 0, 0, DateTimeKind.Local), new DateTime(2021, 3, 19, 10, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Workout",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2021, 3, 19, 19, 15, 0, 0, DateTimeKind.Local), new DateTime(2021, 3, 19, 18, 15, 0, 0, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Member");

            migrationBuilder.UpdateData(
                table: "Workout",
                keyColumn: "ID",
                keyValue: 8,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2021, 3, 11, 11, 15, 0, 0, DateTimeKind.Local), new DateTime(2021, 3, 11, 10, 15, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Workout",
                keyColumn: "ID",
                keyValue: 9,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2021, 3, 11, 18, 15, 0, 0, DateTimeKind.Local), new DateTime(2021, 3, 11, 17, 15, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Workout",
                keyColumn: "ID",
                keyValue: 10,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2021, 3, 12, 11, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 3, 12, 10, 15, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Workout",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2021, 3, 12, 11, 15, 0, 0, DateTimeKind.Local), new DateTime(2021, 3, 12, 10, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Workout",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2021, 3, 12, 19, 15, 0, 0, DateTimeKind.Local), new DateTime(2021, 3, 12, 18, 15, 0, 0, DateTimeKind.Local) });
        }
    }
}
