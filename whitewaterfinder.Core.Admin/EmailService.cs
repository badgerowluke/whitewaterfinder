
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

using whitewaterfinder.BusinessObjects;

namespace whitewaterfinder.Core.Admin
{
    public interface IEmailService
    {
        Task SendMessageAsync(SendGridMessage message);

        SendGridMessage CreateMessage(string txtContent, string htmlContent, string subject);

    }
    public class EmailService : IEmailService
    {
        private readonly ISendGridClient _sendGrid;

        public EmailService(ISendGridClient grid)
        {
            _sendGrid = grid;
        }

        public SendGridMessage CreateMessage(string txtContent, string htmlContent, string subject)
        {

            var from= new EmailAddress("no-reply@paddle-finder.com", "Paddle-Finder");

            var to = new EmailAddress("badgerow.luke@gmail.com", "Luke Badgerow");

            //I'm not really sure how I feel about having this static helper here...
            return MailHelper.CreateSingleEmail(from, to, subject, txtContent, htmlContent);
            
        }

        public async Task SendMessageAsync(SendGridMessage message)
        {
            await _sendGrid.SendEmailAsync(message);
        }
        
    }
}