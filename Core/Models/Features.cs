using System.ComponentModel.DataAnnotations;

namespace Vegas.Core.Models
{
    public class Features
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        
    }
}