using System;
using System.Threading.Tasks;
using com.brgs.orm.Azure;
using whitewaterfinder.BusinessObjects.Configuration;
using whitewaterfinder.BusinessObjects.Messaging;

namespace whitewaterfinder.Repo.Admin
{
    public interface IEmailRepository
    {
        Task PostMessageToQueue(WaterfinderEmailMessage message);
    }
    public class EmailRepository : IEmailRepository
    {
        private readonly IAzureStorage _storage;

        private readonly EmailRepositoryConfig _config;
        public EmailRepository(IAzureStorage storage, EmailRepositoryConfig config)
        {
            _storage = storage;
            _config = config;
        }

        ///<summary>
        ///post tthe message off to the Azure Storage Queue
        ///</summary>
        public async Task PostMessageToQueue(WaterfinderEmailMessage message)
        {
            await _storage.PostQueueMessageAsync(message, _config.MessageQueue);
        }
    }
}
