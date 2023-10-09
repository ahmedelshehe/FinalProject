using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Migrations
{
    public partial class test : Migration
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
                    { -4, "Sales" },
                    { -3, "IT" },
                    { -2, "R & D" },
                    { -1, "HR" }
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
                    { -36, "Salary", 1 },
                    { -35, "GeneralSetting", 2 },
                    { -34, "GeneralSetting", 1 },
                    { -32, "Vacation", 0 },
                    { -31, "Vacation", 3 },
                    { -30, "Vacation", 2 },
                    { -29, "Vacation", 1 },
                    { -28, "OfficialVacation", 0 },
                    { -27, "OfficialVacation", 3 },
                    { -26, "OfficialVacation", 2 },
                    { -25, "OfficialVacation", 1 },
                    { -24, "Department", 0 },
                    { -23, "Department", 3 },
                    { -22, "Department", 2 },
                    { -21, "Department", 1 },
                    { -20, "Permission", 0 },
                    { -19, "Permission", 3 },
                    { -18, "Permission", 2 },
                    { -17, "Permission", 1 },
                    { -16, "AppUser", 0 },
                    { -15, "AppUser", 3 },
                    { -14, "AppUser", 2 },
                    { -13, "AppUser", 1 },
                    { -12, "AppRole", 0 },
                    { -11, "AppRole", 3 },
                    { -10, "AppRole", 2 },
                    { -9, "AppRole", 1 },
                    { -8, "Attendance", 0 },
                    { -7, "Attendance", 3 },
                    { -6, "Attendance", 2 },
                    { -5, "Attendance", 1 },
                    { -4, "Employee", 0 },
                    { -3, "Employee", 3 },
                    { -2, "Employee", 2 },
                    { -1, "Employee", 1 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7210", "0d199b49-dce7-40bb-aaf2-0c68e173a75a", "Adminstrator", null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppRolePermission",
                columns: new[] { "AppRolesId", "PermissionsId" },
                values: new object[,]
                {
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", -36 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", -35 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", -34 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", -32 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", -31 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", -30 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", -29 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", -28 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", -27 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", -26 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", -25 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", -24 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", -23 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", -22 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", -21 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", -20 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", -19 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", -18 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", -17 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", -16 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", -15 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", -14 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", -13 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", -12 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", -11 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", -10 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", -9 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", -8 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", -7 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", -6 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", -5 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", -4 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", -3 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", -2 },
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", -1 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Employees",
                columns: new[] { "Id", "AvailableVacations", "BirthDate", "City", "ContractDate", "Country", "DeptID", "Email", "FirstName", "Gender", "LastName", "NationalId", "Password", "Salary", "Street", "UserId" },
                values: new object[,]
                {
                    { -49, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jadatown", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pakistan", -2, "employee-49@example.com", "Elise", 0, "Javon", "12345678901234", "12345678", 298098.0, "Edd Summit", null },
                    { -48, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tillmanburgh", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mauritius", -2, "employee-48@example.com", "Saige", 0, "Karine", "12345678901234", "12345678", 218251.0, "Eda Meadows", null },
                    { -47, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Lizziestad", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Iraq", -2, "employee-47@example.com", "Jillian", 1, "Kamron", "12345678901234", "12345678", 158522.0, "Lemke Radial", null },
                    { -46, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Jennie", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zambia", -3, "employee-46@example.com", "Eliseo", 1, "Newell", "12345678901234", "12345678", 68253.0, "Albina Inlet", null },
                    { -45, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gorczanychester", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yemen", -1, "employee-45@example.com", "Dorian", 0, "Cecil", "12345678901234", "12345678", 367197.0, "Marvin Falls", null },
                    { -44, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Trycia", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "India", -2, "employee-44@example.com", "Juvenal", 0, "Amely", "12345678901234", "12345678", 203862.0, "Anastasia Summit", null },
                    { -43, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorenzoshire", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Israel", -2, "employee-43@example.com", "Bridie", 1, "Caleigh", "12345678901234", "12345678", 252453.0, "Johns Course", null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Employees",
                columns: new[] { "Id", "AvailableVacations", "BirthDate", "City", "ContractDate", "Country", "DeptID", "Email", "FirstName", "Gender", "LastName", "NationalId", "Password", "Salary", "Street", "UserId" },
                values: new object[,]
                {
                    { -42, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Ronaldo", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Africa", -1, "employee-42@example.com", "Michelle", 1, "Janessa", "12345678901234", "12345678", 203550.0, "Kris Valley", null },
                    { -41, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Whitehaven", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Czech Republic", -1, "employee-41@example.com", "Hiram", 1, "Frank", "12345678901234", "12345678", 425253.0, "Murazik Hills", null },
                    { -40, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Name", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Qatar", -2, "employee-40@example.com", "Magdalen", 0, "Kirsten", "12345678901234", "12345678", 458466.0, "Schroeder Point", null },
                    { -39, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cronaland", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chile", -1, "employee-39@example.com", "Monserrate", 0, "Jerry", "12345678901234", "12345678", 125630.0, "Gutmann Circle", null },
                    { -38, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Kiarra", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Montserrat", -3, "employee-38@example.com", "Deion", 0, "Glenna", "12345678901234", "12345678", 208274.0, "Xander Ridge", null },
                    { -37, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Letha", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bangladesh", -3, "employee-37@example.com", "Kailey", 1, "Jarvis", "12345678901234", "12345678", 242127.0, "Feil Gardens", null },
                    { -36, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kileyton", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sao Tome and Principe", -4, "employee-36@example.com", "Ollie", 0, "Gabriel", "12345678901234", "12345678", 463875.0, "Lina View", null },
                    { -35, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elouiseburgh", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brunei Darussalam", -2, "employee-35@example.com", "Guy", 1, "Leola", "12345678901234", "12345678", 36924.0, "Oswald Drives", null },
                    { -34, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rodriguezview", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Madagascar", -2, "employee-34@example.com", "Enoch", 0, "Sincere", "12345678901234", "12345678", 208042.0, "Norris Knolls", null },
                    { -33, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aubreeview", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nepal", -4, "employee-33@example.com", "Alexane", 0, "Judson", "12345678901234", "12345678", 195930.0, "Doyle Street", null },
                    { -32, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adamsfort", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hungary", -4, "employee-32@example.com", "Precious", 0, "Ericka", "12345678901234", "12345678", 290856.0, "Lambert Club", null },
                    { -31, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gislasonmouth", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thailand", -3, "employee-31@example.com", "Margarete", 1, "Vincenzo", "12345678901234", "12345678", 416182.0, "Rafael Grove", null },
                    { -30, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Leraton", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Madagascar", -1, "employee-30@example.com", "Justice", 0, "Gust", "12345678901234", "12345678", 71113.0, "Krystina Wall", null },
                    { -29, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harryberg", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Central African Republic", -1, "employee-29@example.com", "Nettie", 1, "Dave", "12345678901234", "12345678", 21018.0, "Griffin Place", null },
                    { -28, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Mikaylaberg", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nigeria", -3, "employee-28@example.com", "Salvador", 1, "Elliott", "12345678901234", "12345678", 66580.0, "Lang Mount", null },
                    { -27, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Myrtis", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Benin", -1, "employee-27@example.com", "Courtney", 0, "Terrell", "12345678901234", "12345678", 178963.0, "Cruz Camp", null },
                    { -26, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Vernon", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ethiopia", -1, "employee-26@example.com", "Caleigh", 1, "Dejuan", "12345678901234", "12345678", 469211.0, "Hane Lakes", null },
                    { -25, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bergnaumfurt", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Papua New Guinea", -4, "employee-25@example.com", "Ludwig", 0, "Rosalia", "12345678901234", "12345678", 348967.0, "Maeve Loaf", null },
                    { -24, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Allyberg", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uganda", -4, "employee-24@example.com", "Liam", 1, "Cordelia", "12345678901234", "12345678", 247120.0, "Carmine Pike", null },
                    { -23, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Mavisside", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Faroe Islands", -2, "employee-23@example.com", "Santos", 0, "Julien", "12345678901234", "12345678", 347592.0, "Idell Inlet", null },
                    { -22, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Douglasfort", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "India", -3, "employee-22@example.com", "Daniela", 0, "Carolanne", "12345678901234", "12345678", 37083.0, "Kulas Trail", null },
                    { -21, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Marinaland", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Korea", -1, "employee-21@example.com", "Dexter", 0, "Mathilde", "12345678901234", "12345678", 458116.0, "Gregg Hills", null },
                    { -20, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Ashleyside", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Germany", -4, "employee-20@example.com", "Camron", 0, "Meta", "12345678901234", "12345678", 90773.0, "Kyra Ways", null },
                    { -19, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Trevorberg", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jamaica", -2, "employee-19@example.com", "Andrew", 1, "Connor", "12345678901234", "12345678", 383913.0, "Bonita Streets", null },
                    { -18, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Rayville", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Argentina", -4, "employee-18@example.com", "Helga", 1, "Monserrate", "12345678901234", "12345678", 134125.0, "Asha Park", null },
                    { -17, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Antonietta", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mali", -3, "employee-17@example.com", "Micah", 1, "Kaden", "12345678901234", "12345678", 176220.0, "Sunny Heights", null },
                    { -16, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Casperborough", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Congo", -3, "employee-16@example.com", "Nick", 0, "Jorge", "12345678901234", "12345678", 333041.0, "Paucek View", null },
                    { -15, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Blazeton", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nigeria", -1, "employee-15@example.com", "Amelia", 1, "Juwan", "12345678901234", "12345678", 86291.0, "Morgan Turnpike", null },
                    { -14, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Hectorstad", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chile", -3, "employee-14@example.com", "Fletcher", 1, "Daisha", "12345678901234", "12345678", 11371.0, "Karlie Ridges", null },
                    { -13, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Jed", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "American Samoa", -1, "employee-13@example.com", "Sydnie", 1, "Maeve", "12345678901234", "12345678", 144856.0, "Daniel Manors", null },
                    { -12, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Khalidshire", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Israel", -1, "employee-12@example.com", "Marina", 0, "Kariane", "12345678901234", "12345678", 362259.0, "Ellie Ways", null },
                    { -11, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Schinnerfurt", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Namibia", -1, "employee-11@example.com", "Karen", 1, "Madalyn", "12345678901234", "12345678", 141978.0, "Aylin Vista", null },
                    { -10, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Dedricport", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bahamas", -1, "employee-10@example.com", "Eulah", 1, "Hazle", "12345678901234", "12345678", 17994.0, "Boyer Row", null },
                    { -9, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Rowland", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cameroon", -2, "employee-9@example.com", "Eddie", 0, "Chance", "12345678901234", "12345678", 42385.0, "Koepp Unions", null },
                    { -8, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Justina", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "British Virgin Islands", -2, "employee-8@example.com", "Elmore", 0, "Troy", "12345678901234", "12345678", 77392.0, "O'Kon Bridge", null },
                    { -7, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Port Waldo", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Switzerland", -2, "employee-7@example.com", "Sandrine", 1, "Justice", "12345678901234", "12345678", 30019.0, "Ledner Forks", null },
                    { -6, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Verniceburgh", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "French Polynesia", -1, "employee-6@example.com", "Liliane", 1, "Chauncey", "12345678901234", "12345678", 388342.0, "Nicklaus Mews", null },
                    { -5, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Port Maurinechester", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Niger", -4, "employee-5@example.com", "Bret", 1, "Estevan", "12345678901234", "12345678", 257963.0, "Hudson Prairie", null },
                    { -4, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fredton", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Senegal", -1, "employee-4@example.com", "Rosalind", 1, "Stephany", "12345678901234", "12345678", 268816.0, "Marion Mill", null },
                    { -3, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smithamberg", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Montserrat", -3, "employee-3@example.com", "Lamar", 1, "Norma", "12345678901234", "12345678", 155062.0, "Kattie Rest", null },
                    { -2, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Petratown", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zambia", -3, "employee-2@example.com", "Margarett", 0, "Shaniya", "12345678901234", "12345678", 76540.0, "Ratke Underpass", null },
                    { -1, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Port Lorenzoville", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Poland", -3, "employee-1@example.com", "Selena", 1, "Myra", "12345678901234", "12345678", 128140.0, "Afton Point", null }
                });

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
