using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace whitewaterfinder.BusinessObjects.Rivers
{
     public static class RiverIdBuilder
     {

         public static string BuildRiverIdHash(this IRiver r)
         {
            var _hasher = new MD5CryptoServiceProvider();
            var bytes = _hasher.ComputeHash(Encoding.UTF8.GetBytes($"{r.StateCode}{r.RiverId}"));
            var builder = new StringBuilder();
            for(var x =0; x < bytes.Length; x++)
            {
                builder.Append(bytes[x].ToString("x2"));
            }
            return builder.ToString();
         }
     }
}