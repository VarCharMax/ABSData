using System.ComponentModel.DataAnnotations;

namespace ABSDataFramework.Models
{
    public class Age
    {
        [Key]
        public long id { get; set; }

        public string name { get; set; }

        public int ABSAgeId { get; set; }
    }
}
