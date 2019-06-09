using System;
using System.Net;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace TimeCapsule.Model
{
    public class SendEmails
    {
        private readonly SendGridClient _client = new SendGridClient(Constants.SendGridApiKey);

        public async Task SendMessage(Message obj)
        {
            var to = new EmailAddress(obj.Email);
            var from = Constants.FromEmail;
            var subject = Constants.SubjectFromThePast;
            var replyTo = Constants.ResponseEmailAddress;

            var msg = new SendGridMessage()
            {
                From = from,
                ReplyTo = replyTo,
                Subject = subject,
                PlainTextContent = obj.Text,
                HtmlContent = obj.Text
            };
            
            msg.AddTo(to);

            var response = await _client.SendEmailAsync(msg);
            if (response.StatusCode != HttpStatusCode.Accepted)
            {
                var textResponse = await response.Body.ReadAsStringAsync();
                throw new Exception("Email was not sent. See the inner Exception", new Exception(textResponse));
            }
        }

        public async Task SendNotification(Message obj)
        {
            var to = new EmailAddress(obj.Email);

            var msg = new SendGridMessage()
            {
                From = Constants.FromEmail,
                ReplyTo = Constants.ResponseEmailAddress,
                Subject = Constants.SubjectNotification,
                PlainTextContent = Constants.TextEmailNotification,
                HtmlContent = Constants.HtmlEmailNotification
            };
            
            msg.AddTo(to);

            var response = await _client.SendEmailAsync(msg);
            if (response.StatusCode != HttpStatusCode.Accepted)
            {
                var textResponse = await response.Body.ReadAsStringAsync();
                throw new Exception("Email was not sent. See the inner Exception", new Exception(textResponse));
            }
        }

        public async Task SendNotificationFinishesTheJob(int qtySetEmails)
        {

            var msg = MailHelper.CreateSingleEmail(
                Constants.FromEmail,
                Constants.TechnicalResponseEmailAddress, "[TimeCapsule] BatchProccess",
                $"foram enviados {qtySetEmails}", "");

            var response = await _client.SendEmailAsync(msg);
            if (response.StatusCode != HttpStatusCode.Accepted)
            {
                var textResponse = await response.Body.ReadAsStringAsync();
                throw new Exception("Náo foi possivel enviar o email de notificacao de processo", new Exception(textResponse));
            }
        }
    }
}