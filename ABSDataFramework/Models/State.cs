using System.ComponentModel.DataAnnotations;

namespace ABSDataFramework.Models
{
    public class DimState
    {
        [Key]
        public long id { get; set; }

        public string name { get; set; }

        public int ABSStateId { get; set; }
    }
}
