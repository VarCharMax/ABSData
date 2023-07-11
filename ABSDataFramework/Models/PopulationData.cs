using System.Collections.Generic;

namespace ABSDataFramework.Models
{
    public class PopulationData
    {
        public int RegionCode { get; set; }

        public string RegionName { get; set; }

        public List<DataList> Data { get; set; } = new List<DataList>();
    }

    public class DataList
    {
        public string Age { get; set; }

        public string Sex { get; set; }

        public int CensusYear { get; set; }

        public int Population { get; set; }
    }
}
