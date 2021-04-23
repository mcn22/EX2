using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Pensamientos.Shared
{
    public class EmailSender : IEmailSender
    {
        public EmailSender(SmtpClient smtpClient)
        {
            _smtpClient = smtpClient;
        }

        public SmtpClient _smtpClient { get; }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Task.Run(() => SendEmail(email, subject, message));
        }

        public void SendEmail(string email, string subject, string message)
        {
            var mailMessage = new MailMessage
            {
                From =
                    new MailAddress
                        (
                            _smtpClient.Credentials.GetCredential
                                (_smtpClient.Host, _smtpClient.Port, string.Empty).UserName
                        ),
                Subject = subject,
                Body = message,
                IsBodyHtml = true,
            };

            mailMessage.To.Add(email);
            _smtpClient.Send(mailMessage);
        }
    }
}
