using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FinancialControl.API.Models
{
    public class RenameCategoryModel
    {
        [Required]
        [JsonProperty("categoryId")]
        public string Id { get; set; }

        [Required]
        [JsonProperty("newName")]
        public string Name { get; set; }
    }
}
