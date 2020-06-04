using Newtonsoft.Json.Linq;
namespace whitewaterfinder.Repo.Extensions
{
    public static class JObjectParsingExtension
    {
        public static JToken ParseByIndexes(this JObject obj, string tokenKey1, string tokenKey2 = "", string tokenKey3 = "")
        {
            if(!string.IsNullOrEmpty(tokenKey1) && !string.IsNullOrEmpty(tokenKey2) && !string.IsNullOrEmpty(tokenKey3))
            {
                return obj[tokenKey1][tokenKey2][tokenKey3];
            }
            
            if(!string.IsNullOrEmpty(tokenKey1) && !string.IsNullOrEmpty(tokenKey2) && string.IsNullOrEmpty(tokenKey3))
            {
                return obj[tokenKey1][tokenKey2];
            }

            if(!string.IsNullOrEmpty(tokenKey1) && string.IsNullOrEmpty(tokenKey2) && string.IsNullOrEmpty(tokenKey3))
            {
                return obj[tokenKey1];
            }
            return null;
        }
    }
}