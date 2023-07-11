using System.ComponentModel.DataAnnotations;

namespace ABSDataFramework.Models
{
    public class Region
    {
        [Key]
        public long id { get; set; }

        public string name { get; set; }

        public int ABSRegionId { get; set; }
    }
}
