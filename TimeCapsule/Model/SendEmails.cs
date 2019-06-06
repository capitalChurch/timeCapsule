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
    }
}