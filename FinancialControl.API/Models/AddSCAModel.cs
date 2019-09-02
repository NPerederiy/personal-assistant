using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FinancialControl.API.Models
{
    public class AddSCAModel
    {
        [Required]
        [JsonProperty("ownerId")]
        public string OwnerId { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty("cardNumber")]
        public string AccountNumber { get; set; }

        [JsonProperty("cardValidTo")]
        public string ValidTo { get; set; }

        [JsonProperty("cardType")]
        public string BankCardType { get; set; }
    }
}
