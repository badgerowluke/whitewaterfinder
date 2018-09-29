using System;
namespace whitewaterfinder.BusinessObjects.USGSResponses
{
    public class USGSRiverResponse
    {
        public USGSRiverValue Value { get; set; }
        public USGSRiverResponse() {
        }

    }
    public class USGSRiverValue {
        public USGSRiverQueryInfo QueryInfo { get; set; }
		public USGSRiverTimeSeries[] TimeSeries { get; set; }
        public USGSRiverValue() {

        }
    }
    public class USGSRiverQueryInfo {
        
    }
    public class USGSRiverTimeSeries
    {
        public USGSSourceInfo SourceInfo { get; set; }
        public USGSRiverVariableInfo Variable { get; set; }
        public USGSRiverDataValueCollection[] Values { get; set; }
    }
    public class USGSRiverDataValueCollection {
        public USGSRiverData[] Value { get; set; }

    }
    public class USGSRiverData {
        public string Value { get; set; }
		public object[] Qualifier { get; set; }
		public string DateTime { get; set; }
    }
    public class USGSRiverVariableInfo {
        public string VariableName { get; set; }
        public string VariableDescription { get; set; }
        public string ValueType { get; set; }
        public USGSRiverUnits unit { get; set; }
    }
    public class USGSRiverUnits {
        public string UnitCode { get; set; }
    }
}
