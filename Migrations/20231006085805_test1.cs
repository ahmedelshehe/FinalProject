using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -49,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "New Antoneville", "Kiribati", -1, "Maybell", 1, "Hunter", 18790.0, "Rath Island" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -48,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Tavaresfort", "Portugal", -4, "Chaz", 0, "Polly", 11362.0, "Robel Unions" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -47,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "North Malliefort", "Antarctica (the territory South of 60 deg S)", -1, "Angus", "Hayley", 74310.0, "Abshire Pine" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -46,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Pacochaport", "Honduras", -3, "Tre", "Arlene", 259673.0, "Cruz Rest" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -45,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Schummborough", "Cocos (Keeling) Islands", -4, "Dimitri", 0, "Katlyn", 411266.0, "Emelia Springs" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -44,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Lyricville", "Belize", -3, "Henriette", 0, "Karen", 89602.0, "Donavon Unions" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -43,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Rutherfordland", "Honduras", -1, "Merl", 1, "Pasquale", 456003.0, "Marion Islands" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -42,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Joaquinside", "Ethiopia", "Hank", 0, "Kiara", 78230.0, "Breitenberg Station" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -41,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Hardymouth", "Dominica", -4, "Cathy", "Moriah", 231545.0, "Kuphal Road" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -40,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "South Ruby", "Greenland", -1, "Horace", 1, "Walker", 240285.0, "Christiansen Spurs" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -39,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "West Aldenborough", "Uzbekistan", -2, "Cierra", "Dayne", 235705.0, "Isaias Manors" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -38,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Oranstad", "Sudan", -1, "Pierre", 0, "Abbigail", 256234.0, "Robert Street" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -37,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Marielleton", "Mauritius", -2, "Roberto", 0, "Bella", 144858.0, "Angelina Mills" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -36,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "West Reid", "Grenada", "Ryder", "Danika", 300342.0, "Josh Glens" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -35,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Torreytown", "Saint Lucia", -3, "Ralph", "Tyshawn", 65148.0, "Weber Brooks" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -34,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "New Jeraldfort", "United Kingdom", -2, "Wiley", 1, "Shanelle", 199893.0, "Octavia Roads" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -33,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Port Kathryn", "Djibouti", -1, "Ursula", 1, "Makenzie", 74198.0, "Christiansen Lakes" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -32,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "West Dejachester", "Tajikistan", "Buster", "Bridgette", 422659.0, "Archibald Ville" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -31,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Ilianaland", "Czech Republic", "Alfredo", 0, "Ceasar", 469481.0, "Hank Flat" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -30,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Laurelhaven", "Northern Mariana Islands", -4, "Edwardo", "Caden", 310851.0, "Dach Station" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -29,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "East Cheyenne", "Martinique", -1, "Lisandro", "Ettie", 194938.0, "Jensen Locks" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -28,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "West Beaufort", "Mali", "Alycia", "Mallory", 16290.0, "Jose Lock" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -27,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "East Nayelifort", "French Guiana", "Delta", "Alfreda", 363415.0, "Murphy Crest" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -26,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Dibbertstad", "Mongolia", -2, "Adelbert", "Elwin", 152181.0, "Rolfson Parkway" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -25,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "East Viva", "Colombia", -2, "Sandy", "Gloria", 400328.0, "Emma Spurs" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -24,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "South Wilfredmouth", "Greenland", -3, "Waldo", "Christop", 398586.0, "Garrick Causeway" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -23,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Sanfordberg", "Afghanistan", -1, "Princess", 0, "Nicolas", 117050.0, "Bins Alley" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -22,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Robbieside", "Togo", "Valentina", "Tod", 330351.0, "Giovanny Views" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -21,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Mayraport", "Brazil", -1, "Alverta", 1, "Samara", 56798.0, "Collin Path" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -20,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Ziemannton", "Poland", -3, "Ulises", "Alexa", 327906.0, "Kariane Trail" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -19,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Lake Olliemouth", "Macao", "Kaden", 0, "Aaron", 61633.0, "Mraz Fields" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -18,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Joanyburgh", "Djibouti", -4, "Preston", "Edgardo", 19525.0, "Abshire Villages" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -17,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Halvorsonton", "Congo", "Coby", "Mariano", 39981.0, "Agustin Vista" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -16,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Port Haydenmouth", "Samoa", -4, "Daron", "Davion", 248849.0, "Royal Squares" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -15,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Lake Alessiachester", "Bouvet Island (Bouvetoya)", -4, "Nia", 1, "Adrienne", 95884.0, "Fidel Rest" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -14,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Binsside", "British Virgin Islands", -3, "Bernice", 0, "Cielo", 41898.0, "Connelly Island" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -13,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "South Bennieland", "British Virgin Islands", -1, "Rosa", "Roosevelt", 398103.0, "Zemlak Island" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -12,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Littleton", "Iceland", -3, "Alexys", "Darby", 49963.0, "Gulgowski Run" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -11,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Lake Svenside", "Thailand", -2, "Cornell", 1, "Ralph", 286936.0, "Era Brook" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -10,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "East Sienna", "Bulgaria", -1, "Landen", 0, "Clyde", 370215.0, "Hilpert Curve" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -9,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "West Carole", "Jamaica", -1, "Van", 1, "Antonietta", 186599.0, "Predovic Green" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -8,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "South Rasheedbury", "Germany", -4, "Savanah", 0, "Nick", 118379.0, "Reichel Harbors" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -7,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "East Woodrowshire", "Timor-Leste", -3, "Amaya", 1, "Ladarius", 67459.0, "Klocko Bypass" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -6,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Quentinport", "Antarctica (the territory South of 60 deg S)", -2, "Aric", 1, "Furman", 426567.0, "Barton Place" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -5,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Madisonmouth", "Isle of Man", -4, "Callie", 1, "Shany", 339709.0, "Lisa Land" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -4,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Beahanfurt", "French Polynesia", -1, "Ethan", 0, "Lelia", 414014.0, "Mason Street" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -3,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "West Micheal", "Cape Verde", -1, "Melyna", "Thaddeus", 347946.0, "Demarco Summit" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Hickleshire", "Cocos (Keeling) Islands", -4, "Estell", "Torrance", 8496.0, "Obie Greens" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Broderickside", "Bosnia and Herzegovina", "Rigoberto", "Aiyana", 59970.0, "McDermott Branch" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Role",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "f869f276-2051-4e42-8b9a-cf0406f03be3");

            migrationBuilder.CreateIndex(
                name: "IX_WeekDaysViewModel_SettingViewModelid",
                schema: "dbo",
                table: "WeekDaysViewModel",
                column: "SettingViewModelid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeekDaysViewModel",
                schema: "dbo");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -49,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Lillianatown", "Slovenia", -2, "Gilberto", 0, "Matilda", 480615.0, "Deshaun Hollow" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -48,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "West Evalynhaven", "Barbados", -3, "Andre", 1, "Tyler", 77567.0, "Padberg Corner" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -47,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Goldnerland", "Liechtenstein", -2, "Jettie", "Chloe", 416180.0, "Mohr Meadow" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -46,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Lake Allanton", "Nauru", -4, "Israel", "Domingo", 145175.0, "Paul Falls" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -45,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Hirtheport", "Venezuela", -3, "Libbie", 1, "Kaleb", 253195.0, "Arden Mall" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -44,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "South Ona", "Chad", -2, "Quinn", 1, "Zora", 53490.0, "Marie Ports" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -43,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Collierburgh", "Turks and Caicos Islands", -4, "Kendrick", 0, "Kelli", 123037.0, "Nitzsche Path" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -42,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Candidamouth", "Belarus", "Marcel", 1, "Broderick", 43677.0, "Rempel Cape" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -41,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "East Giuseppe", "Northern Mariana Islands", -2, "Tyra", "Buford", 33566.0, "Krystel Club" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -40,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Schinnerberg", "Saint Barthelemy", -3, "Nathanial", 0, "Garett", 106463.0, "Vandervort Court" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -39,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Port Lori", "Mongolia", -4, "Brett", "Pete", 383961.0, "Shanel Oval" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -38,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Melynaville", "Panama", -4, "Celine", 1, "Isaiah", 426072.0, "Shawn Trail" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -37,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Whitetown", "Gambia", -1, "Cortez", 1, "Concepcion", 393925.0, "Dorothy Trace" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -36,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Krajcikport", "Tokelau", "Reynold", "Laurie", 10001.0, "Jenifer Well" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -35,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "North Aiden", "United Arab Emirates", -4, "Alayna", "Precious", 303527.0, "Timothy Terrace" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -34,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Port Louie", "Saint Kitts and Nevis", -3, "Cameron", 0, "Theodora", 89993.0, "Ella Village" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -33,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Ortizport", "Dominican Republic", -4, "Bria", 0, "Lonzo", 465770.0, "Johnson Ville" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -32,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "South Seamus", "Bahamas", "Godfrey", "Juston", 372647.0, "Braun Path" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -31,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Sofiastad", "Algeria", "Jules", 1, "Destini", 423702.0, "Della Island" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -30,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Marshallside", "Norway", -1, "Emelia", "Zoila", 112745.0, "Alessandra Drive" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -29,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Ebertfurt", "Oman", -4, "Lucas", "Ubaldo", 247731.0, "Lila River" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -28,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "West Enos", "Yemen", "Roel", "Veronica", 47359.0, "Prohaska Drives" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -27,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Patside", "Portugal", "Aditya", "Eric", 103420.0, "Flatley Valleys" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -26,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "North Evalyntown", "Mauritania", -4, "Kian", "Sabina", 125813.0, "Heloise Parks" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -25,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Quitzonport", "Switzerland", -3, "Lynn", "Hayley", 184223.0, "Lockman Glens" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -24,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Hamillhaven", "Liechtenstein", -2, "Lesly", "Tre", 371068.0, "Romaguera Inlet" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -23,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Princessberg", "Sudan", -2, "Avery", 1, "Steve", 421568.0, "Becker Mountains" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -22,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "South Blair", "Costa Rica", "Hilton", "Aaliyah", 473591.0, "Ellie Way" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -21,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Kubside", "Trinidad and Tobago", -4, "Drake", 0, "Audie", 197810.0, "Hector Skyway" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -20,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Loyalland", "Cocos (Keeling) Islands", -1, "Misael", "Antonette", 473553.0, "Haley Heights" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -19,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Asaland", "Marshall Islands", "Jeanne", 1, "Alex", 480965.0, "Sylvia Ridge" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -18,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "West Lizzie", "Mali", -3, "Lester", "Bulah", 240498.0, "Kessler Forge" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -17,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "North Gisselleport", "Macedonia", "Yoshiko", "Velda", 225734.0, "Fahey Island" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -16,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "West Erin", "Netherlands Antilles", -2, "Oran", "Kevin", 250821.0, "Streich Inlet" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -15,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Dameonfort", "Belgium", -2, "Bridie", 0, "Sabryna", 282381.0, "Sawayn Extension" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -14,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "New Mable", "Falkland Islands (Malvinas)", -1, "Presley", 1, "Rosa", 92606.0, "Lowe Valley" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -13,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Port Elmirafurt", "Denmark", -4, "Leila", "Alfredo", 116578.0, "Collin Mountains" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -12,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Kulasville", "Wallis and Futuna", -1, "Carli", "Sabina", 375104.0, "Dominique Road" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -11,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Kuhicside", "Denmark", -1, "Omer", 0, "Emmett", 293576.0, "Bosco Corners" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -10,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "North Kariane", "Uzbekistan", -4, "Hubert", 1, "Shyanne", 77682.0, "Gulgowski View" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -9,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "West Eveside", "Sao Tome and Principe", -4, "Isac", 0, "Aidan", 296764.0, "Arturo Groves" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -8,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "East Samantamouth", "Costa Rica", -2, "Wilber", 1, "Queenie", 189644.0, "Schaefer Flats" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -7,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Toyburgh", "Sri Lanka", -1, "Cecile", 0, "Annabelle", 251795.0, "Dahlia Via" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -6,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Lake Lea", "Puerto Rico", -4, "Marina", 0, "Lauretta", 135206.0, "Maggio Curve" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -5,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "East Claudieside", "Nicaragua", -2, "Rollin", 0, "Cornelius", 109779.0, "Douglas Port" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -4,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "New Irvingburgh", "Wallis and Futuna", -4, "Jayson", 1, "Kaelyn", 217411.0, "Becker Rapid" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -3,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Noemiton", "Switzerland", -2, "Ocie", "Edwin", 7371.0, "O'Keefe Green" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "South Arlo", "Somalia", -2, "Armando", "Ramon", 310171.0, "Cruickshank Ferry" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Williamsonport", "Sri Lanka", "Tierra", "Alvina", 285607.0, "Roberta Crossroad" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Role",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "af5e0bd5-5067-4925-8c72-1e4200c7fb11");
        }
    }
}
