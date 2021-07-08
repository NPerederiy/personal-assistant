using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Notifications.API.Models
{
    public class SendEmailModel
    {
        [JsonProperty("senderEmail")]
        public string Sender { get; set; }

        [Required]
        [JsonProperty("recipientEmail")]
        public string Recipient { get; set; }

        [Required]
        [JsonProperty("subject")]
        public string Subject { get; set; }

        [Required]
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
