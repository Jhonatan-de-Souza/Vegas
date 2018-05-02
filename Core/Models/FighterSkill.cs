using System.ComponentModel.DataAnnotations.Schema;

namespace Vega.Core.Models
{
    [Table("FighterSkills")]
    public class FighterSkill
    {
        public int FighterId { get; set; }
        public int SkillId { get; set; }
        public Fighter Fighter { get; set; }
        public Skill Skill { get; set; } 
    }
}