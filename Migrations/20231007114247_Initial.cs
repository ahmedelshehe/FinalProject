using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalProject.Migrations
{
    public partial class Initial : Migration
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

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -49,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Lake Elton", "Swaziland", -3, "Niko", 0, "Lindsey", 351197.0, "Bahringer Point" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -48,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "New Jorge", "Jordan", -1, "Geovanny", 0, "Rogelio", 24924.0, "Leopoldo Forest" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -47,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Lake Britneytown", "Tajikistan", -4, "Barton", 1, "Demetris", 409537.0, "Beaulah Lock" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -46,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "South Adalbertoton", "Poland", -1, "Carlo", 0, "Audie", 174206.0, "Pacocha Haven" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -45,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Lake Freeman", "Sudan", -4, "Eloisa", "Sammy", 117988.0, "Elwin Mission" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -44,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Braxtonville", "Poland", "Dallas", 0, "Ora", 316717.0, "Adrian Rapid" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -43,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "East Colin", "Barbados", "Dennis", 0, "Desmond", 87913.0, "Ryan Plaza" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -42,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "South Katheryn", "Guadeloupe", "Enos", "Briana", 274063.0, "Kaycee Mall" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -41,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Krisland", "Fiji", "Jailyn", "Abelardo", 260521.0, "Eino Forge" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -40,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Lake Verdie", "Saint Pierre and Miquelon", -1, "Otho", 0, "Ara", 55311.0, "McClure Summit" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -39,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Considinemouth", "Aruba", -1, "Alena", "Asia", 83379.0, "Steuber Manor" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -38,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "New Doris", "United States of America", -4, "Henry", "Molly", 386153.0, "Elsie Crossroad" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -37,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Port Sigmund", "Uzbekistan", -2, "Lorena", "Lonny", 142500.0, "Collier Shore" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -36,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Lawrenceberg", "Afghanistan", -2, "Lonie", 1, "Alysson", 402930.0, "Bosco Cliff" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -35,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "North Orland", "Cook Islands", -3, "Koby", 0, "Ryan", 349405.0, "Aliyah Points" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -34,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "West Christ", "Malaysia", "Dagmar", "Mervin", 430829.0, "Upton Crescent" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -33,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Nienowtown", "Liechtenstein", -1, "Fernando", 1, "Brandt", 104887.0, "Sydnie Station" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -32,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Lake Dulceton", "Greenland", -3, "Jarrell", "Franz", 392610.0, "Luettgen Crescent" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -31,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Tillmanberg", "Bahrain", -2, "Aurelie", "Alvena", 129598.0, "Jackson River" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -30,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "West Constantinmouth", "Benin", -3, "Houston", 0, "Anissa", 11033.0, "Cornelius Street" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -29,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "New Liamview", "Myanmar", -4, "Letha", 0, "Lamar", 460570.0, "Nolan Path" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -28,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Destanyport", "Timor-Leste", -1, "Miracle", 0, "Deangelo", 425828.0, "Mosciski Overpass" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -27,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "New Odie", "Djibouti", "Camryn", "Haylie", 340572.0, "Davis Cliff" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -26,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "West Sophia", "Antarctica (the territory South of 60 deg S)", "Braulio", "Lizzie", 408183.0, "Madilyn Land" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -25,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Tillmanfurt", "Bangladesh", -4, "Eino", 1, "Maximus", 414040.0, "Wilhelm Field" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -24,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Stewartport", "Saint Martin", "Okey", 1, "Alvera", 47555.0, "Rogelio Centers" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -23,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "North Reed", "Burundi", -1, "Bryana", "Karine", 308947.0, "Amya Passage" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -22,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "South Valentina", "Paraguay", -2, "Mohamed", 0, "Kirk", 102432.0, "Bogan Pines" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -21,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "West Deontae", "Macedonia", -4, "Gwendolyn", "Karelle", 254177.0, "Guy Alley" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -20,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "New Javier", "Denmark", "Tyrel", 0, "Geraldine", 64196.0, "Tom Plains" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -19,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Lake Emmalee", "Korea", -4, "Joany", "Horace", 216782.0, "Reynolds Rapid" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -18,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Lake Kaleymouth", "Benin", -2, "Brooke", "Mattie", 262356.0, "Zachariah Stream" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -17,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "East Harmonychester", "Burundi", "Faye", "Darron", 176647.0, "Dickens Hollow" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -16,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Davisberg", "Vanuatu", "Chesley", 1, "Rosendo", 400553.0, "Gutmann Route" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -15,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Donaldfurt", "Comoros", "Lauryn", 1, "Damian", 410213.0, "Metz Street" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -14,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Andresfort", "Czech Republic", "Donavon", 1, "Cletus", 481675.0, "Toy " });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -13,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "New Adalbertoberg", "El Salvador", "Darrel", 0, "Lawson", 345706.0, "Terry Ford" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -12,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Cassinville", "Afghanistan", -1, "Selmer", 0, "Hannah", 29166.0, "Dietrich Corners" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -11,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "New Devontetown", "Benin", -2, "Reyna", "Camron", 99949.0, "Lindgren Loaf" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -10,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "New Paulastad", "United States Minor Outlying Islands", "Declan", 0, "Ruby", 446309.0, "Willms Curve" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -9,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "East Antwanfort", "France", "Patrick", 1, "Jamel", 181884.0, "Feeney Spurs" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -8,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "South Geovannyville", "Gibraltar", -2, "Alexandre", "Odell", 206404.0, "Champlin Road" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -7,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Zboncakborough", "Eritrea", "Rod", 0, "Sadye", 135129.0, "Julian Pine" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -6,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Dangelostad", "Georgia", -4, "Madie", "Osborne", 71310.0, "Emie Tunnel" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -5,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "West Arelymouth", "Reunion", "Emilio", 1, "Emmalee", 199592.0, "Tre Spurs" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -4,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Lake Mae", "Vanuatu", -3, "Fausto", "Lilly", 282838.0, "Nathanael Vista" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -3,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Port Richie", "Western Sahara", -4, "Maya", 1, "Madalyn", 428924.0, "Muller Knolls" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Ervinburgh", "Australia", "Mariane", "Otilia", 271287.0, "Robyn Forest" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Gutmannborough", "Cambodia", -3, "Kristina", "Nikko", 256433.0, "Prosacco Brooks" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Role",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "e6d48d88-53df-49ef-91de-308c42909a90");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeekDaysViewModel",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "WeeklyHolidays",
                schema: "dbo");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -49,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Mohrberg", "Bolivia", -1, "Jane", 1, "Winston", 219272.0, "Abbott Road" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -48,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Bruenport", "Rwanda", -2, "Reyna", 1, "Kelvin", 242232.0, "Brendan Greens" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -47,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "South Ines", "Ireland", -1, "Winfield", 0, "Jack", 59776.0, "Jessie Isle" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -46,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "West Eladiofort", "Lebanon", -4, "Katrine", 1, "Reva", 355499.0, "Ryan Track" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -45,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "West Ellen", "Estonia", -2, "Willow", "Gladyce", 331999.0, "Lowe Divide" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -44,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Emelieport", "Turks and Caicos Islands", "Rashad", 1, "Reymundo", 269428.0, "Gorczany Springs" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -43,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "North Antwan", "Brunei Darussalam", "Mckenzie", 1, "Kennith", 191201.0, "Royal Land" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -42,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Jordanechester", "Romania", "Stuart", "Reanna", 230829.0, "Grimes Green" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -41,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Franeckiborough", "Lithuania", "Horace", "Troy", 200337.0, "Quitzon Walks" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -40,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Kertzmannfort", "Christmas Island", -4, "Reginald", 1, "Giovanny", 12766.0, "Chloe Rapids" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -39,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Schoenhaven", "French Southern Territories", -2, "Zita", "Lillie", 261545.0, "Stiedemann Views" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -38,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "North Earnestborough", "Costa Rica", -3, "Enos", "Cathy", 96195.0, "Harvey Burg" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -37,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "New Bria", "Austria", -3, "Noemy", "Nikita", 368281.0, "Dejah Landing" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -36,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "East Vincenzohaven", "Haiti", -4, "Frida", 0, "Trisha", 69260.0, "Ken Fort" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -35,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Jakefurt", "Maldives", -2, "Conner", 1, "Christop", 100533.0, "Nelle Rue" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -34,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Millsburgh", "Anguilla", "America", "Enoch", 78275.0, "Neoma Isle" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -33,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Port Conrad", "Costa Rica", -4, "Korey", 0, "Kraig", 434457.0, "Santino Expressway" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -32,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Boehmchester", "Honduras", -2, "Deontae", "Demetrius", 118459.0, "Andre Ridges" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -31,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Port Vestaborough", "Hungary", -4, "Delphine", "Tyreek", 455054.0, "Casper Rest" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -30,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Bayerside", "Belize", -2, "Name", 1, "Ardith", 114933.0, "Ebert Roads" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -29,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Port Brenna", "British Indian Ocean Territory (Chagos Archipelago)", -2, "Joseph", 1, "Dalton", 185597.0, "Padberg Creek" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -28,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Lake Erynburgh", "Guinea-Bissau", -2, "Erik", 1, "Breana", 448159.0, "Quitzon Summit" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -27,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Trevormouth", "Cook Islands", "Jose", "Betsy", 245860.0, "Keshaun Prairie" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -26,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "East Toney", "Iran", "David", "Dovie", 137165.0, "Lamont Loaf" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -25,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "New Clemmie", "Uruguay", -1, "Andreane", 0, "Nicholas", 128761.0, "Jerrell Harbors" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -24,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Lilyanchester", "Palestinian Territory", "Ariane", 0, "Milo", 497782.0, "Prosacco Ports" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -23,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "North Herbert", "Mongolia", -4, "Annabel", "Vinnie", 141171.0, "Ella Loaf" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -22,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Hermannview", "Fiji", -3, "Alfonso", 1, "Stefan", 264159.0, "Lola Valley" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -21,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "West Boydtown", "Svalbard & Jan Mayen Islands", -3, "Isabella", "Major", 168123.0, "Koss Parkways" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -20,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Krisfort", "Algeria", "Aaron", 1, "Lizeth", 277179.0, "Stoltenberg Corners" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -19,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Watsonberg", "Uruguay", -2, "Maybell", "Chad", 65141.0, "Rachel Pines" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -18,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Lillianton", "Netherlands", -1, "Hassan", "Janice", 290018.0, "Nella Court" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -17,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "West Kenyattatown", "Monaco", "Shannon", "Shanie", 482206.0, "Marjolaine Vista" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -16,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "North Jessmouth", "Kuwait", "Rosanna", 0, "Ubaldo", 460312.0, "Ruby Streets" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -15,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "New Maddison", "Djibouti", "Mazie", 0, "Harmon", 143982.0, "Harris Square" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -14,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Port Carolannefurt", "United States Virgin Islands", "Allan", 0, "Katlyn", 480194.0, "Edd Views" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -13,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "North Katelin", "Pakistan", "Milford", 1, "Santino", 85849.0, "Tromp Park" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -12,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "East Jaydeberg", "Cameroon", -4, "Frankie", 1, "Abbey", 262624.0, "Cassin Stream" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -11,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "West Tavaresbury", "United States Virgin Islands", -4, "Reta", "Ezekiel", 204915.0, "Marlin Plain" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -10,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "West Maribelview", "Reunion", "Aditya", 1, "Lucious", 192589.0, "Georgiana Overpass" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -9,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Arvidfort", "Philippines", "Sammie", 0, "Trudie", 132700.0, "Prohaska Parks" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -8,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Robelside", "Benin", -1, "Sven", "Abner", 19810.0, "Schoen Roads" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -7,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Baumbachshire", "Thailand", "Malika", 1, "Alisa", 312264.0, "Zemlak Skyway" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -6,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "West Vivienne", "Bahrain", -3, "Murl", "Forest", 207120.0, "Cora Station" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -5,
                columns: new[] { "City", "Country", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Genemouth", "Zimbabwe", "Brandon", 0, "Constantin", 183465.0, "Quentin Course" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -4,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Danikatown", "British Indian Ocean Territory (Chagos Archipelago)", -2, "Howell", "Ephraim", 437026.0, "Keebler Creek" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -3,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "Gender", "LastName", "Salary", "Street" },
                values: new object[] { "Orrinhaven", "Belarus", -2, "Jamison", 0, "Salvatore", 456972.0, "Jewess Brook" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "City", "Country", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "Lynchshire", "Mali", "Mathilde", "Clovis", 45660.0, "Mara Drive" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Employees",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "City", "Country", "DeptID", "FirstName", "LastName", "Salary", "Street" },
                values: new object[] { "New Herbert", "Ghana", -2, "Willa", "Lynn", 11332.0, "Veum Lock" });

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Role",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "e9b5a8e7-a258-488a-abf4-8f4af9300d2a");
        }
    }
}
