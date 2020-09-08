using Sendgrid;

namespace whitewaterfinder.Core.Admin
{
    public interface IEmailUtility
    {

    }
    public class EmailUtility : IEmailUtility
    {
        private readonly ISendGridClient _sendGrid;

        public EmailUtility(ISendGridClient grid)
        {
            _sendGrid = grid;
        }
        public async Task SendAsync(string txtContent, string htmlContent)
        {

            var from= new EmailAddress("no-reply@paddle-finder.com", "Paddle-Finder");
            var subject = "Test Message";
            var to = new EmailAddress("badgerow.luke@gmail.com", "Luke Badgerow");
            //I'm not really sure how I feel about having this static helper here...
            var msg = MailHelper.CreateSingleEmail(from, to, subject, txtContent, htmlContent);
            await _sendGrid.SendEmailAsync(msg);
        }
        
    }
}