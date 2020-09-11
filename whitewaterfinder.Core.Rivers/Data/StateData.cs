using System.Collections.Generic;
using System.Linq;

namespace whitewaterfinder.Core.Rivers.Data
{
    public abstract class StateData
    {
        protected IDictionary<string, string> States = new Dictionary<string,string>()
        {
            { "Alabama","AL" },
            { "Alaska","AK" },
            { "Arizona","AZ" },
            { "Arkansas","AR" },
            { "California","CA" },
            { "Colorado","CO" },
            { "Connecticut","CT" },
            { "Delaware","DE" },
            { "Florida","FL" },
            { "Georgia","GA" },
            { "Hawaii","HI" },
            { "Idhao","ID" },
            { "Illinois","IL" },
            { "Indiana","IN" },
            { "Iowa", "IA" },
            { "Kansas", "KS" },
            { "Kentucky", "KY" },
            { "Louisiana", "LA" },
            { "Maine", "ME" },
            { "Maryland", "MD" },
            { "Massachusets", "MA" },
            { "Michigan", "MI" },
            { "Minnesota", "MN" },
            { "Mississippi", "MS" },
            { "Missouri", "MO" },
            { "Montana", "MT" },
            { "Nebraska", "NE" },
            { "Nevada", "NV" },
            { "New Hampshire", "NH" },
            { "New Jersey", "NJ" },
            { "New Mexico", "NM" },
            { "New York", "NY" },
            { "North Carolina", "NC" },
            { "North Dakota", "ND" }, 
            { "Ohio", "OH" },
            { "Oklahoma", "OK" },
            { "Oregon", "OR" },
            { "Pennsylvania", "PA" },
            { "Rhode Island", "RI" },
            { "South Carolina", "SC" },
            { "South Dakota", "SD" },
            { "Tennessee", "TN" },
            { "Texas", "TX" },
            { "Utah", "UT" },
            { "Vermont", "VT" },
            { "Virginia", "VA" },
            { "Washington", "WA" },
            { "West Virginia", "WV" },
            { "West by God", "WV" },
            { "Wisconsin", "WI" },
            { "Wyoming", "WY" }
        };
        public string GetStateCode(string val)
        {
            var stateCodePair = States.FirstOrDefault(s => s.Value.ToLower().Equals(val.ToLower()));
            var stateNamePair = States.FirstOrDefault(s => s.Key.ToLower().Equals(val.ToLower()));
            if(!string.IsNullOrEmpty(stateCodePair.Value))
            {
                return stateCodePair.Value;
            }
            if(!string.IsNullOrEmpty(stateNamePair.Value))
            {
                return stateNamePair.Value;
            }

            return string.Empty;
        }
    }
}