using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Migrations
{
    public partial class newPhone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Departments",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAttendanceReport",
                schema: "dbo",
                columns: table => new
                {
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DeptName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "GeneralSetting",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExtraHourPrice = table.Column<int>(type: "int", nullable: false),
                    DiscountHourPrice = table.Column<int>(type: "int", nullable: false),
                    numberofvacationInyear = table.Column<int>(type: "int", nullable: false),
                    PriceForDayOvernumberofvacationInyear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Operation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SettingViewModel",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Extra = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingViewModel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "WeeklyHolidays",
                schema: "dbo",
                columns: table => new
                {
                    Holiday = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Genral_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyHolidays", x => new { x.Holiday, x.Genral_Id });
                    table.ForeignKey(
                        name: "FK_WeeklyHolidays_GeneralSetting_Genral_Id",
                        column: x => x.Genral_Id,
                        principalSchema: "dbo",
                        principalTable: "GeneralSetting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppRolePermission",
                schema: "dbo",
                columns: table => new
                {
                    AppRolesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PermissionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRolePermission", x => new { x.AppRolesId, x.PermissionsId });
                    table.ForeignKey(
                        name: "FK_AppRolePermission_Permissions_PermissionsId",
                        column: x => x.PermissionsId,
                        principalSchema: "dbo",
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppRolePermission_Role_AppRolesId",
                        column: x => x.AppRolesId,
                        principalSchema: "dbo",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "dbo",
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
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeekDaysViewModel",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Checked = table.Column<bool>(type: "bit", nullable: false),
                    SettingViewModelid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekDaysViewModel", x => x.id);
                    table.ForeignKey(
                        name: "FK_WeekDaysViewModel_SettingViewModel_SettingViewModelid",
                        column: x => x.SettingViewModelid,
                        principalSchema: "dbo",
                        principalTable: "SettingViewModel",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Attendances",
                schema: "dbo",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExtraHours = table.Column<int>(type: "int", nullable: false, computedColumnSql: "CASE WHEN DATEDIFF(HOUR, ArrivalTime, DepartureTime) > 8  THEN DATEDIFF(HOUR, ArrivalTime, DepartureTime) - 8 ELSE 0 END"),
                    DiscountHours = table.Column<int>(type: "int", nullable: false, computedColumnSql: "CASE WHEN DATEDIFF(HOUR, ArrivalTime, DepartureTime) < 8 AND DATEDIFF(HOUR, ArrivalTime, DepartureTime) > 3 THEN 8 - DATEDIFF(HOUR, ArrivalTime, DepartureTime) ELSE 0 END"),
                    IsAbsent = table.Column<bool>(type: "bit", nullable: false, computedColumnSql: "CONVERT(bit, CASE WHEN DATEDIFF(HOUR, ArrivalTime, DepartureTime) <= 3 THEN 1 ELSE 0 END)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => new { x.Date, x.EmployeeId });
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvailableVacations = table.Column<int>(type: "int", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    DeptID = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DeptID",
                        column: x => x.DeptID,
                        principalSchema: "dbo",
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmpId = table.Column<int>(type: "int", nullable: false),
                    RoleAppId = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Employees_EmpId",
                        column: x => x.EmpId,
                        principalSchema: "dbo",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleAppId",
                        column: x => x.RoleAppId,
                        principalSchema: "dbo",
                        principalTable: "Role",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vacations",
                schema: "dbo",
                columns: table => new
                {
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    VacationType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacations", x => new { x.StartDate, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_Vacations_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "dbo",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfficalVacations",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficalVacations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfficalVacations_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "dbo",
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
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "dbo",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "HR" },
                    { 2, "R & D" },
                    { 3, "IT" },
                    { 4, "Sales" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "GeneralSetting",
                columns: new[] { "Id", "DiscountHourPrice", "ExtraHourPrice", "PriceForDayOvernumberofvacationInyear", "numberofvacationInyear" },
                values: new object[] { 1, 150, 75, 300, 21 });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Permissions",
                columns: new[] { "Id", "Name", "Operation" },
                values: new object[,]
                {
                    { 1, "Employee", 1 },
                    { 2, "Employee", 2 },
                    { 3, "Employee", 3 },
                    { 4, "Employee", 0 },
                    { 5, "Attendance", 1 },
                    { 6, "Attendance", 2 },
                    { 7, "Attendance", 3 },
                    { 8, "Attendance", 0 },
                    { 9, "AppRole", 1 },
                    { 10, "AppRole", 2 },
                    { 11, "AppRole", 3 },
                    { 12, "AppRole", 0 },
                    { 13, "AppUser", 1 },
                    { 14, "AppUser", 2 },
                    { 15, "AppUser", 3 },
                    { 16, "AppUser", 0 },
                    { 17, "Permission", 1 },
                    { 18, "Permission", 2 },
                    { 19, "Permission", 3 },
                    { 20, "Permission", 0 },
                    { 21, "Department", 1 },
                    { 22, "Department", 2 },
                    { 23, "Department", 3 },
                    { 24, "Department", 0 },
                    { 25, "OfficialVacation", 1 },
                    { 26, "OfficialVacation", 2 },
                    { 27, "OfficialVacation", 3 },
                    { 28, "OfficialVacation", 0 },
                    { 29, "Vacation", 1 },
                    { 30, "Vacation", 2 },
                    { 31, "Vacation", 3 },
                    { 32, "Vacation", 0 },
                    { 34, "GeneralSetting", 1 },
                    { 35, "GeneralSetting", 2 },
                    { 36, "Salary", 1 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7210", "73e78560-eaf0-4ea4-81aa-0dc71bb65ae0", "Adminstrator", null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppRolePermission",
                columns: new[] { "AppRolesId", "PermissionsId" },
                values: new object[,]
                {
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", 1 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", 2 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", 3 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", 4 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", 5 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", 6 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", 7 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", 8 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", 9 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", 10 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", 11 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", 12 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", 13 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", 14 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", 15 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", 16 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", 17 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", 18 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", 19 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", 20 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", 21 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", 22 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", 23 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", 24 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", 25 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", 26 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", 27 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", 28 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", 29 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", 30 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", 31 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", 32 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", 34 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", 35 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", 36 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Employees",
                columns: new[] { "Id", "AvailableVacations", "BirthDate", "City", "ContractDate", "Country", "DeptID", "Email", "FirstName", "Gender", "LastName", "NationalId", "Password", "PhoneNumber", "Salary", "Street", "UserId" },
                values: new object[,]
                {
                    { 1, 21, new DateTime(1998, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Idell", new DateTime(2020, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Belize", 3, "employee1@hrsm.com", "Jaleel", 1, "Nat", "12345678901234", "12345678", "01096366618", 263566.0, "Rath Forest", null },
                    { 2, 21, new DateTime(1994, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Mateo", new DateTime(2021, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kazakhstan", 2, "employee2@hrsm.com", "Malachi", 1, "Adan", "12345678901234", "12345678", "01096366618", 11531.0, "Herman Lodge", null },
                    { 3, 21, new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Enriquemouth", new DateTime(2021, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wallis and Futuna", 3, "employee3@hrsm.com", "Nannie", 1, "Jesus", "12345678901234", "12345678", "01096366618", 332157.0, "Cecilia Underpass", null },
                    { 4, 21, new DateTime(1997, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deshawnside", new DateTime(2023, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "British Virgin Islands", 2, "employee4@hrsm.com", "Leda", 1, "Alvis", "12345678901234", "12345678", "01096366618", 164726.0, "Cormier Pike", null },
                    { 5, 21, new DateTime(2002, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Cheyanne", new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Angola", 3, "employee5@hrsm.com", "Alisa", 0, "Christian", "12345678901234", "12345678", "01096366618", 241821.0, "Cummerata Grove", null },
                    { 6, 21, new DateTime(1998, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Lisandro", new DateTime(2020, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iraq", 3, "employee6@hrsm.com", "Jude", 0, "Bertrand", "12345678901234", "12345678", "01096366618", 74171.0, "Jerome Haven", null },
                    { 7, 21, new DateTime(2001, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Myah", new DateTime(2020, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paraguay", 3, "employee7@hrsm.com", "Elijah", 0, "Delphia", "12345678901234", "12345678", "01096366618", 116358.0, "Sofia Court", null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Employees",
                columns: new[] { "Id", "AvailableVacations", "BirthDate", "City", "ContractDate", "Country", "DeptID", "Email", "FirstName", "Gender", "LastName", "NationalId", "Password", "PhoneNumber", "Salary", "Street", "UserId" },
                values: new object[,]
                {
                    { 8, 21, new DateTime(1999, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Mayaville", new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Macao", 2, "employee8@hrsm.com", "Sheridan", 1, "Keshawn", "12345678901234", "12345678", "01096366618", 118165.0, "Bauch Lodge", null },
                    { 9, 21, new DateTime(1995, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "VonRuedenchester", new DateTime(2021, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint Lucia", 2, "employee9@hrsm.com", "Jerrold", 1, "Earnestine", "12345678901234", "12345678", "01096366618", 288194.0, "Mitchell Summit", null },
                    { 10, 21, new DateTime(1995, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Fletcher", new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Austria", 3, "employee10@hrsm.com", "Al", 0, "Jayden", "12345678901234", "12345678", "01096366618", 93943.0, "Kessler Points", null },
                    { 11, 21, new DateTime(1996, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Lindsay", new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grenada", 2, "employee11@hrsm.com", "Mekhi", 1, "Jed", "12345678901234", "12345678", "01096366618", 186323.0, "Larson Rapid", null },
                    { 12, 21, new DateTime(1991, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vonside", new DateTime(2020, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yemen", 2, "employee12@hrsm.com", "Adella", 0, "Hannah", "12345678901234", "12345678", "01096366618", 473888.0, "Freeda Knoll", null },
                    { 13, 21, new DateTime(1990, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hansenborough", new DateTime(2020, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liberia", 2, "employee13@hrsm.com", "Sydnee", 0, "Kaylin", "12345678901234", "12345678", "01096366618", 381210.0, "Boehm Mission", null },
                    { 14, 21, new DateTime(2002, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Port Devanborough", new DateTime(2021, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paraguay", 2, "employee14@hrsm.com", "Deborah", 0, "Shayna", "12345678901234", "12345678", "01096366618", 220865.0, "Una Gateway", null },
                    { 15, 21, new DateTime(1996, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fritschbury", new DateTime(2020, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Slovenia", 2, "employee15@hrsm.com", "Dasia", 1, "Dimitri", "12345678901234", "12345678", "01096366618", 189021.0, "Anderson Mill", null },
                    { 16, 21, new DateTime(2001, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Camyllemouth", new DateTime(2023, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabon", 1, "employee16@hrsm.com", "Marlene", 1, "Nikolas", "12345678901234", "12345678", "01096366618", 24350.0, "Ebert Meadow", null },
                    { 17, 21, new DateTime(1997, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Keeblershire", new DateTime(2023, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "India", 3, "employee17@hrsm.com", "Kellie", 0, "Sid", "12345678901234", "12345678", "01096366618", 299443.0, "Brendan Viaduct", null },
                    { 18, 21, new DateTime(1990, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Stacy", new DateTime(2020, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Congo", 2, "employee18@hrsm.com", "Pattie", 1, "Emmet", "12345678901234", "12345678", "01096366618", 61097.0, "Carter Via", null },
                    { 19, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Santinaburgh", new DateTime(2020, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Azerbaijan", 2, "employee19@hrsm.com", "Dortha", 1, "Raphael", "12345678901234", "12345678", "01096366618", 340693.0, "Stacy Overpass", null },
                    { 20, 21, new DateTime(1999, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Louie", new DateTime(2022, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ukraine", 3, "employee20@hrsm.com", "Lilliana", 0, "Johanna", "12345678901234", "12345678", "01096366618", 386471.0, "Estevan Junctions", null },
                    { 21, 21, new DateTime(1993, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Gilbert", new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bahrain", 1, "employee21@hrsm.com", "Darion", 1, "Aida", "12345678901234", "12345678", "01096366618", 289717.0, "Funk Unions", null },
                    { 22, 21, new DateTime(1993, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Johnson", new DateTime(2020, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Afghanistan", 3, "employee22@hrsm.com", "Cortez", 1, "Summer", "12345678901234", "12345678", "01096366618", 22082.0, "Colleen Cove", null },
                    { 23, 21, new DateTime(1996, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Reese", new DateTime(2021, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jordan", 1, "employee23@hrsm.com", "Naomi", 1, "Keaton", "12345678901234", "12345678", "01096366618", 46654.0, "O'Conner Lane", null },
                    { 24, 21, new DateTime(2000, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Aileenton", new DateTime(2021, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aruba", 3, "employee24@hrsm.com", "Daija", 0, "Eli", "12345678901234", "12345678", "01096366618", 314314.0, "Maggio Tunnel", null },
                    { 25, 21, new DateTime(2002, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Boylemouth", new DateTime(2020, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Poland", 3, "employee25@hrsm.com", "Tara", 1, "Valerie", "12345678901234", "12345678", "01096366618", 196428.0, "Anahi Well", null },
                    { 26, 21, new DateTime(1997, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bahringerport", new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finland", 3, "employee26@hrsm.com", "Nicole", 0, "Salma", "12345678901234", "12345678", "01096366618", 45360.0, "Ole Haven", null },
                    { 27, 21, new DateTime(2002, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Elian", new DateTime(2020, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Morocco", 3, "employee27@hrsm.com", "Adolph", 1, "Novella", "12345678901234", "12345678", "01096366618", 303215.0, "Romaguera Court", null },
                    { 28, 21, new DateTime(1998, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Brennon", new DateTime(2021, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Paraguay", 3, "employee28@hrsm.com", "Osborne", 0, "Katelin", "12345678901234", "12345678", "01096366618", 11386.0, "Hagenes Station", null },
                    { 29, 21, new DateTime(1990, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Krystinafurt", new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "United States Virgin Islands", 2, "employee29@hrsm.com", "Malinda", 0, "Greyson", "12345678901234", "12345678", "01096366618", 412898.0, "Zemlak Ridge", null },
                    { 30, 21, new DateTime(1991, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Angelicatown", new DateTime(2022, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cocos (Keeling) Islands", 1, "employee30@hrsm.com", "America", 1, "Rhoda", "12345678901234", "12345678", "01096366618", 223430.0, "Catharine Rue", null },
                    { 31, 21, new DateTime(1991, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Jakaylachester", new DateTime(2020, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Switzerland", 2, "employee31@hrsm.com", "Odessa", 0, "Florencio", "12345678901234", "12345678", "01096366618", 211439.0, "Kuhlman Lodge", null },
                    { 32, 21, new DateTime(1997, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Edd", new DateTime(2022, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peru", 1, "employee32@hrsm.com", "Kendall", 0, "Scarlett", "12345678901234", "12345678", "01096366618", 484335.0, "Milford Trail", null },
                    { 33, 21, new DateTime(2002, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Port Royal", new DateTime(2023, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Western Sahara", 3, "employee33@hrsm.com", "Aditya", 1, "Fidel", "12345678901234", "12345678", "01096366618", 215248.0, "Beier Coves", null },
                    { 34, 21, new DateTime(2002, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tomburgh", new DateTime(2022, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Western Sahara", 1, "employee34@hrsm.com", "Christa", 1, "Elody", "12345678901234", "12345678", "01096366618", 162419.0, "Nitzsche Junctions", null },
                    { 35, 21, new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Camylle", new DateTime(2020, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "United States of America", 1, "employee35@hrsm.com", "Tressa", 0, "Eryn", "12345678901234", "12345678", "01096366618", 127230.0, "Greta Cape", null },
                    { 36, 21, new DateTime(1992, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Glennachester", new DateTime(2022, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bahrain", 2, "employee36@hrsm.com", "Jany", 0, "Chaya", "12345678901234", "12345678", "01096366618", 456236.0, "Ortiz Estate", null },
                    { 37, 21, new DateTime(1993, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Americoport", new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Montserrat", 3, "employee37@hrsm.com", "Brielle", 1, "Samir", "12345678901234", "12345678", "01096366618", 493629.0, "Kris Squares", null },
                    { 38, 21, new DateTime(2000, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samantabury", new DateTime(2020, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Belgium", 2, "employee38@hrsm.com", "Jedidiah", 0, "Jaron", "12345678901234", "12345678", "01096366618", 299139.0, "Considine Throughway", null },
                    { 39, 21, new DateTime(1996, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gennarofort", new DateTime(2021, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chile", 2, "employee39@hrsm.com", "Laurie", 1, "Joey", "12345678901234", "12345678", "01096366618", 116067.0, "Kailey Flat", null },
                    { 40, 21, new DateTime(1993, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Cheyenne", new DateTime(2021, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gambia", 2, "employee40@hrsm.com", "Enrique", 1, "Lavern", "12345678901234", "12345678", "01096366618", 300427.0, "Jamir Point", null },
                    { 41, 21, new DateTime(2001, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Port Esther", new DateTime(2021, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kuwait", 3, "employee41@hrsm.com", "Sofia", 1, "Jane", "12345678901234", "12345678", "01096366618", 387792.0, "Kshlerin Crossing", null },
                    { 42, 21, new DateTime(1993, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Mikelfurt", new DateTime(2023, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bahamas", 2, "employee42@hrsm.com", "Kenton", 1, "Alena", "12345678901234", "12345678", "01096366618", 205549.0, "Wehner Ville", null },
                    { 43, 21, new DateTime(2001, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Phoebefurt", new DateTime(2021, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Indonesia", 2, "employee43@hrsm.com", "Lucie", 0, "Maymie", "12345678901234", "12345678", "01096366618", 151851.0, "Jerry Drive", null },
                    { 44, 21, new DateTime(1995, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fannyview", new DateTime(2022, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Heard Island and McDonald Islands", 1, "employee44@hrsm.com", "Dustin", 1, "Germaine", "12345678901234", "12345678", "01096366618", 267462.0, "Wiza Ridge", null },
                    { 45, 21, new DateTime(1990, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Josiane", new DateTime(2023, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kenya", 1, "employee45@hrsm.com", "Tracy", 1, "Howell", "12345678901234", "12345678", "01096366618", 52963.0, "Felton Grove", null },
                    { 46, 21, new DateTime(1995, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Port Ocie", new DateTime(2021, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Caledonia", 1, "employee46@hrsm.com", "Jensen", 1, "Ephraim", "12345678901234", "12345678", "01096366618", 392306.0, "Nettie Valleys", null },
                    { 47, 21, new DateTime(1996, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Itzelfort", new DateTime(2022, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Belize", 1, "employee47@hrsm.com", "Alfred", 1, "Kristopher", "12345678901234", "12345678", "01096366618", 134366.0, "Lempi Wells", null },
                    { 48, 21, new DateTime(1992, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Vilmamouth", new DateTime(2021, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lesotho", 1, "employee48@hrsm.com", "Destinee", 0, "Greg", "12345678901234", "12345678", "01096366618", 495446.0, "Monahan Landing", null },
                    { 49, 21, new DateTime(1996, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Zelda", new DateTime(2020, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Greece", 3, "employee49@hrsm.com", "Elsie", 1, "Bert", "12345678901234", "12345678", "01096366618", 39852.0, "Bridgette Lodge", null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Employees",
                columns: new[] { "Id", "AvailableVacations", "BirthDate", "City", "ContractDate", "Country", "DeptID", "Email", "FirstName", "Gender", "LastName", "NationalId", "Password", "PhoneNumber", "Salary", "Street", "UserId" },
                values: new object[] { 50, 21, new DateTime(1998, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trompchester", new DateTime(2020, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Namibia", 1, "employee50@hrsm.com", "Keely", 0, "Alexander", "12345678901234", "12345678", "01096366618", 350866.0, "Crooks Island", null });

            migrationBuilder.CreateIndex(
                name: "IX_AppRolePermission_PermissionsId",
                schema: "dbo",
                table: "AppRolePermission",
                column: "PermissionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_EmployeeId",
                schema: "dbo",
                table: "Attendances",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DeptID",
                schema: "dbo",
                table: "Employees",
                column: "DeptID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                schema: "dbo",
                table: "Employees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficalVacations_UserId",
                schema: "dbo",
                table: "OfficalVacations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "dbo",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "dbo",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "dbo",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_User_EmpId",
                schema: "dbo",
                table: "User",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleAppId",
                schema: "dbo",
                table: "User",
                column: "RoleAppId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "dbo",
                table: "User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "dbo",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                schema: "dbo",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "dbo",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacations_EmployeeId",
                schema: "dbo",
                table: "Vacations",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_WeekDaysViewModel_SettingViewModelid",
                schema: "dbo",
                table: "WeekDaysViewModel",
                column: "SettingViewModelid");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyHolidays_Genral_Id",
                schema: "dbo",
                table: "WeeklyHolidays",
                column: "Genral_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Employees_EmployeeId",
                schema: "dbo",
                table: "Attendances",
                column: "EmployeeId",
                principalSchema: "dbo",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_User_UserId",
                schema: "dbo",
                table: "Employees",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_RoleAppId",
                schema: "dbo",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Employees_EmpId",
                schema: "dbo",
                table: "User");

            migrationBuilder.DropTable(
                name: "AppRolePermission",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Attendances",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EmployeeAttendanceReport",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "OfficalVacations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Vacations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "WeekDaysViewModel",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "WeeklyHolidays",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Permissions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SettingViewModel",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "GeneralSetting",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Employees",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Departments",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "User",
                schema: "dbo");
        }
    }
}
