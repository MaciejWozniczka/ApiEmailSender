using FluentEmail.Core.Models;

namespace ApiEmailSender.Services
{
    public static class AttachmentExtension
    {
        public static List<Attachment> GetAttachmentsList(IFormFileCollection attachments)
        {
            List<Attachment> attachmentList = new();

            foreach (var attachment in attachments)
                attachmentList.Add(new Attachment()
                {
                    Data = attachment.OpenReadStream(),
                    Filename = attachment.FileName,
                    ContentType = attachment.ContentType
                });

            return attachmentList;
        }
    }
}