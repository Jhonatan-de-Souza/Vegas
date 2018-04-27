using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Vega.Core.Models
{
    public class Fighter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Power { get; set; }
        public int Speed { get; set; }
        public bool IsFinalForm { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<FighterSkill> Skills { get; set; }
        public Fighter()
        {
            Skills  = new Collection<FighterSkill>();
        }


    }
}