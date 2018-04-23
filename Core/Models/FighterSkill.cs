using System.ComponentModel.DataAnnotations.Schema;

namespace Vegas.Core.Models
{
    [Table("FighterSkills")]
    public class FighterSkill
    {
        public int FighterId { get; set; }
        public int SkillId { get; set; }
        public Fighter Fighter { get; set; }
        public Skills Skills { get; set; }
    }
}