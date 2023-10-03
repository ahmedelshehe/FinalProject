using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Migrations
{
    public partial class updatingdepartments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Departments",
                keyColumn: "Id",
                keyValue: -4,
                column: "Name",
                value: "Sales");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Departments",
                keyColumn: "Id",
                keyValue: -3,
                column: "Name",
                value: "IT");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Departments",
                keyColumn: "Id",
                keyValue: -2,
                column: "Name",
                value: "R & D");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Departments",
                keyColumn: "Id",
                keyValue: -1,
                column: "Name",
                value: "HR");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -49,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Lake Hermanport", "Brunei Darussalam", -1, "Kellie", 1, "Vincenza", 218792.0, "Leora Camp" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -48,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Margarettemouth", "Oman", -2, "Vita", "Ezekiel", 25710.0, "Reynolds Forks" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -47,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "North Rosendo", "Niger", -1, "Myrtice", 0, "Garrison", 382825.0, "Tatum Passage" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -46,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Santiagostad", "Saint Barthelemy", -3, "Golda", "Alta", 203120.0, "Hammes Forest" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -45,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Jacobsview", "Faroe Islands", -1, "Wade", 0, "Clarabelle", 46737.0, "Maymie Course" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -44,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "North Delphinefort", "Mauritius", -2, "Remington", "Jermey", 182075.0, "Kyleigh Cliff" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -43,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "New Vincemouth", "Sudan", "Milton", "Ezra", 30570.0, "Nicolas Common" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -42,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "East Cheyannefort", "Hong Kong", -3, "Boyd", "Karianne", 359801.0, "Barney Grove" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -41,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "South Roscoeberg", "Holy See (Vatican City State)", -4, "Pattie", "Khalid", 34173.0, "Juliana Points" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -40,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Thielberg", "Saint Vincent and the Grenadines", -2, "Sylvia", 1, "Melany", 184275.0, "Leora Gateway" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -39,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Vonburgh", "Liechtenstein", -3, "Rico", 1, "Stacey", 202670.0, "Tillman Mills" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -38,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "South Bettie", "Chile", -1, "Prudence", 1, "Carmine", 17608.0, "Mariana Spur" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -37,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "West Einomouth", "New Zealand", "Efren", 0, "Deanna", 498758.0, "Nienow Parkways" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -36,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Beckerhaven", "Grenada", "Kyra", "Lennie", 351616.0, "Jarod Mountain" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -35,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Aracelytown", "French Polynesia", -1, "Daphney", "Duncan", 36735.0, "Cale Falls" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -34,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Ebertton", "Rwanda", -2, "Kristian", "Fredrick", 207346.0, "Nolan Streets" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -33,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Beattytown", "Somalia", -1, "Catharine", "Ernesto", 351628.0, "Schaden View" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -32,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Roscoefort", "Romania", "Ava", "Aaliyah", 315119.0, "Douglas " });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -31,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Oraburgh", "Nicaragua", -1, "Josefina", 1, "Delilah", 143921.0, "Jones Canyon" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -30,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "South Keon", "Venezuela", -1, "Rowan", "Trent", 230035.0, "Weimann Dam" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -29,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Leannonville", "Tajikistan", -4, "Kasandra", "Wiley", 444500.0, "Baumbach Forest" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -28,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "West Pietro", "Slovenia", "Noel", "Otto", 277260.0, "Andrew Canyon" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -27,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "North Adelle", "France", -4, "Tanya", "Vella", 67583.0, "Hansen Trace" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -26,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "East Meggiemouth", "Malaysia", -2, "Pasquale", 1, "Jace", 93620.0, "Thompson Valley" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -25,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Port Bernhardberg", "Sao Tome and Principe", -2, "Carmelo", 0, "Gianni", 419267.0, "O'Connell Track" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -24,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Treutelville", "Fiji", "Dillan", "Hayley", 202387.0, "Deckow River" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -23,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Wehnerton", "Holy See (Vatican City State)", -1, "Herminio", "Monty", 421998.0, "Collier Drive" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -22,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Jayceefort", "Tuvalu", -1, "Federico", 1, "Anjali", 401388.0, "Dach Isle" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -21,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Arneland", "Bouvet Island (Bouvetoya)", -1, "Omari", "Lizeth", 66576.0, "Herman Harbor" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -20,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "South Ahmedbury", "China", -3, "Monica", 1, "Kariane", 93629.0, "Alford Valley" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -19,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Strosintown", "Switzerland", -2, "Zoey", "Lynn", 209916.0, "Destini Rue" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -18,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Feeneymouth", "Congo", -1, "Lennie", 1, "Sheldon", 117466.0, "Schaden Route" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -17,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "South Frederiqueton", "Tokelau", -4, "Courtney", 0, "Gail", 297318.0, "Tristin Locks" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -16,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "North Tonibury", "Congo", -3, "Elisha", "Rae", 291917.0, "Audra Pike" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -15,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "West Eloyton", "Tanzania", "Alvah", 1, "Lennie", 460353.0, "Davis Drive" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -14,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Port Aditya", "Botswana", -3, "Lyda", "Gayle", 277494.0, "Franecki Vista" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -13,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Wuckertmouth", "Bahrain", -2, "Spencer", "Amiya", 385769.0, "Roob Club" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -12,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "East Amani", "Wallis and Futuna", "Barbara", 0, "Karen", 400331.0, "Raynor Extensions" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -11,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "West Ivory", "Gambia", -3, "Hardy", 0, "Dereck", 141389.0, "Herman River" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -10,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Quigleymouth", "Iraq", -1, "Casper", "Nico", 377009.0, "Krista Trail" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -9,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Lavernafurt", "Central African Republic", "Jacinthe", 1, "Matteo", 381746.0, "Schuster Vista" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -8,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Naderberg", "Jamaica", -4, "Melany", 1, "Kitty", 451641.0, "Dion Spring" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -7,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "New Van", "Romania", -4, "Silas", 1, "Cortez", 11956.0, "Wisozk Landing" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -6,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "New Arvilla", "Norfolk Island", -3, "Cooper", "Julio", 366751.0, "Evelyn Isle" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -5,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "North Arianna", "Brunei Darussalam", -2, "Rebeka", "Hallie", 142971.0, "Sydni Spring" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -4,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Mohammadside", "Equatorial Guinea", -3, "Shyanne", 1, "Effie", 239494.0, "Joelle Passage" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -3,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Lake Kari", "Bhutan", -2, "Consuelo", 0, "Federico", 333385.0, "Walsh Field" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Emorytown", "Monaco", -1, "Ashlynn", 1, "Kendrick", 312619.0, "Metz Lights" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Ivyberg", "Guadeloupe", "Jacky", "Emerson", 308513.0, "Cristina Ports" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Role",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "f931912e-333c-4a2c-a271-274429d0b5d3");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Departments",
                keyColumn: "Id",
                keyValue: -4,
                column: "Name",
                value: "Department 4");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Departments",
                keyColumn: "Id",
                keyValue: -3,
                column: "Name",
                value: "Department 3");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Departments",
                keyColumn: "Id",
                keyValue: -2,
                column: "Name",
                value: "Department 2");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Departments",
                keyColumn: "Id",
                keyValue: -1,
                column: "Name",
                value: "Department 1");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -49,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Murphyview", "Norfolk Island", -4, "Vinnie", 0, "Adolf", 302640.0, "Steuber Ridges" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -48,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "South Reynachester", "Malaysia", -3, "Zechariah", "Marcella", 315847.0, "Parker Loaf" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -47,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "South Marilyne", "Sao Tome and Principe", -4, "Dion", 1, "Blaze", 57904.0, "Bogan Walk" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -46,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "South Graycemouth", "Latvia", -1, "Weston", "Tierra", 485268.0, "Renner Dale" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -45,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "North Scotside", "Anguilla", -4, "Rolando", 1, "Lauryn", 347572.0, "Brandyn Mount" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -44,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "West Alessandroside", "Sweden", -3, "Velma", "Yvette", 485357.0, "Lakin Expressway" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -43,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "South Buddy", "Portugal", "Edmond", "Gust", 45217.0, "Krystel Avenue" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -42,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Gersonhaven", "Guernsey", -1, "Bobby", "Moses", 350527.0, "Ryder Square" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -41,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Lake Sophie", "Cambodia", -1, "Elsie", "Selmer", 38816.0, "Botsford Fork" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -40,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Ondrickamouth", "Macao", -4, "Willy", 0, "Vivian", 459713.0, "Bartell Courts" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -39,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "North Jedborough", "Niger", -1, "Andre", 0, "Destiney", 348844.0, "Ralph Road" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -38,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "East Braeden", "Bolivia", -3, "Lucius", 0, "Brielle", 427952.0, "Irwin Burgs" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -37,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Larryborough", "Latvia", "Grayson", 1, "Kali", 253355.0, "Brekke Manors" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -36,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Port Orrin", "Turks and Caicos Islands", "Garth", "Murray", 374847.0, "Pacocha Curve" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -35,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Lake Theresaview", "Greece", -2, "Brandyn", "Estella", 258374.0, "Homenick Locks" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -34,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Bettyechester", "Congo", -4, "Elliot", "Willie", 187011.0, "Ima Turnpike" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -33,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Watersfurt", "United States Virgin Islands", -4, "Brain", "Karine", 202885.0, "Bode Ferry" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -32,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "West Ewell", "Madagascar", "Reymundo", "Rossie", 110890.0, "Strosin Tunnel" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -31,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Othaview", "Cote d'Ivoire", -2, "Loy", 0, "Spencer", 476001.0, "Carter Passage" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -30,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Grimesview", "Kuwait", -2, "Melvina", "Katharina", 169161.0, "Brekke Neck" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -29,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Roobburgh", "Wallis and Futuna", -1, "Nathen", "Ahmad", 294342.0, "Derek Haven" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -28,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Gibsonmouth", "Philippines", "Bella", "Marcellus", 395425.0, "Schneider Mill" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -27,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Boyleview", "New Caledonia", -2, "Rickey", "Ottis", 289853.0, "Schmitt Key" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -26,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "DuBuqueville", "Malta", -3, "Austin", 0, "Kris", 15694.0, "Zulauf Extensions" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -25,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "West Koreymouth", "Lesotho", -3, "Beverly", 1, "Brannon", 38611.0, "Pollich Corners" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -24,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Pfannerstillton", "Central African Republic", "Dusty", "Lacey", 20232.0, "Shanahan Brook" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -23,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Rebecaport", "Tajikistan", -4, "Cheyenne", "Myrtie", 242353.0, "Block Way" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -22,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Derrickside", "Saint Barthelemy", -3, "Aiden", 0, "Emmitt", 135765.0, "Goodwin Prairie" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -21,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "New Sallie", "Bulgaria", -3, "Mittie", "Ellsworth", 291915.0, "Schneider Row" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -20,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Kayceeville", "Palau", -1, "Hermina", 0, "Rashad", 470179.0, "Zander Ranch" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -19,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "West Colten", "Cocos (Keeling) Islands", -3, "Ardith", "Hobart", 494148.0, "Gorczany Landing" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -18,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Kolefort", "United States Minor Outlying Islands", -3, "Gerard", 0, "Luther", 365423.0, "Wolf Drive" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -17,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Hermanmouth", "Jersey", -3, "Sven", 1, "Nestor", 440406.0, "Nader Club" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -16,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "North Wilfridburgh", "Jamaica", -2, "Katharina", "Sarai", 420797.0, "Harmony Coves" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -15,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Turnerport", "Niue", "Blake", 0, "Nicolette", 38019.0, "Lueilwitz Mount" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -14,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Lake Kayland", "Norfolk Island", -2, "Narciso", "Newton", 461298.0, "Clemmie Inlet" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -13,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Matildahaven", "Finland", -4, "Ulises", "Jeanne", 87772.0, "Ashlynn Fords" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -12,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Daughertyport", "Korea", "Nelson", 1, "Gabrielle", 163025.0, "Lily Plaza" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -11,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "South Murphyshire", "Canada", -2, "Felicity", 1, "Antoinette", 47260.0, "Raynor Coves" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -10,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Domenickchester", "Kazakhstan", -2, "Brayan", "Jane", 18311.0, "Cole Extension" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -9,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Bechtelarstad", "Malawi", "Ulises", 0, "Aniyah", 230257.0, "Lesch Junction" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -8,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Sanfordborough", "Antigua and Barbuda", -3, "Eulalia", 0, "Stacy", 84142.0, "Rosenbaum Island" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -7,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Aureliamouth", "Holy See (Vatican City State)", -2, "Margarette", 0, "Caesar", 234647.0, "Enrique Garden" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -6,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Hellerberg", "United States Virgin Islands", -1, "Toby", "Nichole", 406498.0, "Hermiston Corners" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -5,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Schadenborough", "Tuvalu", -4, "Blake", "Alexandre", 12977.0, "Verna Lane" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -4,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "South Arvel", "Guatemala", -2, "Declan", 0, "Bryana", 100403.0, "Adrienne Cliffs" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -3,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "South Jazlyntown", "Thailand", -3, "Vincenza", 1, "Hank", 357596.0, "Lockman Vista" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "West Goldenside", "Finland", -2, "Vicente", 0, "Erin", 180196.0, "Curt Brooks" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Rutherfordfort", "Bahrain", "Mozelle", "Fiona", 170439.0, "Erdman Field" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Role",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "fad33632-ac58-4e22-a6fc-995ab8fe2a37");
        }
    }
}
