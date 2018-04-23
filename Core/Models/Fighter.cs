using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Vegas.Core.Models
{
    public class Fighter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Power { get; set; }
        public int Speed { get; set; }
        public bool IsFinalForm { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<Skills> Skills { get; set; }
        public Fighter()
        {
            Skills  = new Collection<Skills>();
        }


    }
}