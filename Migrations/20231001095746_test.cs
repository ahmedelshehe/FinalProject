using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -49,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "West Murphy", "Uganda", "Sydnie", 1, "Jadyn", 208668.0, "Janelle Plains" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -48,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Homenickfort", "San Marino", -3, "Walter", "Magnus", 44319.0, "Funk Dale" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -47,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Johnsonmouth", "Vanuatu", -2, "Pietro", 1, "Neil", 398942.0, "Strosin Heights" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -46,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Keeleyside", "Bouvet Island (Bouvetoya)", -4, "Humberto", "Lauryn", 358245.0, "Rosendo Valley" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -45,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "East Omarishire", "New Caledonia", "Jeanne", "Hillard", 425272.0, "Murphy Courts" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -44,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Towneborough", "Paraguay", -2, "Kale", "Ara", 377417.0, "Garrison Plain" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -43,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "South Amiya", "Uganda", "Claudie", "Jeffry", 338685.0, "Robel Wells" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -42,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Langfurt", "Maldives", -3, "Rhoda", 1, "Mabelle", 50219.0, "Zander Orchard" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -41,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "O'Konside", "Nicaragua", -2, "Miller", "Keagan", 298643.0, "Jordan Row" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -40,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Marcoside", "Angola", -4, "Lexi", 1, "Lonie", 89327.0, "Polly Parkway" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -39,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Harveyburgh", "Saint Kitts and Nevis", -4, "Rhiannon", "Quinton", 256353.0, "O'Kon Ridge" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -38,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Port Jerald", "Ukraine", -3, "Darrion", 1, "Sydnie", 461081.0, "Ila Circle" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -37,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Ryanchester", "Ethiopia", -1, "Trey", 1, "Nelle", 435842.0, "Hilpert Walks" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -36,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "West Carolyn", "Micronesia", -3, "Reyna", "Werner", 254368.0, "Graham Manors" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -35,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Vandervortport", "China", -3, "Armand", 1, "Stanley", 221608.0, "Langosh Isle" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -34,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "North Keely", "Congo", "Madisyn", 1, "Donnie", 134076.0, "Parisian Union" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -33,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Howeville", "Seychelles", -3, "Herminia", 0, "Lauren", 352994.0, "Fadel Mountain" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -32,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Port Jaclynberg", "Netherlands Antilles", -1, "Elliot", "Frank", 317933.0, "Carter Knoll" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -31,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "East Finn", "Sweden", -3, "Dallin", 1, "Alexane", 122221.0, "Manuela Mills" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -30,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Kovacekside", "Canada", -4, "Eliane", 0, "German", 271743.0, "Smith Greens" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -29,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Simonischester", "French Polynesia", -3, "Brennan", 0, "Hillard", 25825.0, "Nathaniel Greens" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -28,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Shieldsbury", "Chile", "Samanta", 0, "Levi", 83793.0, "Flavio Overpass" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -27,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Samanthaport", "Northern Mariana Islands", "Kip", 0, "Nicole", 174335.0, "Clifford Plains" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -26,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Daxburgh", "Czech Republic", -2, "August", 0, "Dane", 139954.0, "Barrows Light" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -25,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Evanhaven", "Uganda", -2, "Lisette", "Eliane", 86250.0, "Lindgren Run" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -24,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "East Geovanniburgh", "Niger", -4, "Jennings", "Alfonzo", 177296.0, "Arjun Corners" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -23,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "South Jeanettemouth", "Paraguay", -4, "Oleta", "Janice", 469494.0, "Jaiden Cove" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -22,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Dietrichland", "Antigua and Barbuda", -1, "Mabel", "Kassandra", 27984.0, "Jenkins Viaduct" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -21,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "West Maiyaberg", "Chad", -2, "Aubrey", "Eudora", 485084.0, "Nitzsche Estate" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -20,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Brakusborough", "Azerbaijan", "Rossie", 0, "Syble", 197549.0, "Marta Path" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -19,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Adamsview", "Pakistan", "Garrison", 0, "Sierra", 369096.0, "Marlon Shoal" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -18,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Juliusberg", "Kiribati", "Albert", 1, "Dion", 444258.0, "Davin Parks" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -17,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Bradenfort", "Cook Islands", "Felipa", 1, "Miguel", 132726.0, "Koss Glens" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -16,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "North Francis", "Liberia", -2, "Juston", "Antone", 17530.0, "Baumbach Stream" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -15,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Daijachester", "Cape Verde", "Ervin", "Grady", 239848.0, "Terrance Tunnel" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -14,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Collierland", "Martinique", -1, "Kaleigh", 1, "Ada", 457255.0, "Ole Groves" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -13,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "North Malvinaton", "Namibia", -3, "Kyra", 0, "Trenton", 107465.0, "Wilkinson Summit" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -12,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Gusikowskihaven", "Guinea", -3, "Ernest", "Augusta", 169273.0, "Glover Haven" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -11,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Bernitamouth", "Mauritius", -3, "Deron", "Lucile", 131701.0, "Waelchi Spurs" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -10,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Cassidyland", "Monaco", -1, "Penelope", 0, "Oda", 484758.0, "Hauck Hill" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -9,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Lake Rowland", "Sweden", -3, "Ramona", "Billie", 99254.0, "Johnson Coves" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -8,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Deontaeview", "Norway", -2, "Laurel", "Lelia", 46139.0, "Tabitha Walk" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -7,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Vaughntown", "Jamaica", "Jaqueline", "Yvette", 217397.0, "Huel Brook" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -6,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "North Laishatown", "Iran", -3, "Keaton", 0, "Leonel", 115742.0, "Treutel Rapids" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -5,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Krystelmouth", "South Africa", -2, "Donny", "Darby", 326975.0, "Brandt Canyon" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -4,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Domenicoport", "Albania", -4, "Genevieve", 1, "Brice", 287485.0, "Maymie Wells" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -3,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "New Desmond", "Turkmenistan", -4, "Mikayla", "Ole", 46123.0, "Bartoletti Walk" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Davisfurt", "Morocco", -1, "Maxime", "Jimmie", 99304.0, "Kaylie Shoals" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Rosaleefurt", "Venezuela", "Osvaldo", "Russell", 423773.0, "Lowe Vista" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Role",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "1d2c5f89-22d8-48ed-b92e-c0b9b963bf40");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeAttendanceReport",
                schema: "dbo");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -49,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Raynorchester", "Panama", "Camren", 0, "Herminia", 35631.0, "Alexzander Mills" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -48,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "East Jasenton", "Andorra", -1, "Marjorie", "Demarco", 473285.0, "Jerde Courts" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -47,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "East Tabitha", "Cocos (Keeling) Islands", -3, "Margaretta", 0, "Arianna", 40503.0, "Wyman Bridge" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -46,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "North Hailey", "Burkina Faso", -2, "Keara", "Brycen", 424605.0, "Peggie Ferry" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -45,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Martybury", "Uzbekistan", "Lucie", "Forrest", 287081.0, "Ursula Keys" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -44,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Millsland", "Faroe Islands", -1, "Rex", "Janiya", 205119.0, "D'Amore Corners" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -43,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "South Tristianfurt", "Mayotte", "Ed", "Eriberto", 328060.0, "Green Tunnel" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -42,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Sylvanside", "Qatar", -1, "Linda", 0, "Carol", 256599.0, "Etha Estates" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -41,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Lindgrenport", "Guatemala", -1, "Elisabeth", "Adrienne", 43918.0, "Marjory Dam" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -40,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "West Danielle", "India", -1, "Marjorie", 0, "Lonny", 374766.0, "Nathanial Inlet" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -39,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Arvelville", "Pakistan", -1, "Ines", "Joannie", 71468.0, "Anastasia Pine" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -38,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Lake Louland", "Armenia", -1, "Celia", 0, "Kiel", 71250.0, "Emmanuel Flats" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -37,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Ressieburgh", "Montserrat", -4, "Murphy", 0, "Gonzalo", 434887.0, "Kautzer Vista" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -36,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Port Uriahhaven", "Timor-Leste", -1, "Josephine", "Duane", 350719.0, "Earnestine Isle" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -35,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "East Faustinoside", "Martinique", -4, "Hettie", 0, "Delilah", 263379.0, "Hank Parkways" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -34,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "North Tre", "Isle of Man", "Kian", 0, "Oma", 265389.0, "Gregory Camp" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -33,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "North Richie", "Liechtenstein", -1, "Estefania", 1, "Alberta", 78573.0, "Wyman Island" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -32,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Moenside", "India", -2, "Mavis", "Dessie", 468908.0, "Langosh Parkway" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -31,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Lake Sylvan", "Belize", -2, "Jensen", 0, "Ben", 104361.0, "Annalise Row" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -30,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Weldonbury", "Gambia", -2, "Noelia", 1, "Jamir", 386149.0, "Stehr Avenue" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -29,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Dariusstad", "American Samoa", -1, "Cristal", 1, "Sallie", 350195.0, "Shields Fall" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -28,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "South Rhoda", "Mexico", "Janiya", 1, "Dannie", 465532.0, "Sallie Land" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -27,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "South Howardshire", "Uzbekistan", "Cassandre", 1, "Davin", 63322.0, "Jewess Isle" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -26,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Lake Priscilla", "Falkland Islands (Malvinas)", -3, "Brian", 1, "Demario", 108779.0, "Lang Trace" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -25,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Lake Luisa", "Western Sahara", -3, "Trystan", "Adrain", 218767.0, "Selina Passage" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -24,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Lenoreville", "Somalia", -2, "Sasha", "Sylvia", 34309.0, "Berge Neck" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -23,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Kaitlintown", "Philippines", -2, "Erwin", "Joan", 95224.0, "Weimann Trail" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -22,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "New Matilde", "Montserrat", -4, "Reyes", "Alfredo", 275946.0, "Jenifer River" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -21,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Emelyside", "Saint Kitts and Nevis", -3, "Toney", "Kirk", 111912.0, "Ari Prairie" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -20,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Sierrashire", "Samoa", "Keyon", 1, "Hertha", 366952.0, "Kunze Knolls" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -19,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Heathcotemouth", "El Salvador", "Heaven", 1, "Berenice", 96733.0, "Smitham Place" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -18,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Medhurstborough", "Cayman Islands", "Myrtice", 0, "Misael", 102558.0, "Hermann Heights" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -17,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "North Wiltonland", "Lao People's Democratic Republic", "Retta", 0, "Kirstin", 414435.0, "Christophe Flat" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -16,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Kreigertown", "Thailand", -1, "Melyssa", "Sonny", 353288.0, "Lonie Vista" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -15,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Lake Hettie", "Netherlands", "Jacey", "Jeff", 157967.0, "Devonte Vista" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -14,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "South Raleigh", "Korea", -3, "Manuela", 0, "Delphine", 278076.0, "Reichel Corners" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -13,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Stantonberg", "Honduras", -2, "Vito", 1, "Winnifred", 377340.0, "Weissnat Port" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -12,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "New Camille", "Bhutan", -4, "Margarete", "Malachi", 476312.0, "Mackenzie Village" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -11,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Emardhaven", "Saint Lucia", -2, "Allie", "Jocelyn", 103371.0, "Welch Crossroad" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -10,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Gorczanybury", "Netherlands", -3, "Rahsaan", 1, "Sherman", 85529.0, "Kohler Street" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -9,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Lake Maria", "Niue", -4, "Antonetta", "Douglas", 479305.0, "Hane Highway" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -8,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "East Maudie", "Moldova", -4, "Destany", "Viviane", 83520.0, "General Orchard" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -7,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "North Kurtis", "Andorra", "Tyreek", "Reba", 161858.0, "Hills Square" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -6,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Ornland", "Afghanistan", -1, "Chanel", 1, "Clair", 63583.0, "Leopold Ports" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -5,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "South Kennyshire", "Greece", -3, "Katrina", "Roberta", 117343.0, "Upton Divide" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -4,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Port Haileeview", "Mongolia", -1, "Gustave", 0, "Enos", 108444.0, "Gottlieb Pines" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -3,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "North Jammie", "Syrian Arab Republic", -3, "Marisol", "Aiyana", 64675.0, "Hubert Ports" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Francescobury", "Kazakhstan", -4, "Jamar", "Gordon", 356694.0, "Ziemann Plains" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Flaviohaven", "Korea", "Catharine", "Santino", 163612.0, "Herzog Walks" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Role",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "cc7251e5-cab8-4d08-84d5-6f4ef6aabea9");
        }
    }
}
