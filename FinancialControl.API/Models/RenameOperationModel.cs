using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FinancialControl.API.Models
{
    public class RenameOperationModel
    {
        [Required]
        [JsonProperty("operationId")]
        public string Id { get; set; }

        [Required]
        [JsonProperty("newName")]
        public string Name { get; set; }
    }
}
