using System.ComponentModel.DataAnnotations;

namespace ABSDataFramework.Models
{
    public class FactPopulation
    {
        [Key]
        public long id { get; set; }

        public Sex Sex { get; set; }

        public Age AgeCode { get; set; }

        public DimState State { get; set; }

        public string RegionType { get; set; }

        public string GeographyLevel { get; set; }

        public Region Region { get; set; }

        public int Time { get; set; }

        public int CensusYear { get; set; }

        public int Value { get; set; }
    }
}
