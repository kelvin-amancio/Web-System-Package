
using System.Net;
using System.Net.Mail;
using WebSystem.Core.models;

namespace WebSystem.Core
{
    public class WebSystemEmail
    {
        public async Task<SystemResultViewModel<bool>> SendEmail(string host, string userName, string password, int port, WsEmail wsEmail)
        {
            var smtpClient = new SmtpClient(host, port);
            smtpClient.Credentials = new NetworkCredential(userName, password);
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;

            var mail = new MailMessage();
            mail.From = new MailAddress(wsEmail.FromEmail, wsEmail.FromName);
            mail.To.Add(new MailAddress(wsEmail.ToEmail, wsEmail.ToName));
            mail.Subject = wsEmail.Subject;
            mail.Body = wsEmail.Body;
            mail.IsBodyHtml = true;

            try
            {
                await smtpClient.SendMailAsync(mail);
                return new SystemResultViewModel<bool>(true);
            }
            catch (SmtpException smtpEx)
            {
                return new SystemResultViewModel<bool>(false, smtpEx.Message);
            }
        }
    }
}