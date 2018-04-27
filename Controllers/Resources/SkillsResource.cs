using System.ComponentModel.DataAnnotations;

namespace Vega.Controllers.Resources
{
    public class SkillsResource
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AttackRange { get; set; }
    }
}