using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Migrations
{
    public partial class reportUpdate : Migration
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
                values: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7210", "af5e0bd5-5067-4925-8c72-1e4200c7fb11", "Adminstrator", null });

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
                    { -49, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lillianatown", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Slovenia", -2, "employee-49@example.com", "Gilberto", 0, "Matilda", "12345678901234", "12345678", 480615.0, "Deshaun Hollow", null },
                    { -48, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Evalynhaven", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Barbados", -3, "employee-48@example.com", "Andre", 1, "Tyler", "12345678901234", "12345678", 77567.0, "Padberg Corner", null },
                    { -47, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Goldnerland", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liechtenstein", -2, "employee-47@example.com", "Jettie", 0, "Chloe", "12345678901234", "12345678", 416180.0, "Mohr Meadow", null },
                    { -46, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Allanton", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nauru", -4, "employee-46@example.com", "Israel", 1, "Domingo", "12345678901234", "12345678", 145175.0, "Paul Falls", null },
                    { -45, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hirtheport", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Venezuela", -3, "employee-45@example.com", "Libbie", 1, "Kaleb", "12345678901234", "12345678", 253195.0, "Arden Mall", null },
                    { -44, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Ona", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chad", -2, "employee-44@example.com", "Quinn", 1, "Zora", "12345678901234", "12345678", 53490.0, "Marie Ports", null },
                    { -43, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Collierburgh", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Turks and Caicos Islands", -4, "employee-43@example.com", "Kendrick", 0, "Kelli", "12345678901234", "12345678", 123037.0, "Nitzsche Path", null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Employees",
                columns: new[] { "Id", "AvailableVacations", "BirthDate", "City", "ContractDate", "Country", "DeptID", "Email", "FirstName", "Gender", "LastName", "NationalId", "Password", "Salary", "Street", "UserId" },
                values: new object[,]
                {
                    { -42, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Candidamouth", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Belarus", -1, "employee-42@example.com", "Marcel", 1, "Broderick", "12345678901234", "12345678", 43677.0, "Rempel Cape", null },
                    { -41, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Giuseppe", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Northern Mariana Islands", -2, "employee-41@example.com", "Tyra", 1, "Buford", "12345678901234", "12345678", 33566.0, "Krystel Club", null },
                    { -40, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Schinnerberg", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint Barthelemy", -3, "employee-40@example.com", "Nathanial", 0, "Garett", "12345678901234", "12345678", 106463.0, "Vandervort Court", null },
                    { -39, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Port Lori", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mongolia", -4, "employee-39@example.com", "Brett", 1, "Pete", "12345678901234", "12345678", 383961.0, "Shanel Oval", null },
                    { -38, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Melynaville", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panama", -4, "employee-38@example.com", "Celine", 1, "Isaiah", "12345678901234", "12345678", 426072.0, "Shawn Trail", null },
                    { -37, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Whitetown", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gambia", -1, "employee-37@example.com", "Cortez", 1, "Concepcion", "12345678901234", "12345678", 393925.0, "Dorothy Trace", null },
                    { -36, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Krajcikport", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tokelau", -3, "employee-36@example.com", "Reynold", 0, "Laurie", "12345678901234", "12345678", 10001.0, "Jenifer Well", null },
                    { -35, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Aiden", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Arab Emirates", -4, "employee-35@example.com", "Alayna", 1, "Precious", "12345678901234", "12345678", 303527.0, "Timothy Terrace", null },
                    { -34, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Port Louie", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint Kitts and Nevis", -3, "employee-34@example.com", "Cameron", 0, "Theodora", "12345678901234", "12345678", 89993.0, "Ella Village", null },
                    { -33, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ortizport", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dominican Republic", -4, "employee-33@example.com", "Bria", 0, "Lonzo", "12345678901234", "12345678", 465770.0, "Johnson Ville", null },
                    { -32, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Seamus", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bahamas", -4, "employee-32@example.com", "Godfrey", 0, "Juston", "12345678901234", "12345678", 372647.0, "Braun Path", null },
                    { -31, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sofiastad", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Algeria", -4, "employee-31@example.com", "Jules", 1, "Destini", "12345678901234", "12345678", 423702.0, "Della Island", null },
                    { -30, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marshallside", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Norway", -1, "employee-30@example.com", "Emelia", 0, "Zoila", "12345678901234", "12345678", 112745.0, "Alessandra Drive", null },
                    { -29, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ebertfurt", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oman", -4, "employee-29@example.com", "Lucas", 0, "Ubaldo", "12345678901234", "12345678", 247731.0, "Lila River", null },
                    { -28, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Enos", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yemen", -4, "employee-28@example.com", "Roel", 1, "Veronica", "12345678901234", "12345678", 47359.0, "Prohaska Drives", null },
                    { -27, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Patside", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Portugal", -4, "employee-27@example.com", "Aditya", 1, "Eric", "12345678901234", "12345678", 103420.0, "Flatley Valleys", null },
                    { -26, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Evalyntown", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mauritania", -4, "employee-26@example.com", "Kian", 0, "Sabina", "12345678901234", "12345678", 125813.0, "Heloise Parks", null },
                    { -25, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Quitzonport", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Switzerland", -3, "employee-25@example.com", "Lynn", 0, "Hayley", "12345678901234", "12345678", 184223.0, "Lockman Glens", null },
                    { -24, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hamillhaven", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Liechtenstein", -2, "employee-24@example.com", "Lesly", 0, "Tre", "12345678901234", "12345678", 371068.0, "Romaguera Inlet", null },
                    { -23, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Princessberg", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sudan", -2, "employee-23@example.com", "Avery", 1, "Steve", "12345678901234", "12345678", 421568.0, "Becker Mountains", null },
                    { -22, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Blair", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Costa Rica", -2, "employee-22@example.com", "Hilton", 0, "Aaliyah", "12345678901234", "12345678", 473591.0, "Ellie Way", null },
                    { -21, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kubside", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trinidad and Tobago", -4, "employee-21@example.com", "Drake", 0, "Audie", "12345678901234", "12345678", 197810.0, "Hector Skyway", null },
                    { -20, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Loyalland", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cocos (Keeling) Islands", -1, "employee-20@example.com", "Misael", 1, "Antonette", "12345678901234", "12345678", 473553.0, "Haley Heights", null },
                    { -19, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Asaland", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marshall Islands", -2, "employee-19@example.com", "Jeanne", 1, "Alex", "12345678901234", "12345678", 480965.0, "Sylvia Ridge", null },
                    { -18, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Lizzie", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mali", -3, "employee-18@example.com", "Lester", 1, "Bulah", "12345678901234", "12345678", 240498.0, "Kessler Forge", null },
                    { -17, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Gisselleport", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Macedonia", -1, "employee-17@example.com", "Yoshiko", 1, "Velda", "12345678901234", "12345678", 225734.0, "Fahey Island", null },
                    { -16, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Erin", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Netherlands Antilles", -2, "employee-16@example.com", "Oran", 0, "Kevin", "12345678901234", "12345678", 250821.0, "Streich Inlet", null },
                    { -15, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dameonfort", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Belgium", -2, "employee-15@example.com", "Bridie", 0, "Sabryna", "12345678901234", "12345678", 282381.0, "Sawayn Extension", null },
                    { -14, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Mable", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Falkland Islands (Malvinas)", -1, "employee-14@example.com", "Presley", 1, "Rosa", "12345678901234", "12345678", 92606.0, "Lowe Valley", null },
                    { -13, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Port Elmirafurt", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denmark", -4, "employee-13@example.com", "Leila", 1, "Alfredo", "12345678901234", "12345678", 116578.0, "Collin Mountains", null },
                    { -12, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kulasville", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wallis and Futuna", -1, "employee-12@example.com", "Carli", 0, "Sabina", "12345678901234", "12345678", 375104.0, "Dominique Road", null },
                    { -11, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kuhicside", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denmark", -1, "employee-11@example.com", "Omer", 0, "Emmett", "12345678901234", "12345678", 293576.0, "Bosco Corners", null },
                    { -10, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Kariane", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Uzbekistan", -4, "employee-10@example.com", "Hubert", 1, "Shyanne", "12345678901234", "12345678", 77682.0, "Gulgowski View", null },
                    { -9, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Eveside", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sao Tome and Principe", -4, "employee-9@example.com", "Isac", 0, "Aidan", "12345678901234", "12345678", 296764.0, "Arturo Groves", null },
                    { -8, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Samantamouth", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Costa Rica", -2, "employee-8@example.com", "Wilber", 1, "Queenie", "12345678901234", "12345678", 189644.0, "Schaefer Flats", null },
                    { -7, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Toyburgh", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sri Lanka", -1, "employee-7@example.com", "Cecile", 0, "Annabelle", "12345678901234", "12345678", 251795.0, "Dahlia Via", null },
                    { -6, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Lea", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Puerto Rico", -4, "employee-6@example.com", "Marina", 0, "Lauretta", "12345678901234", "12345678", 135206.0, "Maggio Curve", null },
                    { -5, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Claudieside", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nicaragua", -2, "employee-5@example.com", "Rollin", 0, "Cornelius", "12345678901234", "12345678", 109779.0, "Douglas Port", null },
                    { -4, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Irvingburgh", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wallis and Futuna", -4, "employee-4@example.com", "Jayson", 1, "Kaelyn", "12345678901234", "12345678", 217411.0, "Becker Rapid", null },
                    { -3, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Noemiton", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Switzerland", -2, "employee-3@example.com", "Ocie", 1, "Edwin", "12345678901234", "12345678", 7371.0, "O'Keefe Green", null },
                    { -2, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Arlo", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Somalia", -2, "employee-2@example.com", "Armando", 0, "Ramon", "12345678901234", "12345678", 310171.0, "Cruickshank Ferry", null },
                    { -1, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Williamsonport", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sri Lanka", -1, "employee-1@example.com", "Tierra", 1, "Alvina", "12345678901234", "12345678", 285607.0, "Roberta Crossroad", null }
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
                name: "SettingViewModel",
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
                name: "WeeklyHolidays",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Permissions",
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
