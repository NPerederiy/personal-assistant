using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FinancialControl.API.Models
{
    public class TransactionTagModel
    {
        [Required]
        [JsonProperty("transactionId")]
        public string Id { get; set; }

        [Required]
        [JsonProperty("tag")]
        public string Tag { get; set; }
    }
}
