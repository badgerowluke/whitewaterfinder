namespace whitewaterfinder.BusinessObjects.Configuration
{
    public class RiverRepositoryConfig
    {
        public string BaseUSGSURL { get; set; }
        public string RiverTable { get; set; }
        public string AzureSearchKey { get; set; }
        public string AzureSearchUrl { get; set; }
        public string BlobStore { get; set; }
    }
}