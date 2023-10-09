using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Migrations
{
    public partial class Final : Migration
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
                name: "PhoneNumbers",
                schema: "dbo",
                columns: table => new
                {
                    Number = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbers", x => new { x.Number, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "dbo",
                        principalTable: "Employees",
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
                values: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7210", "8844d434-0e8d-48a7-ab77-902b7330f1ef", "Adminstrator", null });

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
                columns: new[] { "Id", "AvailableVacations", "BirthDate", "City", "ContractDate", "Country", "DeptID", "Email", "FirstName", "Gender", "LastName", "NationalId", "Password", "Salary", "Street", "UserId" },
                values: new object[,]
                {
                    { 1, 21, new DateTime(1991, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hintzton", new DateTime(2020, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Madagascar", 2, "employee1@hrsm.com", "Kareem", 0, "Noble", "12345678901234", "12345678", 339679.0, "Klocko Circle", null },
                    { 2, 21, new DateTime(1998, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Timmothy", new DateTime(2022, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lebanon", 1, "employee2@hrsm.com", "Dixie", 0, "Celestino", "12345678901234", "12345678", 480082.0, "Corene Corners", null },
                    { 3, 21, new DateTime(1996, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Noemiefurt", new DateTime(2022, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Switzerland", 3, "employee3@hrsm.com", "Sheldon", 0, "Antonia", "12345678901234", "12345678", 383114.0, "Barton Neck", null },
                    { 4, 21, new DateTime(1997, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Macy", new DateTime(2020, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Belarus", 1, "employee4@hrsm.com", "Dan", 1, "Russell", "12345678901234", "12345678", 158283.0, "Kertzmann Groves", null },
                    { 5, 21, new DateTime(1991, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Port Ernabury", new DateTime(2023, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Palau", 2, "employee5@hrsm.com", "Jessy", 1, "Cristopher", "12345678901234", "12345678", 180025.0, "Jarvis Springs", null },
                    { 6, 21, new DateTime(2000, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Port Hendersonberg", new DateTime(2020, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Slovenia", 3, "employee6@hrsm.com", "Jordi", 1, "Evan", "12345678901234", "12345678", 38096.0, "Lebsack Forest", null },
                    { 7, 21, new DateTime(2001, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Narciso", new DateTime(2021, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bhutan", 2, "employee7@hrsm.com", "Ofelia", 0, "Andre", "12345678901234", "12345678", 366775.0, "Bernice Forks", null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Employees",
                columns: new[] { "Id", "AvailableVacations", "BirthDate", "City", "ContractDate", "Country", "DeptID", "Email", "FirstName", "Gender", "LastName", "NationalId", "Password", "Salary", "Street", "UserId" },
                values: new object[,]
                {
                    { 8, 21, new DateTime(1991, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nicklausmouth", new DateTime(2020, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Portugal", 2, "employee8@hrsm.com", "Hazle", 1, "Edd", "12345678901234", "12345678", 448698.0, "Skiles Oval", null },
                    { 9, 21, new DateTime(1993, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Kailey", new DateTime(2020, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Martinique", 3, "employee9@hrsm.com", "Caitlyn", 1, "Jazmyn", "12345678901234", "12345678", 394820.0, "Kshlerin Shoals", null },
                    { 10, 21, new DateTime(1995, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Christinachester", new DateTime(2022, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gambia", 1, "employee10@hrsm.com", "Jarrod", 1, "Elton", "12345678901234", "12345678", 212722.0, "Mireille Crossing", null },
                    { 11, 21, new DateTime(1996, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Wendyport", new DateTime(2023, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mexico", 3, "employee11@hrsm.com", "Destiny", 1, "Trisha", "12345678901234", "12345678", 212686.0, "Johnson Forge", null },
                    { 12, 21, new DateTime(1993, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Heaneyberg", new DateTime(2022, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Barbados", 3, "employee12@hrsm.com", "Olin", 0, "Everette", "12345678901234", "12345678", 300193.0, "Caitlyn Port", null },
                    { 13, 21, new DateTime(1995, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Kassandra", new DateTime(2022, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint Vincent and the Grenadines", 3, "employee13@hrsm.com", "Paxton", 1, "Electa", "12345678901234", "12345678", 275545.0, "Hilll Crest", null },
                    { 14, 21, new DateTime(1997, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Willard", new DateTime(2022, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uganda", 3, "employee14@hrsm.com", "Jayden", 0, "Gus", "12345678901234", "12345678", 334106.0, "Anderson Views", null },
                    { 15, 21, new DateTime(1993, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Danialborough", new DateTime(2022, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Latvia", 2, "employee15@hrsm.com", "Destany", 1, "Leonie", "12345678901234", "12345678", 170403.0, "Mekhi Forge", null },
                    { 16, 21, new DateTime(1995, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zoiebury", new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Congo", 2, "employee16@hrsm.com", "Isaias", 0, "Glen", "12345678901234", "12345678", 247431.0, "Tyson Way", null },
                    { 17, 21, new DateTime(1995, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Port Zeldafort", new DateTime(2022, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iceland", 3, "employee17@hrsm.com", "Dorthy", 0, "Granville", "12345678901234", "12345678", 359214.0, "Mohr Mountain", null },
                    { 18, 21, new DateTime(1994, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Darwin", new DateTime(2020, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Kingdom", 1, "employee18@hrsm.com", "Roxane", 1, "Tommie", "12345678901234", "12345678", 201763.0, "Block Streets", null },
                    { 19, 21, new DateTime(1992, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Bradleymouth", new DateTime(2023, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cameroon", 1, "employee19@hrsm.com", "Raul", 0, "Tiara", "12345678901234", "12345678", 395909.0, "Walsh Skyway", null },
                    { 20, 21, new DateTime(1993, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Port Isomburgh", new DateTime(2022, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bhutan", 1, "employee20@hrsm.com", "Raven", 1, "Rosanna", "12345678901234", "12345678", 203037.0, "Dillon Throughway", null },
                    { 21, 21, new DateTime(1994, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Watershaven", new DateTime(2022, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "San Marino", 3, "employee21@hrsm.com", "Adrain", 0, "Randi", "12345678901234", "12345678", 48721.0, "Matt Crest", null },
                    { 22, 21, new DateTime(1993, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Talonborough", new DateTime(2022, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Portugal", 2, "employee22@hrsm.com", "Cristobal", 1, "Tad", "12345678901234", "12345678", 451102.0, "Buckridge Dam", null },
                    { 23, 21, new DateTime(1990, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fadelton", new DateTime(2020, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cameroon", 3, "employee23@hrsm.com", "Reanna", 0, "Yoshiko", "12345678901234", "12345678", 357435.0, "Adams Coves", null },
                    { 24, 21, new DateTime(1998, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ryanhaven", new DateTime(2022, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Turks and Caicos Islands", 3, "employee24@hrsm.com", "Berta", 1, "Joey", "12345678901234", "12345678", 125594.0, "Walsh Path", null },
                    { 25, 21, new DateTime(1995, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trantowview", new DateTime(2022, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabon", 1, "employee25@hrsm.com", "Hank", 1, "Gaston", "12345678901234", "12345678", 90754.0, "Stanton Divide", null },
                    { 26, 21, new DateTime(1992, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fridafurt", new DateTime(2022, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bahamas", 3, "employee26@hrsm.com", "Charles", 1, "Freda", "12345678901234", "12345678", 452820.0, "Runolfsson Highway", null },
                    { 27, 21, new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Loycetown", new DateTime(2021, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anguilla", 3, "employee27@hrsm.com", "Weldon", 0, "Ellsworth", "12345678901234", "12345678", 224585.0, "Alexys Light", null },
                    { 28, 21, new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sengerberg", new DateTime(2022, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Greenland", 2, "employee28@hrsm.com", "Randall", 0, "Odie", "12345678901234", "12345678", 182602.0, "Germaine Stravenue", null },
                    { 29, 21, new DateTime(1992, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Curtisside", new DateTime(2023, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brazil", 1, "employee29@hrsm.com", "Wilton", 0, "Pablo", "12345678901234", "12345678", 82769.0, "Darrick Turnpike", null },
                    { 30, 21, new DateTime(1990, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Luciano", new DateTime(2022, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Arab Emirates", 1, "employee30@hrsm.com", "Kathryne", 0, "Gregoria", "12345678901234", "12345678", 97273.0, "Ladarius Ports", null },
                    { 31, 21, new DateTime(1998, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Zoe", new DateTime(2021, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cambodia", 3, "employee31@hrsm.com", "Edgardo", 1, "Mathew", "12345678901234", "12345678", 114275.0, "Swaniawski Crossroad", null },
                    { 32, 21, new DateTime(1996, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Ariel", new DateTime(2022, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint Lucia", 2, "employee32@hrsm.com", "Dudley", 0, "Lorenz", "12345678901234", "12345678", 398911.0, "Mae Green", null },
                    { 33, 21, new DateTime(1992, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dibbertberg", new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Palau", 3, "employee33@hrsm.com", "Thora", 1, "Mozell", "12345678901234", "12345678", 23514.0, "Rhea Mews", null },
                    { 34, 21, new DateTime(2000, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Charlieborough", new DateTime(2021, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uzbekistan", 2, "employee34@hrsm.com", "Bernie", 1, "Angie", "12345678901234", "12345678", 497478.0, "Paucek Pass", null },
                    { 35, 21, new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Brannon", new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eritrea", 1, "employee35@hrsm.com", "Berniece", 0, "Gaston", "12345678901234", "12345678", 369083.0, "Mable Meadow", null },
                    { 36, 21, new DateTime(1991, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Ciara", new DateTime(2022, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bangladesh", 3, "employee36@hrsm.com", "Leonie", 1, "Etha", "12345678901234", "12345678", 181746.0, "Carter Pine", null },
                    { 37, 21, new DateTime(1991, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Delilah", new DateTime(2022, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "British Virgin Islands", 3, "employee37@hrsm.com", "Sydney", 0, "Jamaal", "12345678901234", "12345678", 76024.0, "Roosevelt Well", null },
                    { 38, 21, new DateTime(1996, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Cristopherport", new DateTime(2022, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Svalbard & Jan Mayen Islands", 3, "employee38@hrsm.com", "Ashleigh", 0, "Carroll", "12345678901234", "12345678", 160526.0, "Bartoletti Rest", null },
                    { 39, 21, new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Leannonberg", new DateTime(2020, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cuba", 3, "employee39@hrsm.com", "Eliseo", 1, "Parker", "12345678901234", "12345678", 419117.0, "Larson Garden", null },
                    { 40, 21, new DateTime(2000, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dibbertberg", new DateTime(2020, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vanuatu", 2, "employee40@hrsm.com", "Kristin", 0, "Brian", "12345678901234", "12345678", 430265.0, "Lane Brooks", null },
                    { 41, 21, new DateTime(1994, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Port Wymanside", new DateTime(2020, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marshall Islands", 2, "employee41@hrsm.com", "Milan", 1, "Abigayle", "12345678901234", "12345678", 226701.0, "Hermiston Vista", null },
                    { 42, 21, new DateTime(1991, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nicolasport", new DateTime(2021, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panama", 1, "employee42@hrsm.com", "Jannie", 1, "Brenden", "12345678901234", "12345678", 14939.0, "Connelly Street", null },
                    { 43, 21, new DateTime(1993, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Bailey", new DateTime(2023, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Myanmar", 1, "employee43@hrsm.com", "Quinton", 1, "Vernon", "12345678901234", "12345678", 289495.0, "Olson Inlet", null },
                    { 44, 21, new DateTime(1991, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Giovannitown", new DateTime(2021, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gambia", 1, "employee44@hrsm.com", "Ahmad", 1, "Kacey", "12345678901234", "12345678", 7086.0, "Freeman Vista", null },
                    { 45, 21, new DateTime(1997, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Citlallifort", new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Angola", 2, "employee45@hrsm.com", "Nathan", 0, "Keira", "12345678901234", "12345678", 450754.0, "Marge Village", null },
                    { 46, 21, new DateTime(1993, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Bernardo", new DateTime(2022, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finland", 2, "employee46@hrsm.com", "Amie", 1, "Juliet", "12345678901234", "12345678", 309569.0, "Alana Vista", null },
                    { 47, 21, new DateTime(1993, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Destinshire", new DateTime(2023, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Montenegro", 1, "employee47@hrsm.com", "Bettie", 0, "Arnold", "12345678901234", "12345678", 304288.0, "Kendrick Bypass", null },
                    { 48, 21, new DateTime(1997, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yundtfort", new DateTime(2020, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saudi Arabia", 1, "employee48@hrsm.com", "Dion", 0, "Mike", "12345678901234", "12345678", 403086.0, "Hardy Canyon", null },
                    { 49, 21, new DateTime(1997, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Rozella", new DateTime(2022, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cayman Islands", 1, "employee49@hrsm.com", "Alberto", 0, "Garrett", "12345678901234", "12345678", 12504.0, "Ismael Gateway", null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Employees",
                columns: new[] { "Id", "AvailableVacations", "BirthDate", "City", "ContractDate", "Country", "DeptID", "Email", "FirstName", "Gender", "LastName", "NationalId", "Password", "Salary", "Street", "UserId" },
                values: new object[] { 50, 21, new DateTime(1994, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Sandrineland", new DateTime(2021, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Swaziland", 3, "employee50@hrsm.com", "Maximillia", 1, "Ethel", "12345678901234", "12345678", 103320.0, "Rosenbaum Villages", null });

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
                name: "IX_PhoneNumbers_EmployeeId",
                schema: "dbo",
                table: "PhoneNumbers",
                column: "EmployeeId");

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
                name: "PhoneNumbers",
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
