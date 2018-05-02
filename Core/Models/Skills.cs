
using System.ComponentModel.DataAnnotations;

namespace Vega.Core.Models
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AttackRange { get; set; }
    }
}