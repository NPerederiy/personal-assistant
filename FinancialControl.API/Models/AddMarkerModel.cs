using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FinancialControl.API.Models
{
    public class OperationMarkerModel
    {
        [Required]
        [JsonProperty("operationId")]
        public string Id { get; set; }

        [Required]
        [JsonProperty("marker")]
        public string Marker { get; set; }
    }
}
