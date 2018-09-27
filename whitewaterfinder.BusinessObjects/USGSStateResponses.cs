using System;
namespace whitewaterfinder.BusinessObjects
{
    public class USGSStateResponse
    {
        public USGSValue Value { get; set; }
        public USGSStateResponse() {
        }
    }
    public class USGSValue
    {
        public USGSQueryInfo QueryInfo { get; set; }
        public USGSTimeSeries[] TimeSeries { get; set; }
        public USGSValue() {

        }
    }
    public class USGSQueryInfo
    {

    }
    public class USGSTimeSeries
    {
        public USGSSourceInfo SourceInfo { get; set; }
    }
    public class USGSSourceInfo
    {
        public string SiteName { get; set; }
        public USGSSiteCode[] SiteCode { get; set; }
        public USGSGeoloc Geolocation { get; set; }
    }
    public class USGSGeoloc 
    {
        public Location GeogLocation { get; set; }
    }
    public class USGSSiteCode 
    {
        public string Value { get; set; }
        public string Network { get; set; }
        public string AgencyCode { get; set; }
    }
    public class Location 
    {
        public string SRS { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}