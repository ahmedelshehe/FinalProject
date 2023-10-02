using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Migrations
{
    public partial class AddingGeneralSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -49,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Dejahhaven", "Antarctica (the territory South of 60 deg S)", -2, "Clarabelle", "Letha", 419812.0, "Jacobi Plains" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -48,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Aubreeport", "Tajikistan", -4, "Kristoffer", "Virginie", 32757.0, "Trystan Pike" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -47,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Titusport", "Russian Federation", -2, "Brennon", "Dorothy", 157594.0, "Rolfson Turnpike" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -46,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "New Izabella", "Albania", -2, "Drake", "Otho", 224000.0, "Waelchi Manor" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -45,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Armanifort", "Hong Kong", -3, "Aliya", "Kailee", 376421.0, "Precious Park" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -44,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "North Bernadetteborough", "Liechtenstein", -2, "Victor", "Shayna", 128761.0, "Lockman Canyon" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -43,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Isaacberg", "Greenland", -2, "Adrienne", 1, "Delpha", 278121.0, "Solon Vista" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -42,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Schuppeland", "Monaco", "Joseph", 0, "Regan", 127165.0, "Von Mission" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -41,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Borischester", "Morocco", -2, "Lauren", 0, "Retha", 260873.0, "Renner Fork" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -40,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Clarahaven", "Kuwait", -1, "Giovanny", "Amelia", 311054.0, "Konopelski Lake" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -39,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Lake Imogene", "Chad", -3, "Roberto", "Talon", 401127.0, "Lorna Street" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -38,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Lynchmouth", "Sweden", -4, "Shayna", "Clifton", 235122.0, "Powlowski Hills" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -37,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Lockmanport", "Romania", -2, "Aidan", 1, "Arlo", 155651.0, "Orn Shoals" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -36,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "New Trevion", "Turkmenistan", -2, "Fredrick", 1, "Hope", 53172.0, "Paucek Pine" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -35,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "North Anahi", "Cape Verde", -3, "Elizabeth", "Troy", 402771.0, "Bartoletti Circles" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -34,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "West Freidaland", "Norfolk Island", "Jaycee", "Adrien", 446908.0, "Arvid Viaduct" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -33,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Shaunfurt", "Uzbekistan", -1, "Marcella", 1, "Alia", 229766.0, "Trantow River" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -32,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "North Harmony", "South Georgia and the South Sandwich Islands", -2, "Oral", "Bert", 51526.0, "Wolff Village" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -31,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Lake Dougshire", "United States of America", -2, "Payton", "Davin", 126866.0, "Candido Mews" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -30,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "O'Connerland", "Fiji", -4, "Odell", "Lew", 410925.0, "Weissnat Oval" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -29,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Markfurt", "Netherlands", -2, "Syble", "Kelley", 455777.0, "Johnston Coves" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -28,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Lake Terrell", "Isle of Man", -1, "Haskell", "Uriah", 110831.0, "Teresa Lake" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -27,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "South Payton", "Puerto Rico", -2, "Cornell", "Kenny", 493826.0, "Langworth Squares" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -26,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Natashaville", "Bouvet Island (Bouvetoya)", "Jacinthe", 1, "Isadore", 231080.0, "Moshe Street" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -25,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Johnsonport", "Saint Vincent and the Grenadines", -2, "Jason", "Ken", 10722.0, "Rosenbaum Coves" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -24,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Torphyburgh", "Bermuda", -3, "Kody", 1, "Dane", 463235.0, "Bradtke Station" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -23,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Titusland", "United States Minor Outlying Islands", "Delilah", "Amy", 252947.0, "Addison Court" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -22,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Kleinfort", "Bolivia", -4, "Nikita", "Demarcus", 86375.0, "Schmidt Lakes" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -21,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Frederikport", "Liberia", "Alexis", 1, "Jerry", 69029.0, "Annetta Hills" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -20,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "West Kraigfort", "Kyrgyz Republic", "Randall", "Providenci", 43533.0, "Kunze Hills" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -19,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "O'Connerberg", "Korea", "Carlo", 0, "Dane", 462177.0, "Isobel Stravenue" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -18,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Ferryhaven", "Latvia", -3, "Jena", 0, "Bridgette", 268973.0, "Abelardo Orchard" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -17,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Cedricktown", "Bhutan", -3, "Enoch", 0, "Royce", 39499.0, "Schroeder Parkway" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -16,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Lake Reidport", "Denmark", -4, "Eliane", 0, "Daniella", 236154.0, "Oberbrunner Heights" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -15,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Marksland", "Morocco", -1, "Deondre", 0, "Orpha", 196727.0, "Wiza Spring" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -14,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "East Drew", "Guernsey", -4, "Blanche", 1, "Stanford", 317075.0, "Welch Expressway" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -13,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "New Jaydeville", "Samoa", -3, "Macy", "Christine", 164353.0, "Jerde Isle" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -12,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "East Jamar", "Belarus", -4, "Cleve", "Eldred", 372363.0, "Hackett Light" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -11,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Carterbury", "Uzbekistan", -1, "Asa", "Niko", 321112.0, "Leffler Hill" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -10,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "South Claud", "Micronesia", "Carmella", "Brice", 79237.0, "Lillian Isle" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -9,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "South Frida", "Tuvalu", -4, "Jeffery", "Mark", 195732.0, "Mayert Terrace" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -8,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Lake Joel", "Latvia", -4, "Bryon", 1, "Wilhelm", 40589.0, "Eichmann Field" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -7,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "New Khalidview", "Uganda", -4, "Wyatt", "Cathy", 144366.0, "Caleb Oval" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -6,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Nitzscheborough", "Uganda", -4, "Durward", 0, "Selina", 199507.0, "Walter Shoal" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -5,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Gracieshire", "Belgium", "Alf", "Ahmed", 446090.0, "Dakota Dale" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -4,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "North Lelah", "Pakistan", -3, "Melody", 1, "Jannie", 481608.0, "Kira Walk" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -3,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "New Lavonnehaven", "Andorra", "Gino", 1, "Sierra", 259972.0, "Elouise Crossing" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Yvonnefort", "Saudi Arabia", -4, "Floy", 0, "Emelie", 103244.0, "Jillian Ridges" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Prohaskaside", "Montserrat", "Lizzie", 1, "Margaretta", 24673.0, "Janick Street" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Role",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "a864e382-1fe0-4d16-a93f-ecf8e71b1947");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneralSetting",
                schema: "dbo");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -49,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Kraigport", "Kiribati", -1, "Sierra", "Curtis", 21071.0, "Waters Freeway" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -48,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Lake Carli", "Namibia", -3, "Yessenia", "Theodore", 108481.0, "Roscoe Trafficway" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -47,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "North Esteban", "Swaziland", -3, "Bailey", "Bianka", 40043.0, "Nella Meadow" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -46,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Okunevaborough", "Saint Pierre and Miquelon", -1, "Janiya", "Ella", 204613.0, "Aniyah Ridge" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -45,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Lake Gino", "Antarctica (the territory South of 60 deg S)", -4, "Raegan", "Keara", 473237.0, "Schmidt Ranch" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -44,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Zemlakview", "Indonesia", -3, "Ada", "Nelson", 315945.0, "Anibal Station" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -43,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Kamrynfurt", "Tokelau", -4, "Shirley", 0, "Noe", 359851.0, "Justice Gateway" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -42,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "South Bradleytown", "Solomon Islands", "Mable", 1, "Paolo", 189082.0, "Schamberger Gateway" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -41,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "East Vernonhaven", "Croatia", -3, "Demetrius", 1, "Isai", 417736.0, "Schneider Isle" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -40,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Port Jason", "Botswana", -2, "Rebekah", "Eloise", 374011.0, "Pacocha Valleys" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -39,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Lake Dinofurt", "Nigeria", -2, "Mafalda", "Trent", 167100.0, "Adams Shoal" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -38,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Steuberland", "Holy See (Vatican City State)", -3, "Sarai", "Johann", 222695.0, "Eleanore Station" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -37,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "North Cecilstad", "Lesotho", -4, "Anna", 0, "Richie", 468256.0, "Edwardo Vista" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -36,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "West Marcomouth", "Senegal", -4, "Linda", 0, "Melba", 201901.0, "Myrtis Parkways" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -35,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Port Virgieshire", "Sudan", -2, "Hilbert", "Cortney", 303019.0, "Leonardo Circle" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -34,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Johnsside", "Tonga", "Sonny", "Toney", 421393.0, "Ritchie Courts" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -33,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Emeliafort", "Cameroon", -4, "Shawn", 0, "Brook", 313310.0, "Weimann Avenue" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -32,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Meaghanbury", "Ghana", -1, "Walker", "Laurel", 14038.0, "Zackary Mall" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -31,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "North Paxton", "Hong Kong", -1, "Briana", "Abigail", 64288.0, "Raynor Road" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -30,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Bruenmouth", "American Samoa", -3, "Pete", "Hailie", 366010.0, "Shanon Center" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -29,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "North Corneliusshire", "Brunei Darussalam", -4, "Janie", "Emil", 289079.0, "Kamron Spring" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -28,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "East Lonzoborough", "Nicaragua", -4, "Freida", "Dayne", 61104.0, "Stiedemann Isle" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -27,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Brownport", "Jordan", -4, "Lilyan", "Florencio", 45894.0, "Kunze Highway" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -26,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Hartmannton", "Rwanda", "Kira", 0, "Jerrell", 63549.0, "Emma Brooks" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -25,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Port Deshawnberg", "Zambia", -1, "Violette", "Joshua", 31847.0, "Ariel Run" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -24,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "West Letitiafurt", "El Salvador", -4, "Tia", 0, "Brennan", 139186.0, "D'Amore Street" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -23,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Brockland", "Holy See (Vatican City State)", "Oda", "Henriette", 219640.0, "Lucie Mountain" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -22,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Bauchchester", "Aruba", -2, "Ezequiel", "Barbara", 344783.0, "Hahn Divide" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -21,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Alexzandermouth", "Kazakhstan", "Adriel", 0, "Morris", 378294.0, "Haley Forest" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -20,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Williamsonport", "Swaziland", "Tania", "Augusta", 79675.0, "Sylvester Rapid" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -19,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "D'Amorefort", "Egypt", "Gaylord", 1, "Zena", 77036.0, "Rosemary Pass" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -18,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "New Luraborough", "Ireland", -1, "Finn", 1, "Virginie", 135963.0, "Lauren Ville" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -17,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "South Brianneside", "Somalia", -2, "Christina", 1, "Ben", 435142.0, "Wiza Canyon" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -16,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Darbyport", "Guernsey", -1, "Brenna", 1, "Alessandra", 358351.0, "Alena Fork" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -15,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Zoeyland", "Iraq", -3, "Taurean", 1, "Rachael", 426677.0, "Jermey Canyon" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -14,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "New Kasandra", "Ukraine", -2, "Esmeralda", 0, "Claude", 467119.0, "Murphy Prairie" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -13,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Ernserton", "Brazil", -2, "Junius", "Ernie", 40531.0, "Ivah Center" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -12,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "East Clarabelleberg", "Kenya", -3, "Eula", "Amari", 306037.0, "Runolfsdottir Loaf" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -11,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "North Valentine", "Lesotho", -3, "Norma", "Constantin", 292298.0, "Norene Cove" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -10,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Bellahaven", "Seychelles", "Orpha", "Maximilian", 133000.0, "Selmer Shoal" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -9,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Jaylinside", "Malawi", -3, "Krystel", "Jermaine", 114721.0, "Camila Isle" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -8,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Meaghanborough", "Paraguay", -1, "Brandi", 0, "Samson", 160837.0, "Littel Port" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -7,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "North Elizabethfurt", "United Kingdom", -1, "Asia", "Lorena", 79946.0, "Lockman Crossroad" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -6,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Port Johnpaulmouth", "Australia", -1, "Ernesto", 1, "Elwin", 489079.0, "Maritza Square" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -5,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "New Edmond", "Montenegro", "Samantha", "Audra", 283904.0, "Dayton Rest" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -4,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "West Micaelaberg", "Finland", -4, "Maryjane", 0, "Ayden", 123487.0, "Dahlia Ville" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -3,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "West Hobartshire", "Ethiopia", "Olaf", 0, "Taylor", 160118.0, "Fritsch Manors" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "East Catalinahaven", "Kazakhstan", -3, "Sally", 1, "Whitney", 38095.0, "Evie Gateway" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "East Tiffanystad", "Benin", "Maybell", 0, "Lauren", 18258.0, "Mosciski Inlet" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Role",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "43053382-37f9-4443-a8fa-c65bf5f54240");
        }
    }
}
