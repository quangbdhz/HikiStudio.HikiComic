using MimeKit;

namespace HikiComic.ViewModels.SendMail
{
    public class EmailMessage
    {
        public string To { get; set; }

        public string From { get; set; }

        public string Subject { get; set; }

        public string MessageText { get; set; }

        public MimeMessage GetMessage()
        {
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = MessageText;

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("HikiStudio", From));
            message.To.Add(new MailboxAddress("HikiStudio", To));
            message.Subject = Subject;
            message.Body = bodyBuilder.ToMessageBody();
            return message;
        }
    }
}
