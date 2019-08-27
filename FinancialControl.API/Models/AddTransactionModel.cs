using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FinancialControl.API.Models
{
    public class AddTransactionModel
    {
        [Required]
        [JsonProperty("categoryId")]
        public string CategoryId { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("cost")]
        public decimal Cost { get; set; }

        [Required]
        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }

        //public string Time { get; set; }   -- TODO: Implement

        //public string[] Tags { get; set; }   -- TODO: Implement
    }
}
