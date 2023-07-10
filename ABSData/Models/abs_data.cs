namespace ABSData.Models
{
    public class abs_data
    {
        public long id { get; set; }

        public sex_abs Sex { get; set; }

        public string AgeCode { get; set; }

        public string Age { get; set; }

        public state State { get; set; }

        public string RegionType { get; set; }

        public string GeographyLevel { get; set; }

        public string ASGS_2016 { get; set; }

        public region Region { get; set; }

        public int Time { get; set; }

        public int CensusYear { get; set; }

        public int Value { get; set; }
    }
}
