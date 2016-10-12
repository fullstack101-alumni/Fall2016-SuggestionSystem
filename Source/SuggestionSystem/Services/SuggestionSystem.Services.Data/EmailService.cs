namespace SuggestionSystem.Services.Data
{
    using System.Configuration;
    using System.Net.Mail;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;

    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            await ConfigSendGridAsync(message);
        }

        public async Task ConfigSendGridAsync(IdentityMessage message)
        {
            string fromAddress = ConfigurationManager.AppSettings.Get("FromAddress");
            string smtpClient = ConfigurationManager.AppSettings.Get("SmtpClient");
            string userId = ConfigurationManager.AppSettings.Get("UserId");
            string password = ConfigurationManager.AppSettings.Get("Password");
            string smtpPort = ConfigurationManager.AppSettings.Get("SMTPPort");
            bool enableSSL = ConfigurationManager.AppSettings.Get("EnableSSL").ToUpper() == "YES" ? true : false;

            var mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(fromAddress);
            mailMessage.To.Add(message.Destination);
            mailMessage.Subject = message.Subject;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = message.Body;

            var client = new SmtpClient();
            client.Host = smtpClient;
            client.EnableSsl = enableSSL;
            client.Port = int.Parse(smtpPort);
            client.Credentials = new System.Net.NetworkCredential(userId, password);

            client.Send(mailMessage);
        }
    }
}
