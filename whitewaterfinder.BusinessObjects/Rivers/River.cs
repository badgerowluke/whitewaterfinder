using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
namespace whitewaterfinder.BusinessObjects.Rivers
{
    public interface IRiver
    {
        string Id { get; set; }
        string Name { get; set; }
        string RiverId { get; set; }
        string Latitude { get; set; }
        string Srs { get; set; }
        string State { get; set; }
        string StateCode { get; set; }
    }

    public class River : IRiver
    {
        public string Id { get; set; }
		public string Name { get; set; }
		public string RiverId { get; set; }
		public string Latitude { get; set; }
		public string Longitude { get; set; }
		public string Srs { get; set; }
        public RiverData[] Levels { get; set; }
        public RiverData[] Flow { get; set; }
        public RiverData[] RiverData { get; set; }
        public string State { get; set; }
        public string StateCode { get; set; }

		public River() {
		}
    }
    public class RiverData {
        public DateTime DateTime { get; set; }
        public object Value { get; set; }
        public string Flow { get; set; }
        public string Level { get; set; }
    }
    public class RiverEntity : TableEntity, IRiver
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
		public string Name { get; set; }
		public string RiverId { get; set; }
		public string Latitude { get; set; }
		public string Longitude { get; set; }
		public string Srs { get; set; }
        public RiverData[] Levels { get; set; }
        public RiverData[] Flow { get; set; }
        public RiverData[] RiverData { get; set; }
        public string State { get; set; }
        public string StateCode { get; set; }

        public RiverEntity()
        {
            
        }

        public RiverEntity(Guid reportId)
        {
            RowKey = reportId.ToString();
        }
    }

}
