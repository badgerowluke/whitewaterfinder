using Sendgrid;

namespace whitewaterfinder.Core.Admin
{
    public interface IEmailUtility
    {

    }
    public class EmailUtility : IEmailUtility
    {
        public async Task Send()
        {
            var key = "";
            var client = new SendGridClient(key);
            var from= new EmailAddress("no-reply@paddle-finder.com", "Paddle-Finder");
            var subject = "Test Message";
            var to = new EmailAddress("badgerow.luke@gmail.com", "Luke Badgerow");
            var txtContent = "";
            var htmlContent = "";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, txtContent, htmlContent);
        }
        
    }
}