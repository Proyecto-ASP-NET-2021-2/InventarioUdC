using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;
using System.Configuration;

namespace LogicaNegocio.Servicios
{
    public class Notifications
    {
        public Boolean SendEmail(string subject, string content, string toName, string toEmail)
        {
            string apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("sebastian.1701720825@ucaldas.edu.co", "Proyecto .NET");
            
            var to = new EmailAddress(toEmail, toName);
            var plainTextContent = content;
            var htmlContent = content;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);
            return true;
        }

        public Boolean SendSMS(string content, string to, string from)
        {
            // twillio service
            return true;
        }
    }
}
