using System.ComponentModel.DataAnnotations;

namespace ABSDataFramework.Models
{
    public class state
    {
        [Key]
        public long id { get; set; }

        public string name { get; set; }
    }
}
