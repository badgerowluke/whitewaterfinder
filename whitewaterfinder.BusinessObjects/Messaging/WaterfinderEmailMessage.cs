namespace whitewaterfinder.BusinessObjects.Messaging
{
    ///<summary>
    ///internal wrapper for building a SendGridMessage
    ///this is to prevent package dependency creep
    ///</summary>
    public class WaterfinderEmailMessage
    {
        public string NameTo { get; set; }

        public string NameFrom { get; set; }

        public string AddressTo { get; set; }

        public string AddressFrom { get; set; }

        public string TextContent { get; set; }

        public string HtmlContent { get; set; }
        
        public string Subject { get; set; }
    }
}