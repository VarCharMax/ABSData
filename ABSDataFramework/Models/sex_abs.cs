using System.ComponentModel.DataAnnotations;

namespace ABSDataFramework.Models
{
    public class sex_abs
    {
        [Key]
        public long id { get; set; }

        public string name { get; set; }
    }
}
