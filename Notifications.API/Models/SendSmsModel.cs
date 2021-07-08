using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Notifications.API.Models
{
    public class SendSmsModel
    {
        [JsonProperty("senderPhone")]
        public string Sender { get; set; }

        [Required]
        [JsonProperty("recipientPhone")]
        public string Recipient { get; set; }

        [Required]
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
