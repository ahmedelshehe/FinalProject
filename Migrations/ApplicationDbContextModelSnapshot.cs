using System;
using FinalProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinalProject.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AppRolePermission", b =>
                {
                    b.Property<string>("AppRolesId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PermissionsId")
                        .HasColumnType("int");

                    b.HasKey("AppRolesId", "PermissionsId");

                    b.HasIndex("PermissionsId");

                    b.ToTable("AppRolePermission", "dbo");

                    b.HasData(
                        new
                        {
                            AppRolesId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                            PermissionsId = -1
                        },
                        new
                        {
                            AppRolesId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                            PermissionsId = -2
                        },
                        new
                        {
                            AppRolesId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                            PermissionsId = -3
                        },
                        new
                        {
                            AppRolesId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                            PermissionsId = -4
                        },
                        new
                        {
                            AppRolesId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                            PermissionsId = -5
                        },
                        new
                        {
                            AppRolesId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                            PermissionsId = -6
                        },
                        new
                        {
                            AppRolesId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                            PermissionsId = -7
                        },
                        new
                        {
                            AppRolesId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                            PermissionsId = -8
                        },
                        new
                        {
                            AppRolesId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                            PermissionsId = -9
                        },
                        new
                        {
                            AppRolesId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                            PermissionsId = -10
                        },
                        new
                        {
                            AppRolesId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                            PermissionsId = -11
                        },
                        new
                        {
                            AppRolesId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                            PermissionsId = -12
                        },
                        new
                        {
                            AppRolesId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                            PermissionsId = -13
                        },
                        new
                        {
                            AppRolesId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                            PermissionsId = -14
                        },
                        new
                        {
                            AppRolesId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                            PermissionsId = -15
                        },
                        new
                        {
                            AppRolesId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                            PermissionsId = -16
                        },
                        new
                        {
                            AppRolesId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                            PermissionsId = -17
                        },
                        new
                        {
                            AppRolesId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                            PermissionsId = -18
                        },
                        new
                        {
                            AppRolesId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                            PermissionsId = -19
                        },
                        new
                        {
                            AppRolesId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                            PermissionsId = -20
                        },
                        new
                        {
                            AppRolesId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                            PermissionsId = -21
                        },
                        new
                        {
                            AppRolesId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                            PermissionsId = -22
                        },
                        new
                        {
                            AppRolesId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                            PermissionsId = -23
                        },
                        new
                        {
                            AppRolesId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                            PermissionsId = -24
                        },
                        new
                        {
                            AppRolesId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                            PermissionsId = -25
                        },
                        new
                        {
                            AppRolesId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                            PermissionsId = -26
                        },
                        new
                        {
                            AppRolesId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                            PermissionsId = -27
                        },
                        new
                        {
                            AppRolesId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                            PermissionsId = -28
                        });
                });

            modelBuilder.Entity("FinalProject.Models.AppRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Role", "dbo");

                    b.HasData(
                        new
                        {
                            Id = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                            ConcurrencyStamp = "1d2c5f89-22d8-48ed-b92e-c0b9b963bf40",
                            Name = "Adminstrator"
                        });
                });

            modelBuilder.Entity("FinalProject.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<int>("EmpId")
                        .HasColumnType("int");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("RoleAppId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("EmpId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("RoleAppId");

                    b.ToTable("User", "dbo");
                });

            modelBuilder.Entity("FinalProject.Models.Attendance", b =>
                {
                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("DiscountHours")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("int")
                        .HasComputedColumnSql("CASE WHEN DATEDIFF(HOUR, ArrivalTime, DepartureTime) < 8 AND DATEDIFF(HOUR, ArrivalTime, DepartureTime) > 3 THEN 8 - DATEDIFF(HOUR, ArrivalTime, DepartureTime) ELSE 0 END");

                    b.Property<int>("ExtraHours")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("int")
                        .HasComputedColumnSql("CASE WHEN DATEDIFF(HOUR, ArrivalTime, DepartureTime) > 8  THEN DATEDIFF(HOUR, ArrivalTime, DepartureTime) - 8 ELSE 0 END");

                    b.Property<bool>("IsAbsent")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("bit")
                        .HasComputedColumnSql("CONVERT(bit, CASE WHEN DATEDIFF(HOUR, ArrivalTime, DepartureTime) <= 3 THEN 1 ELSE 0 END)");

                    b.HasKey("Date", "EmployeeId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Attendances", "dbo");
                });

            modelBuilder.Entity("FinalProject.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments", "dbo");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Name = "Department 1"
                        },
                        new
                        {
                            Id = -2,
                            Name = "Department 2"
                        },
                        new
                        {
                            Id = -3,
                            Name = "Department 3"
                        },
                        new
                        {
                            Id = -4,
                            Name = "Department 4"
                        });
                });

            modelBuilder.Entity("FinalProject.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AvailableVacations")
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ContractDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DeptID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("NationalId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("DeptID");

                    b.HasIndex("UserId");

                    b.ToTable("Employees", "dbo");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Rosaleefurt",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Venezuela",
                            DeptID = -3,
                            Email = "employee-1@example.com",
                            FirstName = "Osvaldo",
                            Gender = 1,
                            LastName = "Russell",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 423773.0,
                            Street = "Lowe Vista"
                        },
                        new
                        {
                            Id = -2,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Davisfurt",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Morocco",
                            DeptID = -1,
                            Email = "employee-2@example.com",
                            FirstName = "Maxime",
                            Gender = 1,
                            LastName = "Jimmie",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 99304.0,
                            Street = "Kaylie Shoals"

                        },
                        new
                        {
                            Id = -3,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "New Desmond",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Turkmenistan",
                            DeptID = -4,
                            Email = "employee-3@example.com",
                            FirstName = "Mikayla",
                            Gender = 1,
                            LastName = "Ole",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 46123.0,
                            Street = "Bartoletti Walk"

                        },
                        new
                        {
                            Id = -4,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Domenicoport",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Albania",
                            DeptID = -4,
                            Email = "employee-4@example.com",
                            FirstName = "Genevieve",
                            Gender = 1,
                            LastName = "Brice",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 287485.0,
                            Street = "Maymie Wells"

                        },
                        new
                        {
                            Id = -5,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Krystelmouth",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "South Africa",
                            DeptID = -2,
                            Email = "employee-5@example.com",
                            FirstName = "Donny",
                            Gender = 0,
                            LastName = "Darby",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 326975.0,
                            Street = "Brandt Canyon"

                        },
                        new
                        {
                            Id = -6,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "North Laishatown",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Iran",
                            DeptID = -3,
                            Email = "employee-6@example.com",
                            FirstName = "Keaton",
                            Gender = 0,
                            LastName = "Leonel",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 115742.0,
                            Street = "Treutel Rapids"
                        },
                        new
                        {
                            Id = -7,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Vaughntown",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Jamaica",
                            DeptID = -4,
                            Email = "employee-7@example.com",
                            FirstName = "Jaqueline",
                            Gender = 0,
                            LastName = "Yvette",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 217397.0,
                            Street = "Huel Brook"
                        },
                        new
                        {
                            Id = -8,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Deontaeview",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Norway",
                            DeptID = -2,
                            Email = "employee-8@example.com",
                            FirstName = "Laurel",
                            Gender = 0,
                            LastName = "Lelia",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 46139.0,
                            Street = "Tabitha Walk"
                        },
                        new
                        {
                            Id = -9,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Lake Rowland",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Sweden",
                            DeptID = -3,
                            Email = "employee-9@example.com",
                            FirstName = "Ramona",
                            Gender = 0,
                            LastName = "Billie",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 99254.0,
                            Street = "Johnson Coves"
                        },
                        new
                        {
                            Id = -10,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Cassidyland",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Monaco",
                            DeptID = -1,
                            Email = "employee-10@example.com",
                            FirstName = "Penelope",
                            Gender = 0,
                            LastName = "Oda",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 484758.0,
                            Street = "Hauck Hill"
                        },
                        new
                        {
                            Id = -11,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Bernitamouth",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Mauritius",
                            DeptID = -3,
                            Email = "employee-11@example.com",
                            FirstName = "Deron",
                            Gender = 1,
                            LastName = "Lucile",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 131701.0,
                            Street = "Waelchi Spurs"

                        },
                        new
                        {
                            Id = -12,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Gusikowskihaven",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Guinea",
                            DeptID = -3,
                            Email = "employee-12@example.com",
                            FirstName = "Ernest",
                            Gender = 1,
                            LastName = "Augusta",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 169273.0,
                            Street = "Glover Haven"

                        },
                        new
                        {
                            Id = -13,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "North Malvinaton",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Namibia",
                            DeptID = -3,
                            Email = "employee-13@example.com",
                            FirstName = "Kyra",
                            Gender = 0,
                            LastName = "Trenton",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 107465.0,
                            Street = "Wilkinson Summit"

                        },
                        new
                        {
                            Id = -14,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Collierland",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Martinique",
                            DeptID = -1,
                            Email = "employee-14@example.com",
                            FirstName = "Kaleigh",
                            Gender = 1,
                            LastName = "Ada",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 457255.0,
                            Street = "Ole Groves"
                        },
                        new
                        {
                            Id = -15,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Daijachester",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Cape Verde",
                            DeptID = -1,
                            Email = "employee-15@example.com",
                            FirstName = "Ervin",
                            Gender = 0,
                            LastName = "Grady",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 239848.0,
                            Street = "Terrance Tunnel"

                        },
                        new
                        {
                            Id = -16,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "North Francis",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Liberia",
                            DeptID = -2,
                            Email = "employee-16@example.com",
                            FirstName = "Juston",
                            Gender = 0,
                            LastName = "Antone",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 17530.0,
                            Street = "Baumbach Stream"
                        },
                        new
                        {
                            Id = -17,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Bradenfort",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Cook Islands",
                            DeptID = -4,
                            Email = "employee-17@example.com",
                            FirstName = "Felipa",
                            Gender = 1,
                            LastName = "Miguel",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 132726.0,
                            Street = "Koss Glens"                        },
                        new
                        {
                            Id = -18,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Juliusberg",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Kiribati",
                            DeptID = -2,
                            Email = "employee-18@example.com",
                            FirstName = "Albert",
                            Gender = 1,
                            LastName = "Dion",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 444258.0,
                            Street = "Davin Parks"
                        },
                        new
                        {
                            Id = -19,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Adamsview",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Pakistan",
                            DeptID = -1,
                            Email = "employee-19@example.com",
                            FirstName = "Garrison",
                            Gender = 0,
                            LastName = "Sierra",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 369096.0,
                            Street = "Marlon Shoal"
                        },
                        new
                        {
                            Id = -20,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Brakusborough",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Azerbaijan",
                            DeptID = -1,
                            Email = "employee-20@example.com",
                            FirstName = "Rossie",
                            Gender = 0,
                            LastName = "Syble",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 197549.0,
                            Street = "Marta Path"

                        },
                        new
                        {
                            Id = -21,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "West Maiyaberg",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Chad",
                            DeptID = -2,
                            Email = "employee-21@example.com",
                            FirstName = "Aubrey",
                            Gender = 1,
                            LastName = "Eudora",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 485084.0,
                            Street = "Nitzsche Estate"
                        },
                        new
                        {
                            Id = -22,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),

                            City = "Dietrichland",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Antigua and Barbuda",
                            DeptID = -1,
                            Email = "employee-22@example.com",
                            FirstName = "Mabel",
                            Gender = 1,
                            LastName = "Kassandra",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 27984.0,
                            Street = "Jenkins Viaduct"
                        },
                        new
                        {
                            Id = -23,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "South Jeanettemouth",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Paraguay",
                            DeptID = -4,
                            Email = "employee-23@example.com",
                            FirstName = "Oleta",
                            Gender = 0,
                            LastName = "Janice",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 469494.0,
                            Street = "Jaiden Cove"
                        },
                        new
                        {
                            Id = -24,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "East Geovanniburgh",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Niger",
                            DeptID = -4,
                            Email = "employee-24@example.com",
                            FirstName = "Jennings",
                            Gender = 1,
                            LastName = "Alfonzo",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 177296.0,
                            Street = "Arjun Corners"
                        },
                        new
                        {
                            Id = -25,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Evanhaven",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Uganda",
                            DeptID = -2,
                            Email = "employee-25@example.com",
                            FirstName = "Lisette",
                            Gender = 0,
                            LastName = "Eliane",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 86250.0,
                            Street = "Lindgren Run"
                        },
                        new
                        {
                            Id = -26,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Daxburgh",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Czech Republic",
                            DeptID = -2,
                            Email = "employee-26@example.com",
                            FirstName = "August",
                            Gender = 0,
                            LastName = "Dane",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 139954.0,
                            Street = "Barrows Light"
                        },
                        new
                        {
                            Id = -27,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Samanthaport",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Northern Mariana Islands",
                            DeptID = -2,
                            Email = "employee-27@example.com",
                            FirstName = "Kip",
                            Gender = 0,
                            LastName = "Nicole",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 174335.0,
                            Street = "Clifford Plains"
                        },
                        new
                        {
                            Id = -28,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Shieldsbury",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Chile",
                            DeptID = -2,
                            Email = "employee-28@example.com",
                            FirstName = "Samanta",
                            Gender = 0,
                            LastName = "Levi",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 83793.0,
                            Street = "Flavio Overpass"

                        },
                        new
                        {
                            Id = -29,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Simonischester",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "French Polynesia",
                            DeptID = -3,
                            Email = "employee-29@example.com",
                            FirstName = "Brennan",
                            Gender = 0,
                            LastName = "Hillard",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 25825.0,
                            Street = "Nathaniel Greens"

                        },
                        new
                        {
                            Id = -30,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Kovacekside",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Canada",
                            DeptID = -4,
                            Email = "employee-30@example.com",
                            FirstName = "Eliane",
                            Gender = 0,
                            LastName = "German",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 271743.0,
                            Street = "Smith Greens"

                        },
                        new
                        {
                            Id = -31,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "East Finn",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Sweden",
                            DeptID = -3,
                            Email = "employee-31@example.com",
                            FirstName = "Dallin",
                            Gender = 1,
                            LastName = "Alexane",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 122221.0,
                            Street = "Manuela Mills"

                        },
                        new
                        {
                            Id = -32,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Port Jaclynberg",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Netherlands Antilles",
                            DeptID = -1,
                            Email = "employee-32@example.com",
                            FirstName = "Elliot",
                            Gender = 0,
                            LastName = "Frank",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 317933.0,
                            Street = "Carter Knoll"
                        },
                        new
                        {
                            Id = -33,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Howeville",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Seychelles",
                            DeptID = -3,
                            Email = "employee-33@example.com",
                            FirstName = "Herminia",
                            Gender = 0,
                            LastName = "Lauren",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 352994.0,
                            Street = "Fadel Mountain"

                        },
                        new
                        {
                            Id = -34,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "North Keely",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Congo",
                            DeptID = -4,
                            Email = "employee-34@example.com",
                            FirstName = "Madisyn",
                            Gender = 1,
                            LastName = "Donnie",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 134076.0,
                            Street = "Parisian Union"

                        },
                        new
                        {
                            Id = -35,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Vandervortport",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "China",
                            DeptID = -3,
                            Email = "employee-35@example.com",
                            FirstName = "Armand",
                            Gender = 1,
                            LastName = "Stanley",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 221608.0,
                            Street = "Langosh Isle"
                        },
                        new
                        {
                            Id = -36,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)

                            City = "West Carolyn",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Micronesia",
                            DeptID = -3,
                            Email = "employee-36@example.com",
                            FirstName = "Reyna",
                            Gender = 1,
                            LastName = "Werner",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 254368.0,
                            Street = "Graham Manors"

                        },
                        new
                        {
                            Id = -37,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Ryanchester",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Ethiopia",
                            DeptID = -1,
                            Email = "employee-37@example.com",
                            FirstName = "Trey",
                            Gender = 1,
                            LastName = "Nelle",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 435842.0,
                            Street = "Hilpert Walks"

                        },
                        new
                        {
                            Id = -38,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Port Jerald",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Ukraine",
                            DeptID = -3,
                            Email = "employee-38@example.com",
                            FirstName = "Darrion",
                            Gender = 1,
                            LastName = "Sydnie",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 461081.0,
                            Street = "Ila Circle"
                        },
                        new
                        {
                            Id = -39,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Harveyburgh",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Saint Kitts and Nevis",
                            DeptID = -4,
                            Email = "employee-39@example.com",
                            FirstName = "Rhiannon",
                            Gender = 1,
                            LastName = "Quinton",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 256353.0,
                            Street = "O'Kon Ridge"
                        },
                        new
                        {
                            Id = -40,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Marcoside",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Angola",
                            DeptID = -4,
                            Email = "employee-40@example.com",
                            FirstName = "Lexi",
                            Gender = 1,
                            LastName = "Lonie",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 89327.0,
                            Street = "Polly Parkway"
                        },
                        new
                        {
                            Id = -41,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "O'Konside",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Nicaragua",
                            DeptID = -2,
                            Email = "employee-41@example.com",
                            FirstName = "Miller",
                            Gender = 0,
                            LastName = "Keagan",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 298643.0,
                            Street = "Jordan Row"
                        },
                        new
                        {
                            Id = -42,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Langfurt",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Maldives",
                            DeptID = -3,
                            Email = "employee-42@example.com",
                            FirstName = "Rhoda",
                            Gender = 1,
                            LastName = "Mabelle",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 50219.0,
                            Street = "Zander Orchard"

                        },
                        new
                        {
                            Id = -43,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "South Amiya",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Uganda",
                            DeptID = -2,
                            Email = "employee-43@example.com",
                            FirstName = "Claudie",
                            Gender = 1,
                            LastName = "Jeffry",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 338685.0,
                            Street = "Robel Wells"
                        },
                        new
                        {
                            Id = -44,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Towneborough",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Paraguay",
                            DeptID = -2,
                            Email = "employee-44@example.com",
                            FirstName = "Kale",
                            Gender = 1,
                            LastName = "Ara",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 377417.0,
                            Street = "Garrison Plain"
                        },
                        new
                        {
                            Id = -45,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "East Omarishire",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "New Caledonia",
                            DeptID = -2,
                            Email = "employee-45@example.com",
                            FirstName = "Jeanne",
                            Gender = 1,
                            LastName = "Hillard",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 425272.0,
                            Street = "Murphy Courts"

                        },
                        new
                        {
                            Id = -46,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Keeleyside",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Bouvet Island (Bouvetoya)",
                            DeptID = -4,
                            Email = "employee-46@example.com",
                            FirstName = "Humberto",
                            Gender = 0,
                            LastName = "Lauryn",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 358245.0,
                            Street = "Rosendo Valley"
                        },
                        new
                        {
                            Id = -47,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Johnsonmouth",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Vanuatu",
                            DeptID = -2,
                            Email = "employee-47@example.com",
                            FirstName = "Pietro",
                            Gender = 1,
                            LastName = "Neil",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 398942.0,
                            Street = "Strosin Heights"

                        },
                        new
                        {
                            Id = -48,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "Homenickfort",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "San Marino",
                            DeptID = -3,
                            Email = "employee-48@example.com",
                            FirstName = "Walter",
                            Gender = 1,
                            LastName = "Magnus",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 44319.0,
                            Street = "Funk Dale"

                        },
                        new
                        {
                            Id = -49,
                            AvailableVacations = 21,
                            BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            City = "West Murphy",
                            ContractDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Country = "Uganda",
                            DeptID = -3,
                            Email = "employee-49@example.com",
                            FirstName = "Sydnie",
                            Gender = 1,
                            LastName = "Jadyn",
                            NationalId = "12345678901234",
                            Password = "12345678",
                            Salary = 208668.0,
                            Street = "Janelle Plains"

                        });
                });

            modelBuilder.Entity("FinalProject.Models.GeneralSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DiscountHourPrice")
                        .HasColumnType("int");

                    b.Property<int>("ExtraHourPrice")
                        .HasColumnType("int");

                    b.Property<int>("PriceForDayOvernumberofvacationInyear")
                        .HasColumnType("int");

                    b.Property<int>("numberofvacationInyear")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("GeneralSetting", "dbo");
                });

            modelBuilder.Entity("FinalProject.Models.OfficialVacation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("Date")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("OfficalVacations", "dbo");
                });

            modelBuilder.Entity("FinalProject.Models.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Operation")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Permissions", "dbo");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Name = "Employee",
                            Operation = 1
                        },
                        new
                        {
                            Id = -2,
                            Name = "Employee",
                            Operation = 2
                        },
                        new
                        {
                            Id = -3,
                            Name = "Employee",
                            Operation = 3
                        },
                        new
                        {
                            Id = -4,
                            Name = "Employee",
                            Operation = 0
                        },
                        new
                        {
                            Id = -5,
                            Name = "Attendance",
                            Operation = 1
                        },
                        new
                        {
                            Id = -6,
                            Name = "Attendance",
                            Operation = 2
                        },
                        new
                        {
                            Id = -7,
                            Name = "Attendance",
                            Operation = 3
                        },
                        new
                        {
                            Id = -8,
                            Name = "Attendance",
                            Operation = 0
                        },
                        new
                        {
                            Id = -9,
                            Name = "AppRole",
                            Operation = 1
                        },
                        new
                        {
                            Id = -10,
                            Name = "AppRole",
                            Operation = 2
                        },
                        new
                        {
                            Id = -11,
                            Name = "AppRole",
                            Operation = 3
                        },
                        new
                        {
                            Id = -12,
                            Name = "AppRole",
                            Operation = 0
                        },
                        new
                        {
                            Id = -13,
                            Name = "AppUser",
                            Operation = 1
                        },
                        new
                        {
                            Id = -14,
                            Name = "AppUser",
                            Operation = 2
                        },
                        new
                        {
                            Id = -15,
                            Name = "AppUser",
                            Operation = 3
                        },
                        new
                        {
                            Id = -16,
                            Name = "AppUser",
                            Operation = 0
                        },
                        new
                        {
                            Id = -17,
                            Name = "Permission",
                            Operation = 1
                        },
                        new
                        {
                            Id = -18,
                            Name = "Permission",
                            Operation = 2
                        },
                        new
                        {
                            Id = -19,
                            Name = "Permission",
                            Operation = 3
                        },
                        new
                        {
                            Id = -20,
                            Name = "Permission",
                            Operation = 0
                        },
                        new
                        {
                            Id = -21,
                            Name = "Department",
                            Operation = 1
                        },
                        new
                        {
                            Id = -22,
                            Name = "Department",
                            Operation = 2
                        },
                        new
                        {
                            Id = -23,
                            Name = "Department",
                            Operation = 3
                        },
                        new
                        {
                            Id = -24,
                            Name = "Department",
                            Operation = 0
                        },
                        new
                        {
                            Id = -25,
                            Name = "OfficialVacation",
                            Operation = 1
                        },
                        new
                        {
                            Id = -26,
                            Name = "OfficialVacation",
                            Operation = 2
                        },
                        new
                        {
                            Id = -27,
                            Name = "OfficialVacation",
                            Operation = 3
                        },
                        new
                        {
                            Id = -28,
                            Name = "OfficialVacation",
                            Operation = 0
                        });
                });

            modelBuilder.Entity("FinalProject.Models.PhoneNumber", b =>
                {
                    b.Property<string>("Number")
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.HasKey("Number", "EmployeeId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("PhoneNumbers", "dbo");
                });

            modelBuilder.Entity("FinalProject.Models.Vacation", b =>
                {
                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("VacationType")
                        .HasColumnType("int");

                    b.HasKey("StartDate", "EmployeeId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Vacations", "dbo");
                });

            modelBuilder.Entity("FinalProject.ViewModels.EmployeeAttendanceVM", b =>
                {
                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeptName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("FulllName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.ToTable("EmployeeAttendanceReport", "dbo");
                                    });


            modelBuilder.Entity("FinalProject.ViewModels.SettingViewModel", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<int>("Extra")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("SettingViewModel", "dbo");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaims", "dbo");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims", "dbo");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogins", "dbo");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles", "dbo");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens", "dbo");
                });

            modelBuilder.Entity("AppRolePermission", b =>
                {
                    b.HasOne("FinalProject.Models.AppRole", null)
                        .WithMany()
                        .HasForeignKey("AppRolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinalProject.Models.Permission", null)
                        .WithMany()
                        .HasForeignKey("PermissionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FinalProject.Models.AppUser", b =>
                {
                    b.HasOne("FinalProject.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmpId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinalProject.Models.AppRole", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleAppId");

                    b.Navigation("Employee");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("FinalProject.Models.Attendance", b =>
                {
                    b.HasOne("FinalProject.Models.Employee", "Employee")
                        .WithMany("Attendances")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("FinalProject.Models.Employee", b =>
                {
                    b.HasOne("FinalProject.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DeptID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinalProject.Models.AppUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Department");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FinalProject.Models.OfficialVacation", b =>
                {
                    b.HasOne("FinalProject.Models.AppUser", "User")
                        .WithMany("OfficalVacations")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FinalProject.Models.PhoneNumber", b =>
                {
                    b.HasOne("FinalProject.Models.Employee", "Employee")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("FinalProject.Models.Vacation", b =>
                {
                    b.HasOne("FinalProject.Models.Employee", "Employee")
                        .WithMany("Vacations")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("FinalProject.Models.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("FinalProject.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FinalProject.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("FinalProject.Models.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinalProject.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FinalProject.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FinalProject.Models.AppRole", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("FinalProject.Models.AppUser", b =>
                {
                    b.Navigation("OfficalVacations");
                });

            modelBuilder.Entity("FinalProject.Models.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("FinalProject.Models.Employee", b =>
                {
                    b.Navigation("Attendances");

                    b.Navigation("PhoneNumbers");

                    b.Navigation("Vacations");
                });
#pragma warning restore 612, 618
        }
    }
}
