using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Vega.Controllers.Resources
{
    public class FighterResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Power { get; set; }
        public int Speed { get; set; }
        public bool IsFinalForm { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<SkillsResource> Skills { get; set; }
        public FighterResource()
        {
            Skills = new Collection<SkillsResource>();
        }

    }
}