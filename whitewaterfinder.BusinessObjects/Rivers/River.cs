using System;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
namespace whitewaterfinder.BusinessObjects.Rivers
{
    public class River
    {
		public string Name { get; set; }
		public string RiverId { get; set; }
		public string Latitude { get; set; }
		public string Longitude { get; set; }
		public string Srs { get; set; }
        public RiverData[] Levels { get; set; }
        public RiverData[] Flow { get; set; }
        public RiverData[] RiverData { get; set; }

		public River() {
		}
    }
    public class RiverData {
        public DateTime DateTime { get; set; }
        public object Value { get; set; }
        public string Flow { get; set; }
        public string Level { get; set; }
    }
    public class RiverEntity : TableEntity
    {
        public DateTime Date { get; set; }
        public string RiverName { get; set; }
        public string RiverId { get; set; }


        public RiverEntity(Guid reportId)
        {
            RowKey = reportId.ToString();
        }
    }
}
