using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MySportsClubLesson6.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MySportsClubLesson6.Services {
    // todo lesson 6-07b: IMailService implementatie
    public class MailService : IMailService {
        private readonly MailSettings _mailSettings;

        public MailService(IOptions<MailSettings> mailSettings) {
            _mailSettings = mailSettings.Value;
        }

        public async Task SendMailAsync(MailRequest mailRequest) {
            // todo: construct email
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;

            var builder = new BodyBuilder();
            builder.HtmlBody = mailRequest.Body;
            
            // todo: add optional attachments 
            if (mailRequest.Attachments != null) {
                byte[] fileBytes;
                foreach (var file in mailRequest.Attachments) {
                    if (file.Length > 0) {
                        using (var ms = new MemoryStream()) {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }
            email.Body = builder.ToMessageBody();

            // todo use SmtpClient for sending the constructed email
            using var smtpClient = new SmtpClient();
            smtpClient.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtpClient.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            await smtpClient.SendAsync(email);
            smtpClient.Disconnect(true);
        }
    }
}
