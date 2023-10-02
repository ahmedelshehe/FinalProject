using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Migrations
{
    public partial class ahmedaymanwahebbs : Migration
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
                    FulllName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DeptName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
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
                table: "Permissions",
                columns: new[] { "Id", "Name", "Operation" },
                values: new object[,]
                {
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
                values: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7210", "a2aab11f-5224-4fb1-aa84-5261f04911c1", "Adminstrator", null });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "AppRolePermission",
                columns: new[] { "AppRolesId", "PermissionsId" },
                values: new object[,]
                {
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
                    { -49, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Aimee", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Palau", -3, "employee-49@example.com", "Victor", 1, "Alverta", "12345678901234", "12345678", 418871.0, "Lelia Turnpike", null },
                    { -48, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Rhiannafurt", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Colombia", -3, "employee-48@example.com", "Lindsay", 0, "Roscoe", "12345678901234", "12345678", 197639.0, "Afton Route", null },
                    { -47, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marvintown", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eritrea", -4, "employee-47@example.com", "Lucas", 1, "Providenci", "12345678901234", "12345678", 414770.0, "Preston Knoll", null },
                    { -46, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Port Sagefort", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brazil", -1, "employee-46@example.com", "Heidi", 0, "Henriette", "12345678901234", "12345678", 464590.0, "America Court", null },
                    { -45, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Mallie", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ukraine", -1, "employee-45@example.com", "Columbus", 0, "Stephan", "12345678901234", "12345678", 167773.0, "Toy Roads", null },
                    { -44, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Schaeferside", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Armenia", -2, "employee-44@example.com", "Dewayne", 1, "Anissa", "12345678901234", "12345678", 177981.0, "Carlie Brook", null },
                    { -43, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ignatiusmouth", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kenya", -3, "employee-43@example.com", "Garrison", 0, "Yesenia", "12345678901234", "12345678", 160974.0, "McGlynn Mountains", null },
                    { -42, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sidneyberg", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Korea", -1, "employee-42@example.com", "Christian", 0, "Macy", "12345678901234", "12345678", 376095.0, "Justus Junction", null },
                    { -41, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lancetown", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cayman Islands", -3, "employee-41@example.com", "Geo", 1, "Elliott", "12345678901234", "12345678", 410813.0, "Metz Plaza", null },
                    { -40, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Joseph", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ukraine", -3, "employee-40@example.com", "Benjamin", 1, "Willard", "12345678901234", "12345678", 287234.0, "Runte Cliffs", null },
                    { -39, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Tyreekview", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Equatorial Guinea", -2, "employee-39@example.com", "Myrtice", 1, "Providenci", "12345678901234", "12345678", 443063.0, "Tony Crescent", null },
                    { -38, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Watsonstad", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint Martin", -3, "employee-38@example.com", "Jordane", 0, "Mike", "12345678901234", "12345678", 185877.0, "Harvey Greens", null },
                    { -37, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Dejonfort", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Heard Island and McDonald Islands", -3, "employee-37@example.com", "Zachary", 1, "Aurelio", "12345678901234", "12345678", 475413.0, "Dooley Run", null },
                    { -36, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Blaze", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Belgium", -4, "employee-36@example.com", "Norberto", 0, "Skylar", "12345678901234", "12345678", 380399.0, "June Pike", null }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Employees",
                columns: new[] { "Id", "AvailableVacations", "BirthDate", "City", "ContractDate", "Country", "DeptID", "Email", "FirstName", "Gender", "LastName", "NationalId", "Password", "Salary", "Street", "UserId" },
                values: new object[,]
                {
                    { -35, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Magdalenborough", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Denmark", -2, "employee-35@example.com", "Daniela", 1, "Eduardo", "12345678901234", "12345678", 214553.0, "Daniel Trace", null },
                    { -34, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Doyle", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Egypt", -1, "employee-34@example.com", "Ayana", 0, "Rebeca", "12345678901234", "12345678", 232230.0, "Predovic Harbor", null },
                    { -33, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Joseph", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "San Marino", -3, "employee-33@example.com", "Alanis", 1, "Rosendo", "12345678901234", "12345678", 10654.0, "Kirlin Roads", null },
                    { -32, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Camryn", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andorra", -3, "employee-32@example.com", "Noah", 0, "Gladyce", "12345678901234", "12345678", 381544.0, "Kub Summit", null },
                    { -31, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Donnaberg", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panama", -2, "employee-31@example.com", "Alana", 1, "Lambert", "12345678901234", "12345678", 351334.0, "Jailyn Track", null },
                    { -30, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reinholdview", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vanuatu", -2, "employee-30@example.com", "Jamal", 1, "Sage", "12345678901234", "12345678", 401787.0, "Nichole Road", null },
                    { -29, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Torpfurt", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Holy See (Vatican City State)", -4, "employee-29@example.com", "Alda", 0, "Dock", "12345678901234", "12345678", 187388.0, "Owen Island", null },
                    { -28, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lake Destineyfort", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tuvalu", -4, "employee-28@example.com", "April", 1, "Savanna", "12345678901234", "12345678", 484628.0, "Kianna Streets", null },
                    { -27, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Port Dorthaton", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maldives", -3, "employee-27@example.com", "Emelie", 0, "Adelbert", "12345678901234", "12345678", 191181.0, "Kale Common", null },
                    { -26, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Christina", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Martinique", -1, "employee-26@example.com", "Paris", 0, "Beulah", "12345678901234", "12345678", 44198.0, "Gislason Squares", null },
                    { -25, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gloriastad", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Holy See (Vatican City State)", -2, "employee-25@example.com", "Ilene", 1, "Jazmyne", "12345678901234", "12345678", 170614.0, "Mueller Forest", null },
                    { -24, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kelsistad", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Niue", -4, "employee-24@example.com", "Wiley", 0, "Coby", "12345678901234", "12345678", 34304.0, "Elmira Brook", null },
                    { -23, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Jerodchester", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Africa", -2, "employee-23@example.com", "Alexander", 0, "Randal", "12345678901234", "12345678", 291060.0, "Krajcik ", null },
                    { -22, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "South Jackiebury", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Burundi", -4, "employee-22@example.com", "Sigmund", 1, "Afton", "12345678901234", "12345678", 60103.0, "Ankunding Mission", null },
                    { -21, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "New Janetchester", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lao People's Democratic Republic", -2, "employee-21@example.com", "Felipe", 0, "Lauren", "12345678901234", "12345678", 163419.0, "Magdalen Prairie", null },
                    { -20, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Clarabellechester", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Norway", -2, "employee-20@example.com", "Justina", 0, "Celestine", "12345678901234", "12345678", 377907.0, "Jovany Islands", null },
                    { -19, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shirleyberg", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saint Barthelemy", -4, "employee-19@example.com", "Amiya", 0, "Anabel", "12345678901234", "12345678", 155234.0, "Marvin Dam", null },
                    { -18, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ryanchester", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Puerto Rico", -4, "employee-18@example.com", "Raphael", 1, "Dax", "12345678901234", "12345678", 12581.0, "Helga Hollow", null },
                    { -17, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Charitystad", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kyrgyz Republic", -4, "employee-17@example.com", "Eula", 0, "Myriam", "12345678901234", "12345678", 128081.0, "Dare Loop", null },
                    { -16, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Port Josiahchester", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Martinique", -2, "employee-16@example.com", "Forest", 0, "Jasper", "12345678901234", "12345678", 43137.0, "Richie Village", null },
                    { -15, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Leifland", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Central African Republic", -3, "employee-15@example.com", "Aron", 1, "Eleanora", "12345678901234", "12345678", 491870.0, "Kamryn Heights", null },
                    { -14, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "East Blaise", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Micronesia", -1, "employee-14@example.com", "Orion", 1, "Flo", "12345678901234", "12345678", 52322.0, "Davis Heights", null },
                    { -13, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Winston", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jordan", -2, "employee-13@example.com", "Baby", 1, "Olaf", "12345678901234", "12345678", 323769.0, "Hegmann Flat", null },
                    { -12, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cruickshankborough", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "French Southern Territories", -2, "employee-12@example.com", "Meghan", 0, "Corbin", "12345678901234", "12345678", 359138.0, "Arianna Manors", null },
                    { -11, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lorenzashire", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bhutan", -1, "employee-11@example.com", "Lorenza", 0, "Lindsay", "12345678901234", "12345678", 445898.0, "Magdalen Meadows", null },
                    { -10, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "West Margeview", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cambodia", -2, "employee-10@example.com", "Stephan", 0, "Daryl", "12345678901234", "12345678", 9339.0, "Heathcote Valley", null },
                    { -9, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Trentonside", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Slovakia (Slovak Republic)", -2, "employee-9@example.com", "Karianne", 0, "Jordy", "12345678901234", "12345678", 245042.0, "Amparo Brooks", null },
                    { -8, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eichmannmouth", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gambia", -4, "employee-8@example.com", "Constance", 0, "Delia", "12345678901234", "12345678", 345641.0, "Parisian Station", null },
                    { -7, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brownview", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nigeria", -3, "employee-7@example.com", "Derek", 0, "Alba", "12345678901234", "12345678", 347426.0, "Jane Courts", null },
                    { -6, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Collinsmouth", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "French Guiana", -3, "employee-6@example.com", "Mohammed", 0, "Eugenia", "12345678901234", "12345678", 107071.0, "Gislason Divide", null },
                    { -5, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cassinberg", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Djibouti", -3, "employee-5@example.com", "Eliezer", 0, "Mazie", "12345678901234", "12345678", 129952.0, "Ceasar Garden", null },
                    { -4, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andrewville", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cameroon", -2, "employee-4@example.com", "Jody", 1, "Adela", "12345678901234", "12345678", 342815.0, "Muhammad Cliff", null },
                    { -3, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aracelystad", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cook Islands", -4, "employee-3@example.com", "Muriel", 0, "Marcella", "12345678901234", "12345678", 55486.0, "Charlotte Loop", null },
                    { -2, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carolynhaven", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Poland", -4, "employee-2@example.com", "Chelsey", 0, "Ollie", "12345678901234", "12345678", 173196.0, "Adriana Prairie", null },
                    { -1, 21, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Myaview", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Netherlands Antilles", -4, "employee-1@example.com", "Celestino", 0, "Maximilian", "12345678901234", "12345678", 313802.0, "Ottilie Mall", null }
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
