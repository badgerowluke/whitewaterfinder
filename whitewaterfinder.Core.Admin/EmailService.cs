
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

using whitewaterfinder.BusinessObjects.Messaging;

using whitewaterfinder.Repo.Admin;

namespace whitewaterfinder.Core.Admin
{
    public interface IEmailService
    {
        Task SendMessageAsync(SendGridMessage message);

        SendGridMessage CreateMessage(WaterfinderEmailMessage message);
        Task WriteMessageToQueue(WaterfinderEmailMessage message);

    }
    public class EmailService : IEmailService
    {
        private readonly ISendGridClient _sendGrid;

        private readonly IEmailRepository _repo;

        public EmailService(ISendGridClient grid, IEmailRepository repo)
        {
            _sendGrid = grid;
            _repo = repo;
        }
        ///<summary>
        ///cast/convert/generate an official SendGridMessage
        ///</summary>
        ///<param name="message"></param>
        ///<returns>A SendGridMessage representing the internal message type</returns>
        public SendGridMessage CreateMessage(WaterfinderEmailMessage message)
        {

            var from = new EmailAddress(message.AddressFrom, message.NameFrom);

            var to = new EmailAddress(message.AddressTo, message.NameFrom);

            //I'm not really sure how I feel about having this static helper here...
            return MailHelper.CreateSingleEmail(from, to, message.Subject, message.TextContent, message.HtmlContent);
            
        }

        ///<summary>
        ///write an internal message to a Processing queue
        ///</summary>
        ///<param name="message"></param>
        public async Task WriteMessageToQueue(WaterfinderEmailMessage message)
        {
            await _repo.PostMessageToQueue(message);
        }

        ///<summary>
        ///use the sendgrid client to fire off the email message
        ///</summary>
        public async Task SendMessageAsync(SendGridMessage message)
        {
            await _sendGrid.SendEmailAsync(message);
        }
        
    }
}