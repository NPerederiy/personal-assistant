using FinancialControl.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancialControl.DAL.EF
{
    internal static class ModelBuilderExtentions
    {
        internal static void AddFinControlEntities(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(b =>
            {
                b.HasKey(u => u.Id);
            });

            modelBuilder.Entity<Category>(b =>
            {
                b.HasKey(c => c.Id);

                b.Property(c => c.Name)
                 .IsRequired();

                b.HasMany(c => c.Subcategories)
                 .WithOne(c => c.ParentCategory)
                 .OnDelete(DeleteBehavior.Restrict);

                b.HasMany(c => c.Operations)
                 .WithOne(o => o.Category)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Operation>(b =>
            {
                b.HasKey(o => o.Id);

                b.Property(o => o.Name)
                 .IsRequired();

                b.Property(o => o.Cost)
                 .HasColumnType("decimal(18, 2)")
                 .IsRequired();
            });

            modelBuilder.Entity<Currency>(b =>
            {
                b.HasKey(c => c.ISO_4217_Code);

                b.Property(c => c.Name)
                 .IsRequired();

                b.Property(c => c.ISO_4217_Code)
                 .HasMaxLength(3)
                 .IsRequired();

                b.Property(c => c.ISO_4217_Number)
                 .HasMaxLength(3)
                 .IsRequired();

                b.HasMany(c => c.Operations)
                 .WithOne(o => o.Currency)
                 .HasForeignKey(o => o.CurrencyCode)
                 .OnDelete(DeleteBehavior.SetNull);
            });
        }

        public static void AddFinControlSeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>().HasData(
                new Currency { ISO_4217_Code = "AED", ISO_4217_Number = "748", Name = "United Arab Emirates Dirham"},
                new Currency { ISO_4217_Code = "AFN", ISO_4217_Number = "971", Name = "Afganistan Afghani"},
                new Currency { ISO_4217_Code = "ALL", ISO_4217_Number = "008", Name = "Albania Lek"},
                new Currency { ISO_4217_Code = "AMD", ISO_4217_Number = "051", Name = "Armenian Dram"},
                new Currency { ISO_4217_Code = "ANG", ISO_4217_Number = "532", Name = "Netherlands Antillean Guilder"},
                new Currency { ISO_4217_Code = "AOA", ISO_4217_Number = "973", Name = "Angola Kwanza" },
                new Currency { ISO_4217_Code = "ARS", ISO_4217_Number = "032", Name = "Argentine Peso" },
                new Currency { ISO_4217_Code = "AUD", ISO_4217_Number = "036", Name = "Australian Dollar" },
                new Currency { ISO_4217_Code = "AWG", ISO_4217_Number = "533", Name = "Aruban Florin" },
                new Currency { ISO_4217_Code = "AZN", ISO_4217_Number = "944", Name = "Azerbaijanian Manat" },
                new Currency { ISO_4217_Code = "BAM", ISO_4217_Number = "977", Name = "Convertible Mark" },
                new Currency { ISO_4217_Code = "BBD", ISO_4217_Number = "052", Name = "Barbados Dollar" },
                new Currency { ISO_4217_Code = "BDT", ISO_4217_Number = "050", Name = "Bangladesh Taka" },
                new Currency { ISO_4217_Code = "BGN", ISO_4217_Number = "975", Name = "Bulgarian Lev" },
                new Currency { ISO_4217_Code = "BHD", ISO_4217_Number = "048", Name = "Bahraini Dinar" },
                new Currency { ISO_4217_Code = "BIF", ISO_4217_Number = "108", Name = "Burundi Franc" },
                new Currency { ISO_4217_Code = "BMD", ISO_4217_Number = "060", Name = "Bermudian Dollar" },
                new Currency { ISO_4217_Code = "BND", ISO_4217_Number = "096", Name = "Brunei Dollar" },
                new Currency { ISO_4217_Code = "BOB", ISO_4217_Number = "068", Name = "Bolivia Boliviano" },
                new Currency { ISO_4217_Code = "BOV", ISO_4217_Number = "984", Name = "Bolivia Mvdol" },
                new Currency { ISO_4217_Code = "BRL", ISO_4217_Number = "986", Name = "Brazilian Real" },
                new Currency { ISO_4217_Code = "BSD", ISO_4217_Number = "044", Name = "Bahamian Dollar" },
                new Currency { ISO_4217_Code = "BTN", ISO_4217_Number = "064", Name = "Bhutan Ngultrum" },
                new Currency { ISO_4217_Code = "BWP", ISO_4217_Number = "072", Name = "Botswana Pula" },
                new Currency { ISO_4217_Code = "BYN", ISO_4217_Number = "933", Name = "Belarussian Ruble" },
                new Currency { ISO_4217_Code = "BZD", ISO_4217_Number = "084", Name = "Belize Dollar" },
                new Currency { ISO_4217_Code = "CAD", ISO_4217_Number = "124", Name = "Canadian Dollar" },
                new Currency { ISO_4217_Code = "CDF", ISO_4217_Number = "976", Name = "Congolese Franc" },
                new Currency { ISO_4217_Code = "CHE", ISO_4217_Number = "947", Name = "WIR Euro" },
                new Currency { ISO_4217_Code = "CHF", ISO_4217_Number = "756", Name = "Swiss Franc" },
                new Currency { ISO_4217_Code = "CHW", ISO_4217_Number = "948", Name = "WIR Franc" },
                new Currency { ISO_4217_Code = "CLF", ISO_4217_Number = "990", Name = "Unidad de Fomento" },
                new Currency { ISO_4217_Code = "CLP", ISO_4217_Number = "152", Name = "Chilean Peso" },
                new Currency { ISO_4217_Code = "CNY", ISO_4217_Number = "156", Name = "Yuan Renminbi" },
                new Currency { ISO_4217_Code = "COP", ISO_4217_Number = "170", Name = "Colombian Peso" },
                new Currency { ISO_4217_Code = "COU", ISO_4217_Number = "970", Name = "Unidad de Valor Real" },
                new Currency { ISO_4217_Code = "CRC", ISO_4217_Number = "188", Name = "Costa Rican Colon" },
                new Currency { ISO_4217_Code = "CUC", ISO_4217_Number = "931", Name = "Peso Convertible" },
                new Currency { ISO_4217_Code = "CUP", ISO_4217_Number = "192", Name = "Cuban Peso" },
                new Currency { ISO_4217_Code = "CVE", ISO_4217_Number = "132", Name = "Cabo Verde Escudo" },
                new Currency { ISO_4217_Code = "CZK", ISO_4217_Number = "203", Name = "Czech Koruna" },
                new Currency { ISO_4217_Code = "DJF", ISO_4217_Number = "262", Name = "Djibouti Franc" },
                new Currency { ISO_4217_Code = "DKK", ISO_4217_Number = "208", Name = "Danish Krone" },
                new Currency { ISO_4217_Code = "DOP", ISO_4217_Number = "214", Name = "Dominican Peso" },
                new Currency { ISO_4217_Code = "DZD", ISO_4217_Number = "012", Name = "Algerian Dinar" },
                new Currency { ISO_4217_Code = "EGP", ISO_4217_Number = "818", Name = "Egyptian Pound" },
                new Currency { ISO_4217_Code = "ERN", ISO_4217_Number = "232", Name = "Eritrea Nakfa" },
                new Currency { ISO_4217_Code = "ETB", ISO_4217_Number = "230", Name = "Ethiopian Birr" },
                new Currency { ISO_4217_Code = "EUR", ISO_4217_Number = "978", Name = "Euro" },
                new Currency { ISO_4217_Code = "FJD", ISO_4217_Number = "242", Name = "Fiji Dollar" },
                new Currency { ISO_4217_Code = "FKP", ISO_4217_Number = "238", Name = "Falkland Islands Pound" },
                new Currency { ISO_4217_Code = "GBP", ISO_4217_Number = "826", Name = "Pound Sterling" },
                new Currency { ISO_4217_Code = "GEL", ISO_4217_Number = "981", Name = "Georgian Lari" },
                new Currency { ISO_4217_Code = "GHS", ISO_4217_Number = "936", Name = "Ghana Cedi" },
                new Currency { ISO_4217_Code = "GIP", ISO_4217_Number = "292", Name = "Gibraltar Pound" },
                new Currency { ISO_4217_Code = "GMD", ISO_4217_Number = "270", Name = "Gambia Dalasi" },
                new Currency { ISO_4217_Code = "GNF", ISO_4217_Number = "324", Name = "Guinea Franc" },
                new Currency { ISO_4217_Code = "GTQ", ISO_4217_Number = "320", Name = "Guatemala Quetzal" },
                new Currency { ISO_4217_Code = "GYD", ISO_4217_Number = "328", Name = "Guyana Dollar" },
                new Currency { ISO_4217_Code = "HKD", ISO_4217_Number = "344", Name = "Hong Kong Dollar" },
                new Currency { ISO_4217_Code = "HNL", ISO_4217_Number = "340", Name = "Honduras Lempira" },
                new Currency { ISO_4217_Code = "HRK", ISO_4217_Number = "191", Name = "Croatian Kuna" },
                new Currency { ISO_4217_Code = "HTG", ISO_4217_Number = "332", Name = "Haiti Gourde" },
                new Currency { ISO_4217_Code = "HUF", ISO_4217_Number = "348", Name = "Hungarian Forint" },
                new Currency { ISO_4217_Code = "IDR", ISO_4217_Number = "360", Name = "Indonesian Rupiah" },
                new Currency { ISO_4217_Code = "ILS", ISO_4217_Number = "376", Name = "Israeli Sheqel" },
                new Currency { ISO_4217_Code = "INR", ISO_4217_Number = "356", Name = "Indian Rupee" },
                new Currency { ISO_4217_Code = "IQD", ISO_4217_Number = "368", Name = "Iraqi Dinar" },
                new Currency { ISO_4217_Code = "IRR", ISO_4217_Number = "364", Name = "Iranian Rial" },
                new Currency { ISO_4217_Code = "ISK", ISO_4217_Number = "352", Name = "Iceland Krona" },
                new Currency { ISO_4217_Code = "JMD", ISO_4217_Number = "388", Name = "Jamaican Dollar" },
                new Currency { ISO_4217_Code = "JOD", ISO_4217_Number = "400", Name = "Jordanian Dinar" },
                new Currency { ISO_4217_Code = "JPY", ISO_4217_Number = "392", Name = "Japanese Yen" },
                new Currency { ISO_4217_Code = "KES", ISO_4217_Number = "404", Name = "Kenyan Shilling" },
                new Currency { ISO_4217_Code = "KGS", ISO_4217_Number = "417", Name = "Kyrgyzstan Som" },
                new Currency { ISO_4217_Code = "KHR", ISO_4217_Number = "116", Name = "Cambodia Riel" },
                new Currency { ISO_4217_Code = "KMF", ISO_4217_Number = "174", Name = "Comoro Franc" },
                new Currency { ISO_4217_Code = "KPW", ISO_4217_Number = "408", Name = "North Korean Won" },
                new Currency { ISO_4217_Code = "KRW", ISO_4217_Number = "410", Name = "South Korean Won" },
                new Currency { ISO_4217_Code = "KWD", ISO_4217_Number = "414", Name = "Kuwaiti Dinar" },
                new Currency { ISO_4217_Code = "KYD", ISO_4217_Number = "136", Name = "Cayman Islands Dollar" },
                new Currency { ISO_4217_Code = "KZT", ISO_4217_Number = "398", Name = "Kazakhstan Tenge" },
                new Currency { ISO_4217_Code = "LAK", ISO_4217_Number = "418", Name = "Laos Kip" },
                new Currency { ISO_4217_Code = "LBP", ISO_4217_Number = "422", Name = "Lebanese Pound" },
                new Currency { ISO_4217_Code = "LKR", ISO_4217_Number = "144", Name = "Sri Lanka Rupee" },
                new Currency { ISO_4217_Code = "LRD", ISO_4217_Number = "430", Name = "Liberian Dollar" },
                new Currency { ISO_4217_Code = "LSL", ISO_4217_Number = "426", Name = "Lesotho Loti" },
                new Currency { ISO_4217_Code = "LYD", ISO_4217_Number = "434", Name = "Libyan Dinar" },
                new Currency { ISO_4217_Code = "MAD", ISO_4217_Number = "504", Name = "Moroccan Dirham" },
                new Currency { ISO_4217_Code = "MDL", ISO_4217_Number = "498", Name = "Moldovan Leu" },
                new Currency { ISO_4217_Code = "MGA", ISO_4217_Number = "969", Name = "Malagasy Ariary" },
                new Currency { ISO_4217_Code = "MKD", ISO_4217_Number = "807", Name = "Macedonian Denar" },
                new Currency { ISO_4217_Code = "MMK", ISO_4217_Number = "104", Name = "Myanmar (Burma) Kyat" },
                new Currency { ISO_4217_Code = "MNT", ISO_4217_Number = "496", Name = "Mongolian Tughrik" },
                new Currency { ISO_4217_Code = "MOP", ISO_4217_Number = "446", Name = "Macao Pataca" },
                new Currency { ISO_4217_Code = "MRU", ISO_4217_Number = "929", Name = "Mauritania Ouguiya" },
                new Currency { ISO_4217_Code = "MUR", ISO_4217_Number = "480", Name = "Mauritius Rupee" },
                new Currency { ISO_4217_Code = "MVR", ISO_4217_Number = "462", Name = "Maldives (Maldive Islands) Rufiyaa" },
                new Currency { ISO_4217_Code = "MWK", ISO_4217_Number = "454", Name = "Malawi Kwacha" },
                new Currency { ISO_4217_Code = "MXN", ISO_4217_Number = "484", Name = "Mexican Peso" },
                new Currency { ISO_4217_Code = "MXV", ISO_4217_Number = "979", Name = "Mexican Unidad de Inversion (UDI)" },
                new Currency { ISO_4217_Code = "MYR", ISO_4217_Number = "458", Name = "Malaysian Ringgit" },
                new Currency { ISO_4217_Code = "MZN", ISO_4217_Number = "943", Name = "Mozambique Metical" },
                new Currency { ISO_4217_Code = "NAD", ISO_4217_Number = "516", Name = "Namibia Dollar" },
                new Currency { ISO_4217_Code = "NGN", ISO_4217_Number = "566", Name = "Nigeria Naira" },
                new Currency { ISO_4217_Code = "NIO", ISO_4217_Number = "558", Name = "Nicaragua Cordoba Oro" },
                new Currency { ISO_4217_Code = "NOK", ISO_4217_Number = "578", Name = "Norwegian Krone" },
                new Currency { ISO_4217_Code = "NPR", ISO_4217_Number = "524", Name = "Nepalese Rupee" },
                new Currency { ISO_4217_Code = "NZD", ISO_4217_Number = "554", Name = "New Zealand Dollar" },
                new Currency { ISO_4217_Code = "OMR", ISO_4217_Number = "512", Name = "Rial Omani" },
                new Currency { ISO_4217_Code = "PAB", ISO_4217_Number = "590", Name = "Panama Balboa" },
                new Currency { ISO_4217_Code = "PEN", ISO_4217_Number = "604", Name = "Nuevo Sol" },
                new Currency { ISO_4217_Code = "PGK", ISO_4217_Number = "598", Name = "Papua New Guinea Kina" },
                new Currency { ISO_4217_Code = "PHP", ISO_4217_Number = "608", Name = "Philippine Peso" },
                new Currency { ISO_4217_Code = "PKR", ISO_4217_Number = "586", Name = "Pakistan Rupee" },
                new Currency { ISO_4217_Code = "PLN", ISO_4217_Number = "985", Name = "Poland Zloty" },
                new Currency { ISO_4217_Code = "PYG", ISO_4217_Number = "600", Name = "Paraguay Guarani" },
                new Currency { ISO_4217_Code = "QAR", ISO_4217_Number = "634", Name = "Qatari Rial" },
                new Currency { ISO_4217_Code = "RON", ISO_4217_Number = "946", Name = "Romanian Leu" },
                new Currency { ISO_4217_Code = "RSD", ISO_4217_Number = "941", Name = "Serbian Dinar" },
                new Currency { ISO_4217_Code = "RUB", ISO_4217_Number = "643", Name = "Russian Ruble" },
                new Currency { ISO_4217_Code = "RWF", ISO_4217_Number = "646", Name = "Rwanda Franc" },
                new Currency { ISO_4217_Code = "SAR", ISO_4217_Number = "682", Name = "Saudi Riyal" },
                new Currency { ISO_4217_Code = "SBD", ISO_4217_Number = "090", Name = "Solomon Islands Dollar" },
                new Currency { ISO_4217_Code = "SCR", ISO_4217_Number = "690", Name = "Seychelles Rupee" },
                new Currency { ISO_4217_Code = "SDG", ISO_4217_Number = "938", Name = "Sudanese Pound" },
                new Currency { ISO_4217_Code = "SEK", ISO_4217_Number = "752", Name = "Swedish Krona" },
                new Currency { ISO_4217_Code = "SGD", ISO_4217_Number = "702", Name = "Singapore Dollar" },
                new Currency { ISO_4217_Code = "SHP", ISO_4217_Number = "654", Name = "Saint Helena Pound" },
                new Currency { ISO_4217_Code = "SLL", ISO_4217_Number = "694", Name = "Sierra Leone Leone" },
                new Currency { ISO_4217_Code = "SOS", ISO_4217_Number = "706", Name = "Somali Shilling" },
                new Currency { ISO_4217_Code = "SRD", ISO_4217_Number = "968", Name = "Surinam Dollar" },
                new Currency { ISO_4217_Code = "SSP", ISO_4217_Number = "728", Name = "South Sudanese Pound" },
                new Currency { ISO_4217_Code = "STN", ISO_4217_Number = "930", Name = "Sao Tome and Principe Dobra" },
                new Currency { ISO_4217_Code = "SVC", ISO_4217_Number = "222", Name = "El Salvador Colon" },
                new Currency { ISO_4217_Code = "SYP", ISO_4217_Number = "760", Name = "Syrian Pound" },
                new Currency { ISO_4217_Code = "SZL", ISO_4217_Number = "748", Name = "Swaziland Lilangeni" },
                new Currency { ISO_4217_Code = "THB", ISO_4217_Number = "764", Name = "Thailand Baht" },
                new Currency { ISO_4217_Code = "TJS", ISO_4217_Number = "972", Name = "Tajikistan Somoni" },
                new Currency { ISO_4217_Code = "TMT", ISO_4217_Number = "934", Name = "Turkmenistan Manat" },
                new Currency { ISO_4217_Code = "TND", ISO_4217_Number = "788", Name = "Tunisian Dinar" },
                new Currency { ISO_4217_Code = "TOP", ISO_4217_Number = "776", Name = "Tonga Pa'anga" },
                new Currency { ISO_4217_Code = "TRY", ISO_4217_Number = "949", Name = "Turkish Lira" },
                new Currency { ISO_4217_Code = "TTD", ISO_4217_Number = "780", Name = "Trinidad and Tobago Dollar" },
                new Currency { ISO_4217_Code = "TWD", ISO_4217_Number = "901", Name = "Taiwan Dollar" },
                new Currency { ISO_4217_Code = "TZS", ISO_4217_Number = "834", Name = "Tanzanian Shilling" },
                new Currency { ISO_4217_Code = "UAH", ISO_4217_Number = "980", Name = "Ukrainian Hryvnia" },
                new Currency { ISO_4217_Code = "UGX", ISO_4217_Number = "800", Name = "Uganda Shilling" },
                new Currency { ISO_4217_Code = "USD", ISO_4217_Number = "840", Name = "US Dollar" },
                new Currency { ISO_4217_Code = "USN", ISO_4217_Number = "997", Name = "US Dollar" },
                new Currency { ISO_4217_Code = "UYI", ISO_4217_Number = "940", Name = "Uruguay Peso en Unidades Indexadas (URUIURUI)" },
                new Currency { ISO_4217_Code = "UYU", ISO_4217_Number = "858", Name = "Peso Uruguayo" },
                new Currency { ISO_4217_Code = "UZS", ISO_4217_Number = "860", Name = "Uzbekistan Sum" },
                new Currency { ISO_4217_Code = "VEF", ISO_4217_Number = "937", Name = "Venezuela Bolivar" },
                new Currency { ISO_4217_Code = "VND", ISO_4217_Number = "704", Name = "Viet Nam Dong" },
                new Currency { ISO_4217_Code = "VUV", ISO_4217_Number = "548", Name = "Vanuatu Vatu" },
                new Currency { ISO_4217_Code = "WST", ISO_4217_Number = "882", Name = "Samoa Tala" },
                new Currency { ISO_4217_Code = "XAF", ISO_4217_Number = "950", Name = "CFA Franc BEAC" },
                new Currency { ISO_4217_Code = "XCD", ISO_4217_Number = "951", Name = "East Caribbean Dollar" },
                new Currency { ISO_4217_Code = "XDR", ISO_4217_Number = "960", Name = "SDR (Special Drawing Right)" },
                new Currency { ISO_4217_Code = "XOF", ISO_4217_Number = "952", Name = "CFA Franc BCEAO" },
                new Currency { ISO_4217_Code = "XPF", ISO_4217_Number = "953", Name = "CFP Franc" },
                new Currency { ISO_4217_Code = "XSU", ISO_4217_Number = "994", Name = "Sucre" },
                new Currency { ISO_4217_Code = "XUA", ISO_4217_Number = "965", Name = "ADB Unit of Account" },
                new Currency { ISO_4217_Code = "YER", ISO_4217_Number = "886", Name = "Yemeni Rial" },
                new Currency { ISO_4217_Code = "ZAR", ISO_4217_Number = "710", Name = "Rand" },
                new Currency { ISO_4217_Code = "ZMW", ISO_4217_Number = "967", Name = "Zambian Kwacha" },
                new Currency { ISO_4217_Code = "ZWL", ISO_4217_Number = "932", Name = "Zimbabwe Dollar" }
            );
        }
    }
}
