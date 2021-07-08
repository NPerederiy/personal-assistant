using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FinancialControl.API.Models
{
    public class RenameTransactionModel
    {
        [Required]
        [JsonProperty("transactionId")]
        public string Id { get; set; }

        [Required]
        [JsonProperty("newName")]
        public string Name { get; set; }
    }
}
