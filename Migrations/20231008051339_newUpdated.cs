using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Migrations
{
    public partial class newUpdated : Migration
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
                values: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7210", "2c4f0911-a4ab-4a43-9b29-f1548554a62e", "Adminstrator", null });

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
                    { -49, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Heidenreichmouth", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Niger", -4, "employee-49@example.com", "Leann", 0, "Rowena", "12345678901234", "12345678", 91550.0, "Bonnie Shoals", null },
                    { -48, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Sybleburgh", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Africa", -1, "employee-48@example.com", "Jett", 1, "Winston", "12345678901234", "12345678", 366276.0, "Schaden Square", null },
                    { -47, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Faye", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Serbia", -1, "employee-47@example.com", "Krystina", 1, "Madelynn", "12345678901234", "12345678", 310111.0, "Rowan Courts", null },
                    { -46, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Runtetown", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Botswana", -1, "employee-46@example.com", "Jazmin", 1, "Sean", "12345678901234", "12345678", 69268.0, "Ritchie Islands", null },
                    { -45, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Burdette", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Niger", -2, "employee-45@example.com", "Berniece", 1, "Jammie", "12345678901234", "12345678", 466664.0, "McClure Crescent", null },
                    { -44, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Swaniawskiland", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Solomon Islands", -2, "employee-44@example.com", "Shanel", 1, "Mylene", "12345678901234", "12345678", 316217.0, "Bradley Track", null },
                    { -43, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uptonland", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liberia", -1, "employee-43@example.com", "Imogene", 0, "Laila", "12345678901234", "12345678", 383258.0, "Kshlerin Centers", null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Employees",
                columns: new[] { "Id", "AvailableVacations", "BirthDate", "City", "ContractDate", "Country", "DeptID", "Email", "FirstName", "Gender", "LastName", "NationalId", "Password", "Salary", "Street", "UserId" },
                values: new object[,]
                {
                    { -42, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Hectortown", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guadeloupe", -1, "employee-42@example.com", "Beaulah", 1, "Montana", "12345678901234", "12345678", 355656.0, "O'Keefe Court", null },
                    { -41, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dietrichstad", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vietnam", -1, "employee-41@example.com", "Myrtie", 0, "Mark", "12345678901234", "12345678", 303068.0, "Borer Pines", null },
                    { -40, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Dariana", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Djibouti", -3, "employee-40@example.com", "Zachariah", 0, "Abdullah", "12345678901234", "12345678", 39467.0, "Berniece Row", null },
                    { -39, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Zakaryhaven", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pitcairn Islands", -3, "employee-39@example.com", "Patience", 1, "Clement", "12345678901234", "12345678", 154166.0, "Fabiola Hollow", null },
                    { -38, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ziemefort", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jersey", -2, "employee-38@example.com", "Vance", 1, "Katharina", "12345678901234", "12345678", 68209.0, "Fritz Loop", null },
                    { -37, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Lonny", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Argentina", -3, "employee-37@example.com", "Reid", 1, "Eliseo", "12345678901234", "12345678", 315850.0, "Joe Cliff", null },
                    { -36, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Mya", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabon", -3, "employee-36@example.com", "Otilia", 0, "Yesenia", "12345678901234", "12345678", 105708.0, "Albina Way", null },
                    { -35, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Emmett", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guinea", -1, "employee-35@example.com", "Stuart", 1, "Demario", "12345678901234", "12345678", 442098.0, "Kirlin Cliff", null },
                    { -34, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Katelynnburgh", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guernsey", -3, "employee-34@example.com", "Hulda", 1, "Tristin", "12345678901234", "12345678", 267990.0, "Goodwin Track", null },
                    { -33, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Marjolaine", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Algeria", -4, "employee-33@example.com", "Claud", 0, "Tre", "12345678901234", "12345678", 93811.0, "Zachariah Shoals", null },
                    { -32, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Marjolainechester", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Israel", -4, "employee-32@example.com", "Dalton", 0, "Marcia", "12345678901234", "12345678", 131309.0, "Penelope Burgs", null },
                    { -31, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Powlowskiberg", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Singapore", -2, "employee-31@example.com", "Sadie", 1, "George", "12345678901234", "12345678", 302042.0, "McDermott Coves", null },
                    { -30, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Gildaborough", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiribati", -4, "employee-30@example.com", "Isabelle", 1, "Cordia", "12345678901234", "12345678", 473491.0, "Zieme Port", null },
                    { -29, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Dustybury", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kiribati", -2, "employee-29@example.com", "Irving", 0, "Ezekiel", "12345678901234", "12345678", 278190.0, "Bergstrom Parkway", null },
                    { -28, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Herthabury", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nigeria", -2, "employee-28@example.com", "Kathryn", 1, "Skyla", "12345678901234", "12345678", 272277.0, "Windler Loaf", null },
                    { -27, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Simeon", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cyprus", -2, "employee-27@example.com", "Deven", 1, "Royce", "12345678901234", "12345678", 137062.0, "Elnora Ports", null },
                    { -26, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bruenburgh", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Czech Republic", -1, "employee-26@example.com", "Shayne", 0, "Kadin", "12345678901234", "12345678", 119603.0, "Meghan River", null },
                    { -25, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "McGlynnfort", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andorra", -3, "employee-25@example.com", "Baby", 1, "Ruthie", "12345678901234", "12345678", 249725.0, "Goldner Wells", null },
                    { -24, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wolfburgh", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Papua New Guinea", -4, "employee-24@example.com", "Myrl", 0, "Berniece", "12345678901234", "12345678", 318461.0, "Collin Spur", null },
                    { -23, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Valerieshire", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "France", -4, "employee-23@example.com", "Branson", 0, "Jabari", "12345678901234", "12345678", 315125.0, "Millie Fall", null },
                    { -22, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Geovanni", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denmark", -4, "employee-22@example.com", "Santos", 0, "Electa", "12345678901234", "12345678", 244180.0, "Lisandro Burg", null },
                    { -21, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Leuschketown", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gabon", -2, "employee-21@example.com", "Elisabeth", 1, "Elena", "12345678901234", "12345678", 225018.0, "Dooley Knolls", null },
                    { -20, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Micaelaside", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Papua New Guinea", -2, "employee-20@example.com", "Charles", 0, "Caesar", "12345678901234", "12345678", 100277.0, "Zelda Springs", null },
                    { -19, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Port Rod", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dominican Republic", -1, "employee-19@example.com", "Abraham", 0, "Renee", "12345678901234", "12345678", 180635.0, "Marquardt Extension", null },
                    { -18, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Christiansenton", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jamaica", -3, "employee-18@example.com", "Justyn", 1, "Damaris", "12345678901234", "12345678", 71457.0, "Cole Divide", null },
                    { -17, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bernadinemouth", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "British Virgin Islands", -2, "employee-17@example.com", "Denis", 0, "Myah", "12345678901234", "12345678", 243153.0, "Homenick Cape", null },
                    { -16, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Amir", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kazakhstan", -1, "employee-16@example.com", "Vida", 1, "Eduardo", "12345678901234", "12345678", 156077.0, "Adella Ridges", null },
                    { -15, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Delmer", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Israel", -4, "employee-15@example.com", "Keenan", 1, "Daren", "12345678901234", "12345678", 135213.0, "Triston Land", null },
                    { -14, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Isaiahstad", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Antigua and Barbuda", -2, "employee-14@example.com", "Gladys", 0, "Rhett", "12345678901234", "12345678", 403016.0, "Blanca Falls", null },
                    { -13, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alexandraside", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Romania", -1, "employee-13@example.com", "Janelle", 0, "Norwood", "12345678901234", "12345678", 472163.0, "Jerry Fields", null },
                    { -12, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Josephineport", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Belarus", -4, "employee-12@example.com", "Cullen", 1, "Cruz", "12345678901234", "12345678", 254215.0, "Michale Stream", null },
                    { -11, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Holdenchester", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kazakhstan", -3, "employee-11@example.com", "Cara", 0, "Shaun", "12345678901234", "12345678", 89645.0, "Annabel Walks", null },
                    { -10, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Krischester", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saudi Arabia", -3, "employee-10@example.com", "Estrella", 0, "Foster", "12345678901234", "12345678", 28204.0, "Hermann Forge", null },
                    { -9, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Otho", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Korea", -4, "employee-9@example.com", "Chesley", 1, "Ernie", "12345678901234", "12345678", 54544.0, "Kutch Crest", null },
                    { -8, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Sammy", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cote d'Ivoire", -4, "employee-8@example.com", "Maximus", 0, "Abagail", "12345678901234", "12345678", 79687.0, "Weimann Run", null },
                    { -7, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Rey", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint Vincent and the Grenadines", -4, "employee-7@example.com", "Imogene", 0, "Elisha", "12345678901234", "12345678", 420077.0, "Freda Mission", null },
                    { -6, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Ebba", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mali", -4, "employee-6@example.com", "Nella", 0, "Wiley", "12345678901234", "12345678", 134135.0, "Kailee Greens", null },
                    { -5, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Newell", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andorra", -2, "employee-5@example.com", "Ryder", 1, "Ima", "12345678901234", "12345678", 403965.0, "Zulauf Alley", null },
                    { -4, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saraiburgh", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guinea", -2, "employee-4@example.com", "Phyllis", 1, "Kasey", "12345678901234", "12345678", 338250.0, "Ferry Isle", null },
                    { -3, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Faheyton", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Zealand", -3, "employee-3@example.com", "Rahul", 1, "Hellen", "12345678901234", "12345678", 469874.0, "Hane Loop", null },
                    { -2, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Port Abdul", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Togo", -1, "employee-2@example.com", "Mack", 0, "Althea", "12345678901234", "12345678", 364261.0, "Rosendo Dale", null },
                    { -1, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hellenmouth", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Burundi", -3, "employee-1@example.com", "Dwight", 1, "Jimmy", "12345678901234", "12345678", 84064.0, "Jazlyn Branch", null }
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
