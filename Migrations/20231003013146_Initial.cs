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
                    { -4, "Department 4" },
                    { -3, "Department 3" },
                    { -2, "Department 2" },
                    { -1, "Department 1" }
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
                values: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7210", "fad33632-ac58-4e22-a6fc-995ab8fe2a37", "Adminstrator", null });

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
                    { -49, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Murphyview", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Norfolk Island", -4, "employee-49@example.com", "Vinnie", 0, "Adolf", "12345678901234", "12345678", 302640.0, "Steuber Ridges", null },
                    { -48, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Reynachester", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malaysia", -3, "employee-48@example.com", "Zechariah", 0, "Marcella", "12345678901234", "12345678", 315847.0, "Parker Loaf", null },
                    { -47, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Marilyne", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sao Tome and Principe", -4, "employee-47@example.com", "Dion", 1, "Blaze", "12345678901234", "12345678", 57904.0, "Bogan Walk", null },
                    { -46, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Graycemouth", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Latvia", -1, "employee-46@example.com", "Weston", 1, "Tierra", "12345678901234", "12345678", 485268.0, "Renner Dale", null },
                    { -45, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Scotside", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Anguilla", -4, "employee-45@example.com", "Rolando", 1, "Lauryn", "12345678901234", "12345678", 347572.0, "Brandyn Mount", null },
                    { -44, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Alessandroside", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sweden", -3, "employee-44@example.com", "Velma", 0, "Yvette", "12345678901234", "12345678", 485357.0, "Lakin Expressway", null },
                    { -43, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Buddy", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Portugal", -4, "employee-43@example.com", "Edmond", 0, "Gust", "12345678901234", "12345678", 45217.0, "Krystel Avenue", null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Employees",
                columns: new[] { "Id", "AvailableVacations", "BirthDate", "City", "ContractDate", "Country", "DeptID", "Email", "FirstName", "Gender", "LastName", "NationalId", "Password", "Salary", "Street", "UserId" },
                values: new object[,]
                {
                    { -42, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gersonhaven", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guernsey", -1, "employee-42@example.com", "Bobby", 0, "Moses", "12345678901234", "12345678", 350527.0, "Ryder Square", null },
                    { -41, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Sophie", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cambodia", -1, "employee-41@example.com", "Elsie", 1, "Selmer", "12345678901234", "12345678", 38816.0, "Botsford Fork", null },
                    { -40, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ondrickamouth", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Macao", -4, "employee-40@example.com", "Willy", 0, "Vivian", "12345678901234", "12345678", 459713.0, "Bartell Courts", null },
                    { -39, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Jedborough", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Niger", -1, "employee-39@example.com", "Andre", 0, "Destiney", "12345678901234", "12345678", 348844.0, "Ralph Road", null },
                    { -38, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Braeden", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bolivia", -3, "employee-38@example.com", "Lucius", 0, "Brielle", "12345678901234", "12345678", 427952.0, "Irwin Burgs", null },
                    { -37, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Larryborough", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Latvia", -4, "employee-37@example.com", "Grayson", 1, "Kali", "12345678901234", "12345678", 253355.0, "Brekke Manors", null },
                    { -36, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Port Orrin", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Turks and Caicos Islands", -4, "employee-36@example.com", "Garth", 1, "Murray", "12345678901234", "12345678", 374847.0, "Pacocha Curve", null },
                    { -35, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Theresaview", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Greece", -2, "employee-35@example.com", "Brandyn", 0, "Estella", "12345678901234", "12345678", 258374.0, "Homenick Locks", null },
                    { -34, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bettyechester", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Congo", -4, "employee-34@example.com", "Elliot", 1, "Willie", "12345678901234", "12345678", 187011.0, "Ima Turnpike", null },
                    { -33, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Watersfurt", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "United States Virgin Islands", -4, "employee-33@example.com", "Brain", 0, "Karine", "12345678901234", "12345678", 202885.0, "Bode Ferry", null },
                    { -32, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Ewell", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Madagascar", -4, "employee-32@example.com", "Reymundo", 0, "Rossie", "12345678901234", "12345678", 110890.0, "Strosin Tunnel", null },
                    { -31, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Othaview", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cote d'Ivoire", -2, "employee-31@example.com", "Loy", 0, "Spencer", "12345678901234", "12345678", 476001.0, "Carter Passage", null },
                    { -30, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Grimesview", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kuwait", -2, "employee-30@example.com", "Melvina", 0, "Katharina", "12345678901234", "12345678", 169161.0, "Brekke Neck", null },
                    { -29, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Roobburgh", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wallis and Futuna", -1, "employee-29@example.com", "Nathen", 1, "Ahmad", "12345678901234", "12345678", 294342.0, "Derek Haven", null },
                    { -28, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gibsonmouth", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Philippines", -1, "employee-28@example.com", "Bella", 1, "Marcellus", "12345678901234", "12345678", 395425.0, "Schneider Mill", null },
                    { -27, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Boyleview", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Caledonia", -2, "employee-27@example.com", "Rickey", 0, "Ottis", "12345678901234", "12345678", 289853.0, "Schmitt Key", null },
                    { -26, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DuBuqueville", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malta", -3, "employee-26@example.com", "Austin", 0, "Kris", "12345678901234", "12345678", 15694.0, "Zulauf Extensions", null },
                    { -25, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Koreymouth", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lesotho", -3, "employee-25@example.com", "Beverly", 1, "Brannon", "12345678901234", "12345678", 38611.0, "Pollich Corners", null },
                    { -24, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pfannerstillton", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Central African Republic", -4, "employee-24@example.com", "Dusty", 0, "Lacey", "12345678901234", "12345678", 20232.0, "Shanahan Brook", null },
                    { -23, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rebecaport", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tajikistan", -4, "employee-23@example.com", "Cheyenne", 1, "Myrtie", "12345678901234", "12345678", 242353.0, "Block Way", null },
                    { -22, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Derrickside", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint Barthelemy", -3, "employee-22@example.com", "Aiden", 0, "Emmitt", "12345678901234", "12345678", 135765.0, "Goodwin Prairie", null },
                    { -21, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Sallie", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bulgaria", -3, "employee-21@example.com", "Mittie", 1, "Ellsworth", "12345678901234", "12345678", 291915.0, "Schneider Row", null },
                    { -20, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kayceeville", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Palau", -1, "employee-20@example.com", "Hermina", 0, "Rashad", "12345678901234", "12345678", 470179.0, "Zander Ranch", null },
                    { -19, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Colten", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cocos (Keeling) Islands", -3, "employee-19@example.com", "Ardith", 0, "Hobart", "12345678901234", "12345678", 494148.0, "Gorczany Landing", null },
                    { -18, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kolefort", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "United States Minor Outlying Islands", -3, "employee-18@example.com", "Gerard", 0, "Luther", "12345678901234", "12345678", 365423.0, "Wolf Drive", null },
                    { -17, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hermanmouth", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jersey", -3, "employee-17@example.com", "Sven", 1, "Nestor", "12345678901234", "12345678", 440406.0, "Nader Club", null },
                    { -16, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "North Wilfridburgh", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jamaica", -2, "employee-16@example.com", "Katharina", 0, "Sarai", "12345678901234", "12345678", 420797.0, "Harmony Coves", null },
                    { -15, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Turnerport", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Niue", -3, "employee-15@example.com", "Blake", 0, "Nicolette", "12345678901234", "12345678", 38019.0, "Lueilwitz Mount", null },
                    { -14, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Kayland", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Norfolk Island", -2, "employee-14@example.com", "Narciso", 0, "Newton", "12345678901234", "12345678", 461298.0, "Clemmie Inlet", null },
                    { -13, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Matildahaven", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finland", -4, "employee-13@example.com", "Ulises", 0, "Jeanne", "12345678901234", "12345678", 87772.0, "Ashlynn Fords", null },
                    { -12, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daughertyport", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Korea", -4, "employee-12@example.com", "Nelson", 1, "Gabrielle", "12345678901234", "12345678", 163025.0, "Lily Plaza", null },
                    { -11, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Murphyshire", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Canada", -2, "employee-11@example.com", "Felicity", 1, "Antoinette", "12345678901234", "12345678", 47260.0, "Raynor Coves", null },
                    { -10, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Domenickchester", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kazakhstan", -2, "employee-10@example.com", "Brayan", 0, "Jane", "12345678901234", "12345678", 18311.0, "Cole Extension", null },
                    { -9, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bechtelarstad", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malawi", -4, "employee-9@example.com", "Ulises", 0, "Aniyah", "12345678901234", "12345678", 230257.0, "Lesch Junction", null },
                    { -8, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sanfordborough", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Antigua and Barbuda", -3, "employee-8@example.com", "Eulalia", 0, "Stacy", "12345678901234", "12345678", 84142.0, "Rosenbaum Island", null },
                    { -7, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aureliamouth", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Holy See (Vatican City State)", -2, "employee-7@example.com", "Margarette", 0, "Caesar", "12345678901234", "12345678", 234647.0, "Enrique Garden", null },
                    { -6, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hellerberg", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "United States Virgin Islands", -1, "employee-6@example.com", "Toby", 1, "Nichole", "12345678901234", "12345678", 406498.0, "Hermiston Corners", null },
                    { -5, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Schadenborough", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tuvalu", -4, "employee-5@example.com", "Blake", 1, "Alexandre", "12345678901234", "12345678", 12977.0, "Verna Lane", null },
                    { -4, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Arvel", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Guatemala", -2, "employee-4@example.com", "Declan", 0, "Bryana", "12345678901234", "12345678", 100403.0, "Adrienne Cliffs", null },
                    { -3, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Jazlyntown", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thailand", -3, "employee-3@example.com", "Vincenza", 1, "Hank", "12345678901234", "12345678", 357596.0, "Lockman Vista", null },
                    { -2, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Goldenside", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finland", -2, "employee-2@example.com", "Vicente", 0, "Erin", "12345678901234", "12345678", 180196.0, "Curt Brooks", null },
                    { -1, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rutherfordfort", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bahrain", -2, "employee-1@example.com", "Mozelle", 1, "Fiona", "12345678901234", "12345678", 170439.0, "Erdman Field", null }
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
                name: "GeneralSetting",
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
                name: "Permissions",
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
