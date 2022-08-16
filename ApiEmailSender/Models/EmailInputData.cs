using FluentEmail.Core.Models;
using System.Text.Json.Serialization;

namespace ApiEmailSender.Models
{
    public class EmailInputData
    {
        public string Subject { get; set; }
        public string Body { get; set; }

        [JsonIgnore]
        public List<Address> RecipientAddressList { get; set; }

        [JsonIgnore]
        public List<Attachment> Attachments { get; set; }
    }
}