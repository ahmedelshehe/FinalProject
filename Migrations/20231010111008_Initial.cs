using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Migrations
{
    public partial class Initial : Migration
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
                values: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7210", "5f1fb906-3df8-4e2c-87c2-37de68c0b681", "Adminstrator", null });

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
                    { 1, 21, new DateTime(1997, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Irmastad", new DateTime(2020, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cameroon", 1, "employee1@hrsm.com", "Frida", 1, "Brian", "12345678901234", "12345678", "01096366618", 465117.0, "Deshaun Rue", null },
                    { 2, 21, new DateTime(1993, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Parisianburgh", new DateTime(2020, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Australia", 2, "employee2@hrsm.com", "Candida", 0, "Jace", "12345678901234", "12345678", "01096366618", 176652.0, "Cronin Radial", null },
                    { 3, 21, new DateTime(1998, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Charlotteland", new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lithuania", 3, "employee3@hrsm.com", "Waino", 1, "John", "12345678901234", "12345678", "01096366618", 147296.0, "Tianna Locks", null },
                    { 4, 21, new DateTime(1990, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Isabel", new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Kingdom", 1, "employee4@hrsm.com", "Wilber", 1, "Gayle", "12345678901234", "12345678", "01096366618", 309059.0, "Keyshawn Gardens", null },
                    { 5, 21, new DateTime(1994, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Reece", new DateTime(2022, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Congo", 1, "employee5@hrsm.com", "Lamont", 0, "Roosevelt", "12345678901234", "12345678", "01096366618", 320608.0, "Anika Shore", null },
                    { 6, 21, new DateTime(1996, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carrollport", new DateTime(2022, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Macedonia", 1, "employee6@hrsm.com", "Georgiana", 1, "Johnathon", "12345678901234", "12345678", "01096366618", 137597.0, "Monahan Hill", null },
                    { 7, 21, new DateTime(2001, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Port Emeraldborough", new DateTime(2022, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mauritania", 1, "employee7@hrsm.com", "Melisa", 0, "Lonzo", "12345678901234", "12345678", "01096366618", 99831.0, "Christian Lane", null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Employees",
                columns: new[] { "Id", "AvailableVacations", "BirthDate", "City", "ContractDate", "Country", "DeptID", "Email", "FirstName", "Gender", "LastName", "NationalId", "Password", "PhoneNumber", "Salary", "Street", "UserId" },
                values: new object[,]
                {
                    { 8, 21, new DateTime(1990, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sporershire", new DateTime(2023, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Haiti", 1, "employee8@hrsm.com", "Beth", 0, "Retha", "12345678901234", "12345678", "01096366618", 99757.0, "Kris Vista", null },
                    { 9, 21, new DateTime(1998, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Jerrelltown", new DateTime(2021, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Benin", 1, "employee9@hrsm.com", "Ben", 1, "Maude", "12345678901234", "12345678", "01096366618", 114246.0, "Wilfred Lodge", null },
                    { 10, 21, new DateTime(1996, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mrazmouth", new DateTime(2020, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "China", 3, "employee10@hrsm.com", "Issac", 1, "Cecil", "12345678901234", "12345678", "01096366618", 90956.0, "Funk Fall", null },
                    { 11, 21, new DateTime(1998, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Dianashire", new DateTime(2021, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uganda", 1, "employee11@hrsm.com", "Mason", 1, "Dulce", "12345678901234", "12345678", "01096366618", 32385.0, "Jacobi Ranch", null },
                    { 12, 21, new DateTime(1996, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Janice", new DateTime(2020, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sao Tome and Principe", 3, "employee12@hrsm.com", "Brice", 0, "Flossie", "12345678901234", "12345678", "01096366618", 123132.0, "Mylene Ports", null },
                    { 13, 21, new DateTime(1994, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "East May", new DateTime(2023, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iran", 3, "employee13@hrsm.com", "Isac", 1, "Emie", "12345678901234", "12345678", "01096366618", 176248.0, "Dena Coves", null },
                    { 14, 21, new DateTime(1995, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Nicholaus", new DateTime(2020, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Holy See (Vatican City State)", 3, "employee14@hrsm.com", "Lauretta", 1, "Charlene", "12345678901234", "12345678", "01096366618", 149737.0, "Everette Flat", null },
                    { 15, 21, new DateTime(1995, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Brionnaborough", new DateTime(2020, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Georgia", 1, "employee15@hrsm.com", "Rossie", 0, "Barton", "12345678901234", "12345678", "01096366618", 306474.0, "Dannie Skyway", null },
                    { 16, 21, new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Parkerberg", new DateTime(2020, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Namibia", 3, "employee16@hrsm.com", "Greta", 1, "Drake", "12345678901234", "12345678", "01096366618", 222667.0, "Quitzon Passage", null },
                    { 17, 21, new DateTime(1999, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jasminhaven", new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panama", 1, "employee17@hrsm.com", "Ernesto", 0, "Edd", "12345678901234", "12345678", "01096366618", 43325.0, "Cummings Mews", null },
                    { 18, 21, new DateTime(1992, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Joneschester", new DateTime(2022, 8, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Philippines", 1, "employee18@hrsm.com", "Oda", 0, "Kaylee", "12345678901234", "12345678", "01096366618", 288906.0, "Stanton Falls", null },
                    { 19, 21, new DateTime(1992, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hilllburgh", new DateTime(2022, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Congo", 3, "employee19@hrsm.com", "Reinhold", 0, "Kali", "12345678901234", "12345678", "01096366618", 83688.0, "Kirlin Ferry", null },
                    { 20, 21, new DateTime(1999, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Harrison", new DateTime(2020, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Papua New Guinea", 1, "employee20@hrsm.com", "Katrine", 1, "Kendrick", "12345678901234", "12345678", "01096366618", 463414.0, "Corene Ports", null },
                    { 21, 21, new DateTime(1997, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alvinaview", new DateTime(2023, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bermuda", 3, "employee21@hrsm.com", "Shaina", 0, "Minerva", "12345678901234", "12345678", "01096366618", 224716.0, "Assunta Greens", null },
                    { 22, 21, new DateTime(1998, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Manuelstad", new DateTime(2023, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Poland", 3, "employee22@hrsm.com", "Jerod", 1, "Emmett", "12345678901234", "12345678", "01096366618", 12856.0, "Martina Fords", null },
                    { 23, 21, new DateTime(1998, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lueilwitzchester", new DateTime(2020, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "United States Virgin Islands", 3, "employee23@hrsm.com", "Marcia", 1, "Rickey", "12345678901234", "12345678", "01096366618", 123019.0, "Turcotte Roads", null },
                    { 24, 21, new DateTime(2000, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Torphyberg", new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guam", 3, "employee24@hrsm.com", "Bonita", 0, "Alayna", "12345678901234", "12345678", "01096366618", 249611.0, "Bartoletti Ridges", null },
                    { 25, 21, new DateTime(1995, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Stephon", new DateTime(2022, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seychelles", 1, "employee25@hrsm.com", "Myrtice", 0, "Brycen", "12345678901234", "12345678", "01096366618", 267944.0, "Kohler Point", null },
                    { 26, 21, new DateTime(1994, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Simoniston", new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Niger", 3, "employee26@hrsm.com", "Elna", 1, "Clay", "12345678901234", "12345678", "01096366618", 373698.0, "Randal Greens", null },
                    { 27, 21, new DateTime(2001, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Berthashire", new DateTime(2020, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guyana", 2, "employee27@hrsm.com", "Kathlyn", 0, "Armani", "12345678901234", "12345678", "01096366618", 391020.0, "Nicolas Estate", null },
                    { 28, 21, new DateTime(1994, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Port Amanda", new DateTime(2020, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kenya", 1, "employee28@hrsm.com", "Arnaldo", 1, "Waino", "12345678901234", "12345678", "01096366618", 378708.0, "Kathryn Underpass", null },
                    { 29, 21, new DateTime(1997, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Vaughnfort", new DateTime(2023, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trinidad and Tobago", 2, "employee29@hrsm.com", "Alfreda", 1, "Skye", "12345678901234", "12345678", "01096366618", 363284.0, "Margie Forest", null },
                    { 30, 21, new DateTime(1991, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Durgantown", new DateTime(2021, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ireland", 1, "employee30@hrsm.com", "Reid", 1, "Lucy", "12345678901234", "12345678", "01096366618", 45764.0, "Hansen Curve", null },
                    { 31, 21, new DateTime(1991, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Londonmouth", new DateTime(2022, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Macao", 2, "employee31@hrsm.com", "Marion", 0, "Gregg", "12345678901234", "12345678", "01096366618", 214131.0, "Aisha Hills", null },
                    { 32, 21, new DateTime(2001, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Danburgh", new DateTime(2020, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Croatia", 2, "employee32@hrsm.com", "Euna", 0, "Candice", "12345678901234", "12345678", "01096366618", 453900.0, "Herman Causeway", null },
                    { 33, 21, new DateTime(1998, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quitzonton", new DateTime(2020, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bolivia", 2, "employee33@hrsm.com", "Precious", 0, "Kiana", "12345678901234", "12345678", "01096366618", 405769.0, "Sandra Mission", null },
                    { 34, 21, new DateTime(1992, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Hildegardhaven", new DateTime(2022, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Benin", 1, "employee34@hrsm.com", "Rebekah", 1, "Oliver", "12345678901234", "12345678", "01096366618", 118093.0, "Graham Forks", null },
                    { 35, 21, new DateTime(2000, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kadefort", new DateTime(2023, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Angola", 2, "employee35@hrsm.com", "Ayden", 1, "Rhianna", "12345678901234", "12345678", "01096366618", 327357.0, "Hilpert Overpass", null },
                    { 36, 21, new DateTime(2000, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cindyhaven", new DateTime(2020, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabon", 1, "employee36@hrsm.com", "Lorena", 1, "Otho", "12345678901234", "12345678", "01096366618", 96707.0, "Hintz Wells", null },
                    { 37, 21, new DateTime(2001, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Skylamouth", new DateTime(2023, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Qatar", 3, "employee37@hrsm.com", "Lempi", 1, "Lambert", "12345678901234", "12345678", "01096366618", 480652.0, "Ruecker Ridges", null },
                    { 38, 21, new DateTime(1999, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Caleigh", new DateTime(2021, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mexico", 1, "employee38@hrsm.com", "Eloisa", 0, "Cooper", "12345678901234", "12345678", "01096366618", 323433.0, "Tiffany Key", null },
                    { 39, 21, new DateTime(1997, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Wilfrid", new DateTime(2022, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Myanmar", 2, "employee39@hrsm.com", "Thalia", 1, "Daron", "12345678901234", "12345678", "01096366618", 252845.0, "Considine Drive", null },
                    { 40, 21, new DateTime(2000, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Imelda", new DateTime(2022, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint Pierre and Miquelon", 1, "employee40@hrsm.com", "Dee", 1, "Patsy", "12345678901234", "12345678", "01096366618", 58878.0, "Ratke Valley", null },
                    { 41, 21, new DateTime(2001, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Ella", new DateTime(2022, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bouvet Island (Bouvetoya)", 1, "employee41@hrsm.com", "Deion", 0, "Phyllis", "12345678901234", "12345678", "01096366618", 123301.0, "Ebert Ways", null },
                    { 42, 21, new DateTime(1990, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hermannton", new DateTime(2023, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brazil", 3, "employee42@hrsm.com", "Kory", 1, "Leanna", "12345678901234", "12345678", "01096366618", 167663.0, "Edward Stream", null },
                    { 43, 21, new DateTime(1995, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Shawnaberg", new DateTime(2020, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabon", 2, "employee43@hrsm.com", "Theo", 0, "Frieda", "12345678901234", "12345678", "01096366618", 141782.0, "Sidney Ridge", null },
                    { 44, 21, new DateTime(1991, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bradtkestad", new DateTime(2023, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malta", 3, "employee44@hrsm.com", "Ila", 1, "Adrien", "12345678901234", "12345678", "01096366618", 382344.0, "Grant Wall", null },
                    { 45, 21, new DateTime(1992, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Johannfurt", new DateTime(2021, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grenada", 3, "employee45@hrsm.com", "Delia", 0, "Brenda", "12345678901234", "12345678", "01096366618", 151551.0, "Littel Loaf", null },
                    { 46, 21, new DateTime(2002, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mariaside", new DateTime(2022, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Arab Emirates", 2, "employee46@hrsm.com", "Dennis", 0, "Jensen", "12345678901234", "12345678", "01096366618", 192560.0, "Cordie Junction", null },
                    { 47, 21, new DateTime(1999, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kochside", new DateTime(2021, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Israel", 1, "employee47@hrsm.com", "Anissa", 1, "Samson", "12345678901234", "12345678", "01096366618", 449145.0, "Friedrich Expressway", null },
                    { 48, 21, new DateTime(1993, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Stephania", new DateTime(2022, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maldives", 2, "employee48@hrsm.com", "Salvatore", 1, "Manley", "12345678901234", "12345678", "01096366618", 314798.0, "Antonia Mountains", null },
                    { 49, 21, new DateTime(1998, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Nikki", new DateTime(2022, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Samoa", 2, "employee49@hrsm.com", "Eusebio", 0, "Afton", "12345678901234", "12345678", "01096366618", 162113.0, "Wellington Way", null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Employees",
                columns: new[] { "Id", "AvailableVacations", "BirthDate", "City", "ContractDate", "Country", "DeptID", "Email", "FirstName", "Gender", "LastName", "NationalId", "Password", "PhoneNumber", "Salary", "Street", "UserId" },
                values: new object[] { 50, 21, new DateTime(1996, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Daphneeton", new DateTime(2023, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Russian Federation", 1, "employee50@hrsm.com", "Trudie", 1, "Granville", "12345678901234", "12345678", "01096366618", 348183.0, "Mafalda Route", null });

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
