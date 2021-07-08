using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FinancialControl.API.Models
{
    public class AddMCAModel
    {
        [Required]
        [JsonProperty("ownerId")]
        public string OwnerId { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("currencyCodes")]
        public string[] CurrencyCodes { get; set; }
    }
}
