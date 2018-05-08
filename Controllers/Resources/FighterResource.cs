using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Vega.Controllers.Resources
{
    public class FighterResource
    {
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
        // public DateTime DateOfBirth { get; set; }
        public ICollection<SkillsResource> Skills { get; set; }
        public FighterResource()
        {
            Skills = new Collection<SkillsResource>();
        }

    }
}