using ApiEmailSender.Models;
using FluentEmail.Core;
using FluentEmail.Core.Models;
using FluentEmail.Smtp;
using System.Net;
using System.Net.Mail;

namespace ApiEmailSender.Services
{
    public interface IEmailSenderService
    {
        Task SendEmail(EmailInputData inputData, CancellationToken cancellationToken);
    }

    public class EmailSenderService : IEmailSenderService
    {
        public async Task SendEmail(EmailInputData inputData, CancellationToken cancellationToken)
        {
            SmtpClient smtp = new()
            {
                Host = "smtp.office365.com",
                Port = 587,
                TargetName = "STARTTLS/smtp.office365.com",
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential("maciej.wozniczka@outlook.com", "PasswordHere") // valid credentials here
            };
            Email.DefaultSender = new SmtpSender(smtp);

            var email = Email
              .From("maciej.wozniczka@outlook.com") // valid email here
              .To(inputData.RecipientAddressList)
              .Subject(inputData.Subject)
              .Body(inputData.Body, true)
              .Attach((IEnumerable<FluentEmail.Core.Models.Attachment>)inputData.Attachments);

            await email.SendAsync(cancellationToken);
        }
    }
}