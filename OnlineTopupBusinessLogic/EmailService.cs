using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;
using OnlineTopup.OnlineTopupCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace OnlineTopup.OnlineTopupBusinessLogic
{
    public class EmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public void SendEmail(string accountNumber)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_emailSettings.FromName, _emailSettings.FromAddress));
            message.To.Add(new MailboxAddress(_emailSettings.ToName, _emailSettings.ToAddress));
            message.Subject = "Account Transaction";

            message.Body = new TextPart("plain")
            {
                Text = $"Account {accountNumber}\n\nA transaction was made to your account\n\n"
            };

            using (var client = new SmtpClient())
            {
                var tlsOption = _emailSettings.EnableTls
                    ? MailKit.Security.SecureSocketOptions.StartTls
                    : MailKit.Security.SecureSocketOptions.None;

                client.Connect(_emailSettings.SmtpHost, _emailSettings.SmtpPort, tlsOption);
                client.Authenticate(_emailSettings.SmtpUsername, _emailSettings.SmtpPassword);
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}