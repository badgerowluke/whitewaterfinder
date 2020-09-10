using System;
using System.Net.Http;
using System.Threading.Tasks;

using whitewaterfinder.BusinessObjects.Users;

namespace whitewaterfinder.Core.Admin
{
    public interface IUserInformationService
    {

    }

    /// <summary>
    /// Use this service to reach out to Auth0 and retreive information about 
    /// </summary>
    public class UserInformationService
    {
        private readonly string _userSearchUrl;

        private readonly HttpClient _client;

        public UserInformationService()
        {


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchVal"></param>
        /// <returns></returns>
        public async Task<User> SearchUser(string searchVal)
        {
            var response = await _client.SendAsync(null);

            return new User();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subscriptionId">The Auth0 assigned sub_id</param>
        /// <returns>User Object</returns>
        public async Task<User> GetUser(string subscriptionId)
        {
            var response = await _client.SendAsync(null);
            return new User();
        }
    }
}
