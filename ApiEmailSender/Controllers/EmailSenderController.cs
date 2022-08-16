using ApiEmailSender.Models;
using ApiEmailSender.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiEmailSender.Controllers
{
    [Route("api/[controller]")]
    public class EmailSenderController : ControllerBase
    {
        private readonly IEmailSenderService _mailService;
        public EmailSenderController(IEmailSenderService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost("/api/EmailSender")]
        public async Task Send(List<string> recipientsList, string subject, string body, IFormFileCollection attachments, CancellationToken cancellationToken)
        {
            EmailInputData emailInput = new EmailInputData()
            {
                RecipientAddressList = RecipientExtension.GetRecipientsFromList(recipientsList),
                Subject = subject,
                Body = body,
                Attachments = AttachmentExtension.GetAttachmentsList(attachments)
            };

            try
            {
                await _mailService.SendEmail(emailInput, cancellationToken);
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}