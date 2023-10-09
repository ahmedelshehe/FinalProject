using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Migrations
{
    public partial class init : Migration
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
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                values: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7210", "c356629c-101d-4231-8857-77f7b9e1bd9a", "Adminstrator", null });

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
                    { 1, 21, new DateTime(1991, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Lamarburgh", new DateTime(2022, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "British Indian Ocean Territory (Chagos Archipelago)", 3, "employee1@hrsm.com", "Selmer", 1, "Paula", "12345678901234", "12345678", 474907.0, "Dibbert Station", null },
                    { 2, 21, new DateTime(1990, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Cliftonfurt", new DateTime(2021, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fiji", 1, "employee2@hrsm.com", "Deron", 1, "Archibald", "12345678901234", "12345678", 40006.0, "Shakira Haven", null },
                    { 3, 21, new DateTime(2000, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Mariana", new DateTime(2021, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cameroon", 2, "employee3@hrsm.com", "Hans", 1, "Litzy", "12345678901234", "12345678", 430712.0, "Yessenia Stravenue", null },
                    { 4, 21, new DateTime(2002, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yostland", new DateTime(2023, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Africa", 1, "employee4@hrsm.com", "Mathilde", 1, "Malika", "12345678901234", "12345678", 15795.0, "Robel Hollow", null },
                    { 5, 21, new DateTime(1991, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Strosinborough", new DateTime(2023, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ethiopia", 1, "employee5@hrsm.com", "Glen", 1, "Melyssa", "12345678901234", "12345678", 198120.0, "Torphy Ports", null },
                    { 6, 21, new DateTime(1997, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thompsonchester", new DateTime(2022, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Macao", 1, "employee6@hrsm.com", "Katrine", 0, "Lauriane", "12345678901234", "12345678", 123890.0, "Buckridge Plaza", null },
                    { 7, 21, new DateTime(1995, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nolanbury", new DateTime(2022, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Solomon Islands", 1, "employee7@hrsm.com", "Modesta", 1, "Jaida", "12345678901234", "12345678", 286782.0, "Koch Roads", null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Employees",
                columns: new[] { "Id", "AvailableVacations", "BirthDate", "City", "ContractDate", "Country", "DeptID", "Email", "FirstName", "Gender", "LastName", "NationalId", "Password", "Salary", "Street", "UserId" },
                values: new object[,]
                {
                    { 8, 21, new DateTime(1990, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Frances", new DateTime(2022, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chad", 1, "employee8@hrsm.com", "Hailie", 0, "Icie", "12345678901234", "12345678", 271066.0, "Tyshawn Place", null },
                    { 9, 21, new DateTime(1992, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Royal", new DateTime(2022, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bermuda", 3, "employee9@hrsm.com", "Clemens", 1, "Nash", "12345678901234", "12345678", 358882.0, "O'Kon Harbor", null },
                    { 10, 21, new DateTime(2001, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Brisachester", new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mauritius", 3, "employee10@hrsm.com", "Zaria", 1, "Meredith", "12345678901234", "12345678", 150608.0, "Schmeler Trail", null },
                    { 11, 21, new DateTime(1994, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Erickton", new DateTime(2021, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nigeria", 1, "employee11@hrsm.com", "Rogelio", 1, "Jedediah", "12345678901234", "12345678", 489533.0, "Feest Light", null },
                    { 12, 21, new DateTime(1991, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Port Amieport", new DateTime(2022, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lao People's Democratic Republic", 3, "employee12@hrsm.com", "Elody", 0, "Lennie", "12345678901234", "12345678", 485044.0, "Jayce Fields", null },
                    { 13, 21, new DateTime(1997, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Judgechester", new DateTime(2023, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Albania", 3, "employee13@hrsm.com", "Armando", 0, "Kaleigh", "12345678901234", "12345678", 158034.0, "Kuvalis Center", null },
                    { 14, 21, new DateTime(1998, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Eldon", new DateTime(2023, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bermuda", 2, "employee14@hrsm.com", "Raleigh", 1, "Suzanne", "12345678901234", "12345678", 274075.0, "Altenwerth Fork", null },
                    { 15, 21, new DateTime(2001, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Blandastad", new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tunisia", 1, "employee15@hrsm.com", "Ceasar", 1, "Santina", "12345678901234", "12345678", 427664.0, "Shane Mission", null },
                    { 16, 21, new DateTime(1993, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Margaretefort", new DateTime(2022, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bolivia", 2, "employee16@hrsm.com", "Charlie", 0, "Hosea", "12345678901234", "12345678", 281389.0, "Orn Drive", null },
                    { 17, 21, new DateTime(2001, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Darron", new DateTime(2023, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Turkmenistan", 1, "employee17@hrsm.com", "Flavio", 1, "Stephen", "12345678901234", "12345678", 298697.0, "Upton Dale", null },
                    { 18, 21, new DateTime(1991, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lemkeborough", new DateTime(2020, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malawi", 1, "employee18@hrsm.com", "Augustine", 0, "Brandy", "12345678901234", "12345678", 481499.0, "Asia Brooks", null },
                    { 19, 21, new DateTime(1992, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gaylordton", new DateTime(2020, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uzbekistan", 1, "employee19@hrsm.com", "Catalina", 1, "Allene", "12345678901234", "12345678", 470201.0, "Ellis Plains", null },
                    { 20, 21, new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Maxine", new DateTime(2022, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Russian Federation", 3, "employee20@hrsm.com", "Constance", 0, "Jackie", "12345678901234", "12345678", 8017.0, "Eliza Burgs", null },
                    { 21, 21, new DateTime(2002, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Lura", new DateTime(2023, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trinidad and Tobago", 3, "employee21@hrsm.com", "Mortimer", 1, "Lionel", "12345678901234", "12345678", 132602.0, "Michele Park", null },
                    { 22, 21, new DateTime(2002, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Zane", new DateTime(2021, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iran", 3, "employee22@hrsm.com", "Toni", 1, "Davonte", "12345678901234", "12345678", 403661.0, "Wilber Plains", null },
                    { 23, 21, new DateTime(1992, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kittyton", new DateTime(2023, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Greenland", 1, "employee23@hrsm.com", "Pearline", 1, "Ford", "12345678901234", "12345678", 146501.0, "Jacklyn Locks", null },
                    { 24, 21, new DateTime(1990, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Jakayla", new DateTime(2023, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Netherlands Antilles", 3, "employee24@hrsm.com", "Loyce", 0, "Neal", "12345678901234", "12345678", 476114.0, "Sincere Lakes", null },
                    { 25, 21, new DateTime(1991, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Port Jerad", new DateTime(2022, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "British Virgin Islands", 2, "employee25@hrsm.com", "Edgar", 0, "Althea", "12345678901234", "12345678", 343620.0, "Hillary Stream", null },
                    { 26, 21, new DateTime(1995, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Port Jaidenmouth", new DateTime(2022, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nauru", 2, "employee26@hrsm.com", "Vida", 0, "Lempi", "12345678901234", "12345678", 87038.0, "Steuber Stravenue", null },
                    { 27, 21, new DateTime(1999, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Marleemouth", new DateTime(2021, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spain", 3, "employee27@hrsm.com", "Twila", 1, "Ryley", "12345678901234", "12345678", 463567.0, "Donnell Estate", null },
                    { 28, 21, new DateTime(1999, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Blake", new DateTime(2022, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Afghanistan", 2, "employee28@hrsm.com", "Derek", 1, "Wilber", "12345678901234", "12345678", 244754.0, "Langosh Ports", null },
                    { 29, 21, new DateTime(2002, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Elmo", new DateTime(2021, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mauritius", 3, "employee29@hrsm.com", "Harvey", 0, "Clyde", "12345678901234", "12345678", 451443.0, "Lesch Stream", null },
                    { 30, 21, new DateTime(1992, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Kali", new DateTime(2020, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Argentina", 1, "employee30@hrsm.com", "Westley", 0, "Genevieve", "12345678901234", "12345678", 271194.0, "Shanie Junction", null },
                    { 31, 21, new DateTime(1993, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Peytonview", new DateTime(2022, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liechtenstein", 1, "employee31@hrsm.com", "Murray", 1, "Yasmine", "12345678901234", "12345678", 77609.0, "Paul Street", null },
                    { 32, 21, new DateTime(1999, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Diamond", new DateTime(2022, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nepal", 3, "employee32@hrsm.com", "Dallas", 0, "Dashawn", "12345678901234", "12345678", 129567.0, "Jeremie Ports", null },
                    { 33, 21, new DateTime(1991, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rosemariehaven", new DateTime(2021, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iran", 2, "employee33@hrsm.com", "Macey", 0, "Earlene", "12345678901234", "12345678", 219389.0, "Lance Ridge", null },
                    { 34, 21, new DateTime(1992, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Batzburgh", new DateTime(2022, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint Barthelemy", 2, "employee34@hrsm.com", "Dessie", 0, "Jane", "12345678901234", "12345678", 233009.0, "Brady Club", null },
                    { 35, 21, new DateTime(1999, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Port Emanuel", new DateTime(2021, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reunion", 1, "employee35@hrsm.com", "Abe", 1, "Alena", "12345678901234", "12345678", 11490.0, "Destinee Loop", null },
                    { 36, 21, new DateTime(1991, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zulaufchester", new DateTime(2022, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Afghanistan", 3, "employee36@hrsm.com", "Heloise", 1, "Mina", "12345678901234", "12345678", 28581.0, "Wyman Turnpike", null },
                    { 37, 21, new DateTime(1996, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Chad", new DateTime(2022, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anguilla", 1, "employee37@hrsm.com", "Ryley", 0, "Carey", "12345678901234", "12345678", 345167.0, "Von Dam", null },
                    { 38, 21, new DateTime(1998, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Maggiebury", new DateTime(2022, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Isle of Man", 2, "employee38@hrsm.com", "Theodore", 0, "Christy", "12345678901234", "12345678", 213621.0, "Nathaniel Inlet", null },
                    { 39, 21, new DateTime(1993, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Port Dorthashire", new DateTime(2020, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint Pierre and Miquelon", 1, "employee39@hrsm.com", "Fabian", 1, "Naomi", "12345678901234", "12345678", 80575.0, "Rodrigo Inlet", null },
                    { 40, 21, new DateTime(1999, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Dayne", new DateTime(2020, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bahamas", 1, "employee40@hrsm.com", "Zita", 1, "Zachery", "12345678901234", "12345678", 61513.0, "Kihn Prairie", null },
                    { 41, 21, new DateTime(1994, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lincolnchester", new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gibraltar", 1, "employee41@hrsm.com", "Rylan", 0, "Allen", "12345678901234", "12345678", 498801.0, "Heidi Pass", null },
                    { 42, 21, new DateTime(1991, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reingermouth", new DateTime(2022, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moldova", 3, "employee42@hrsm.com", "Tod", 1, "Emerald", "12345678901234", "12345678", 158949.0, "Gerlach Streets", null },
                    { 43, 21, new DateTime(1992, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Runolfssonberg", new DateTime(2022, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brazil", 1, "employee43@hrsm.com", "Max", 1, "Burnice", "12345678901234", "12345678", 370711.0, "Wisoky Summit", null },
                    { 44, 21, new DateTime(1990, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maudetown", new DateTime(2021, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malawi", 3, "employee44@hrsm.com", "Dane", 1, "Odie", "12345678901234", "12345678", 497118.0, "Schneider Orchard", null },
                    { 45, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Kelton", new DateTime(2022, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Niue", 1, "employee45@hrsm.com", "Hans", 1, "Dortha", "12345678901234", "12345678", 218499.0, "Barton Ramp", null },
                    { 46, 21, new DateTime(1990, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sengerborough", new DateTime(2021, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bulgaria", 3, "employee46@hrsm.com", "Harmon", 1, "Benton", "12345678901234", "12345678", 51933.0, "Pollich Trail", null },
                    { 47, 21, new DateTime(2000, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rutherfordport", new DateTime(2022, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zimbabwe", 3, "employee47@hrsm.com", "Betty", 0, "Ted", "12345678901234", "12345678", 69365.0, "Bailey Manors", null },
                    { 48, 21, new DateTime(1991, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ambrosechester", new DateTime(2020, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sudan", 2, "employee48@hrsm.com", "Freeman", 1, "Orland", "12345678901234", "12345678", 364749.0, "Santina Locks", null },
                    { 49, 21, new DateTime(1994, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Farrellton", new DateTime(2022, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denmark", 2, "employee49@hrsm.com", "Felix", 1, "Julia", "12345678901234", "12345678", 226304.0, "Jaskolski Ways", null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Employees",
                columns: new[] { "Id", "AvailableVacations", "BirthDate", "City", "ContractDate", "Country", "DeptID", "Email", "FirstName", "Gender", "LastName", "NationalId", "Password", "Salary", "Street", "UserId" },
                values: new object[] { 50, 21, new DateTime(1997, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Carolinastad", new DateTime(2021, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kyrgyz Republic", 3, "employee50@hrsm.com", "Troy", 1, "Enrico", "12345678901234", "12345678", 261011.0, "Kohler Lodge", null });

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
