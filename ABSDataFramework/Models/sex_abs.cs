using System.ComponentModel.DataAnnotations;

namespace ABSDataFramework.Models
{
    public class Sex
    {
        [Key]
        public long id { get; set; }

        public string name { get; set; }

        public int ABSSexId { get; set; }
    }
}
