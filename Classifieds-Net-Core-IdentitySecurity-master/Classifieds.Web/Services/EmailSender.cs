using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Classifieds.Web.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _fromEmailAddress;

        public EmailSender(string smtpServer, int smtpPort, string fromEmailAddress)
        {
            _smtpServer = smtpServer;
            _smtpPort = smtpPort;
            _fromEmailAddress = fromEmailAddress;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var message = new MailMessage
            {
                From = new MailAddress(_fromEmailAddress),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true
            };

            message.To.Add(new MailAddress(email));

            using (var client = new SmtpClient(_smtpServer, _smtpPort))
            {
                client.Send(message);
            }

            return Task.CompletedTask;
        }
    }
}
