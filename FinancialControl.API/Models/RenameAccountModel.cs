using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FinancialControl.API.Models
{
    public class RenameAccountModel
    {
        [Required]
        [JsonProperty("accountId")]
        public string AccountId { get; set; }

        [Required]
        [JsonProperty("name")]
        public string NewName { get; set; }
    }
}
