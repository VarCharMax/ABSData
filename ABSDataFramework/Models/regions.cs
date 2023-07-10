using System.ComponentModel.DataAnnotations;

namespace ABSDataFramework.Models
{
    public class region
    {
        [Key]
        public long id { get; set; }

        public string name { get; set; }
    }
}
