using Microsoft.EntityFrameworkCore.Migrations;

namespace FinancialControl.DAL.Data.Migrations.FinancialControlDb
{
    public partial class AddedCurrencies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurrencyCode",
                table: "Operations",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    ISO_4217_Code = table.Column<string>(maxLength: 3, nullable: false),
                    Name = table.Column<string>(nullable: false),
                    ISO_4217_Number = table.Column<string>(maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.ISO_4217_Code);
                });

            migrationBuilder.InsertData(
                table: "Currency",
                columns: new[] { "ISO_4217_Code", "ISO_4217_Number", "Name" },
                values: new object[,]
                {
                    { "AED", "748", "United Arab Emirates Dirham" },
                    { "NPR", "524", "Nepalese Rupee" },
                    { "NZD", "554", "New Zealand Dollar" },
                    { "OMR", "512", "Rial Omani" },
                    { "PAB", "590", "Panama Balboa" },
                    { "PEN", "604", "Nuevo Sol" },
                    { "PGK", "598", "Papua New Guinea Kina" },
                    { "PHP", "608", "Philippine Peso" },
                    { "PKR", "586", "Pakistan Rupee" },
                    { "PLN", "985", "Poland Zloty" },
                    { "PYG", "600", "Paraguay Guarani" },
                    { "QAR", "634", "Qatari Rial" },
                    { "RON", "946", "Romanian Leu" },
                    { "RSD", "941", "Serbian Dinar" },
                    { "RUB", "643", "Russian Ruble" },
                    { "RWF", "646", "Rwanda Franc" },
                    { "SAR", "682", "Saudi Riyal" },
                    { "SBD", "090", "Solomon Islands Dollar" },
                    { "NOK", "578", "Norwegian Krone" },
                    { "SCR", "690", "Seychelles Rupee" },
                    { "NIO", "558", "Nicaragua Cordoba Oro" },
                    { "NAD", "516", "Namibia Dollar" },
                    { "LSL", "426", "Lesotho Loti" },
                    { "LYD", "434", "Libyan Dinar" },
                    { "MAD", "504", "Moroccan Dirham" },
                    { "MDL", "498", "Moldovan Leu" },
                    { "MGA", "969", "Malagasy Ariary" },
                    { "MKD", "807", "Macedonian Denar" },
                    { "MMK", "104", "Myanmar (Burma) Kyat" },
                    { "MNT", "496", "Mongolian Tughrik" },
                    { "MOP", "446", "Macao Pataca" },
                    { "MRU", "929", "Mauritania Ouguiya" },
                    { "MUR", "480", "Mauritius Rupee" },
                    { "MVR", "462", "Maldives (Maldive Islands) Rufiyaa" },
                    { "MWK", "454", "Malawi Kwacha" },
                    { "MXN", "484", "Mexican Peso" },
                    { "MXV", "979", "Mexican Unidad de Inversion (UDI)" },
                    { "MYR", "458", "Malaysian Ringgit" },
                    { "MZN", "943", "Mozambique Metical" },
                    { "NGN", "566", "Nigeria Naira" },
                    { "LRD", "430", "Liberian Dollar" },
                    { "SDG", "938", "Sudanese Pound" },
                    { "SGD", "702", "Singapore Dollar" },
                    { "USN", "997", "US Dollar" },
                    { "UYI", "940", "Uruguay Peso en Unidades Indexadas (URUIURUI)" },
                    { "UYU", "858", "Peso Uruguayo" },
                    { "UZS", "860", "Uzbekistan Sum" },
                    { "VEF", "937", "Venezuela Bolivar" },
                    { "VND", "704", "Viet Nam Dong" },
                    { "VUV", "548", "Vanuatu Vatu" },
                    { "WST", "882", "Samoa Tala" },
                    { "XAF", "950", "CFA Franc BEAC" },
                    { "XCD", "951", "East Caribbean Dollar" },
                    { "XDR", "960", "SDR (Special Drawing Right)" },
                    { "XOF", "952", "CFA Franc BCEAO" },
                    { "XPF", "953", "CFP Franc" },
                    { "XSU", "994", "Sucre" },
                    { "XUA", "965", "ADB Unit of Account" },
                    { "YER", "886", "Yemeni Rial" },
                    { "ZAR", "710", "Rand" },
                    { "USD", "840", "US Dollar" },
                    { "SEK", "752", "Swedish Krona" },
                    { "UGX", "800", "Uganda Shilling" },
                    { "TZS", "834", "Tanzanian Shilling" },
                    { "SHP", "654", "Saint Helena Pound" },
                    { "SLL", "694", "Sierra Leone Leone" },
                    { "SOS", "706", "Somali Shilling" },
                    { "SRD", "968", "Surinam Dollar" },
                    { "SSP", "728", "South Sudanese Pound" },
                    { "STN", "930", "Sao Tome and Principe Dobra" },
                    { "SVC", "222", "El Salvador Colon" },
                    { "SYP", "760", "Syrian Pound" },
                    { "SZL", "748", "Swaziland Lilangeni" },
                    { "THB", "764", "Thailand Baht" },
                    { "TJS", "972", "Tajikistan Somoni" },
                    { "TMT", "934", "Turkmenistan Manat" },
                    { "TND", "788", "Tunisian Dinar" },
                    { "TOP", "776", "Tonga Pa'anga" },
                    { "TRY", "949", "Turkish Lira" },
                    { "TTD", "780", "Trinidad and Tobago Dollar" },
                    { "TWD", "901", "Taiwan Dollar" },
                    { "UAH", "980", "Ukrainian Hryvnia" },
                    { "LKR", "144", "Sri Lanka Rupee" },
                    { "LBP", "422", "Lebanese Pound" },
                    { "LAK", "418", "Laos Kip" },
                    { "BTN", "064", "Bhutan Ngultrum" },
                    { "BWP", "072", "Botswana Pula" },
                    { "BYN", "933", "Belarussian Ruble" },
                    { "BZD", "084", "Belize Dollar" },
                    { "CAD", "124", "Canadian Dollar" },
                    { "CDF", "976", "Congolese Franc" },
                    { "CHE", "947", "WIR Euro" },
                    { "CHF", "756", "Swiss Franc" },
                    { "CHW", "948", "WIR Franc" },
                    { "CLF", "990", "Unidad de Fomento" },
                    { "CLP", "152", "Chilean Peso" },
                    { "CNY", "156", "Yuan Renminbi" },
                    { "COP", "170", "Colombian Peso" },
                    { "COU", "970", "Unidad de Valor Real" },
                    { "CRC", "188", "Costa Rican Colon" },
                    { "CUC", "931", "Peso Convertible" },
                    { "CUP", "192", "Cuban Peso" },
                    { "BSD", "044", "Bahamian Dollar" },
                    { "CVE", "132", "Cabo Verde Escudo" },
                    { "BRL", "986", "Brazilian Real" },
                    { "BOB", "068", "Bolivia Boliviano" },
                    { "AFN", "971", "Afganistan Afghani" },
                    { "ALL", "008", "Albania Lek" },
                    { "AMD", "051", "Armenian Dram" },
                    { "ANG", "532", "Netherlands Antillean Guilder" },
                    { "AOA", "973", "Angola Kwanza" },
                    { "ARS", "032", "Argentine Peso" },
                    { "AUD", "036", "Australian Dollar" },
                    { "AWG", "533", "Aruban Florin" },
                    { "AZN", "944", "Azerbaijanian Manat" },
                    { "BAM", "977", "Convertible Mark" },
                    { "BBD", "052", "Barbados Dollar" },
                    { "BDT", "050", "Bangladesh Taka" },
                    { "BGN", "975", "Bulgarian Lev" },
                    { "BHD", "048", "Bahraini Dinar" },
                    { "BIF", "108", "Burundi Franc" },
                    { "BMD", "060", "Bermudian Dollar" },
                    { "BND", "096", "Brunei Dollar" },
                    { "BOV", "984", "Bolivia Mvdol" },
                    { "CZK", "203", "Czech Koruna" },
                    { "DJF", "262", "Djibouti Franc" },
                    { "DKK", "208", "Danish Krone" },
                    { "ILS", "376", "Israeli Sheqel" },
                    { "INR", "356", "Indian Rupee" },
                    { "IQD", "368", "Iraqi Dinar" },
                    { "IRR", "364", "Iranian Rial" },
                    { "ISK", "352", "Iceland Krona" },
                    { "JMD", "388", "Jamaican Dollar" },
                    { "JOD", "400", "Jordanian Dinar" },
                    { "JPY", "392", "Japanese Yen" },
                    { "KES", "404", "Kenyan Shilling" },
                    { "KGS", "417", "Kyrgyzstan Som" },
                    { "KHR", "116", "Cambodia Riel" },
                    { "KMF", "174", "Comoro Franc" },
                    { "KPW", "408", "North Korean Won" },
                    { "KRW", "410", "South Korean Won" },
                    { "KWD", "414", "Kuwaiti Dinar" },
                    { "KYD", "136", "Cayman Islands Dollar" },
                    { "KZT", "398", "Kazakhstan Tenge" },
                    { "IDR", "360", "Indonesian Rupiah" },
                    { "HUF", "348", "Hungarian Forint" },
                    { "HTG", "332", "Haiti Gourde" },
                    { "HRK", "191", "Croatian Kuna" },
                    { "DOP", "214", "Dominican Peso" },
                    { "DZD", "012", "Algerian Dinar" },
                    { "EGP", "818", "Egyptian Pound" },
                    { "ERN", "232", "Eritrea Nakfa" },
                    { "ETB", "230", "Ethiopian Birr" },
                    { "EUR", "978", "Euro" },
                    { "FJD", "242", "Fiji Dollar" },
                    { "FKP", "238", "Falkland Islands Pound" },
                    { "ZMW", "967", "Zambian Kwacha" },
                    { "GBP", "826", "Pound Sterling" },
                    { "GHS", "936", "Ghana Cedi" },
                    { "GIP", "292", "Gibraltar Pound" },
                    { "GMD", "270", "Gambia Dalasi" },
                    { "GNF", "324", "Guinea Franc" },
                    { "GTQ", "320", "Guatemala Quetzal" },
                    { "GYD", "328", "Guyana Dollar" },
                    { "HKD", "344", "Hong Kong Dollar" },
                    { "HNL", "340", "Honduras Lempira" },
                    { "GEL", "981", "Georgian Lari" },
                    { "ZWL", "932", "Zimbabwe Dollar" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Operations_CurrencyCode",
                table: "Operations",
                column: "CurrencyCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_Currency_CurrencyCode",
                table: "Operations",
                column: "CurrencyCode",
                principalTable: "Currency",
                principalColumn: "ISO_4217_Code",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operations_Currency_CurrencyCode",
                table: "Operations");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropIndex(
                name: "IX_Operations_CurrencyCode",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "CurrencyCode",
                table: "Operations");
        }
    }
}
