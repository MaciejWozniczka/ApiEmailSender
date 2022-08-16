using FluentEmail.Core.Models;

namespace ApiEmailSender.Services
{
    public static class RecipientExtension
    {
        public static List<Address> GetRecipientsFromList(List<string> recipients)
        {
            List<Address> addresses = new();

            foreach (var recipient in recipients)
                addresses.Add(new Address(recipient));

            return addresses;
        }
    }
}