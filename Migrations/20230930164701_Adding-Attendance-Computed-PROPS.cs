using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Migrations
{
    public partial class AddingAttendanceComputedPROPS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiscountHours",
                schema: "dbo",
                table: "Attendances",
                type: "int",
                nullable: false,
                computedColumnSql: "CASE WHEN DATEDIFF(HOUR, ArrivalTime, DepartureTime) < 8 AND DATEDIFF(HOUR, ArrivalTime, DepartureTime) > 3 THEN 8 - DATEDIFF(HOUR, ArrivalTime, DepartureTime) ELSE 0 END");

            migrationBuilder.AddColumn<int>(
                name: "ExtraHours",
                schema: "dbo",
                table: "Attendances",
                type: "int",
                nullable: false,
                computedColumnSql: "CASE WHEN DATEDIFF(HOUR, ArrivalTime, DepartureTime) > 8  THEN DATEDIFF(HOUR, ArrivalTime, DepartureTime) - 8 ELSE 0 END");

            migrationBuilder.AddColumn<bool>(
                name: "IsAbsent",
                schema: "dbo",
                table: "Attendances",
                type: "bit",
                nullable: false,
                computedColumnSql: "CONVERT(bit, CASE WHEN DATEDIFF(HOUR, ArrivalTime, DepartureTime) <= 3 THEN 1 ELSE 0 END)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountHours",
                schema: "dbo",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "ExtraHours",
                schema: "dbo",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "IsAbsent",
                schema: "dbo",
                table: "Attendances");
        }
    }
}
