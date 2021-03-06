using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Vega.Core.Models
{
    public class Fighter
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Power { get; set; }
        [Required]
        public int Speed { get; set; }
        [Required]
        public bool IsFinalForm { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public ICollection<FighterSkill> Skills { get; set; }
        public Fighter()
        {
            Skills  = new Collection<FighterSkill>();
        }


    }
}