namespace whitewaterfinder.BusinessObjects.Configuration
{
    public class RiverRepositoryConfig
    {
        public string BaseUSGSURL { get; set; }
        public string RiverTable { get; set; }
        public string SearchKey { get; set; }
        public string AzureSearchUrl { get; set; }
        public string AzureSearchAdminUrl { get; set; }
        public string AzureSearchAdminKey { get; set; }
        public string StorageConnection { get; set; }
        public string RiverFile { get; set; }
    }

}