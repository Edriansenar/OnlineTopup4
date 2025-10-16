using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace OnlineTopup.OnlineTopupBusinessLogic
{
    public class EmailService
    {
        private readonly string smtpServer = "sandbox.smtp.mailtrap.io";
        private readonly int port = 2525;
        private readonly string username = "3187cbb95d680f";
        private readonly string password = "6fe48128b0ac23";

        public bool SendEmail(string to, string subject, string body)
        {
            try
            {
                using (var client = new SmtpClient(smtpServer, port))
                {
                    client.Credentials = new NetworkCredential(username, password);
                    client.EnableSsl = true;

                    var mailMessage = new MailMessage("from@example.com", to, subject, body);
                    client.Send(mailMessage);
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Failed to send email: {ex.Message}");
                return false;
            }
        }
    }
}
