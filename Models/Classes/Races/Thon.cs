using Csharquarium.Models.Classes.Feeding;
using Csharquarium.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Csharquarium.Models.Classes.Races
{
    public class Thon : Carnivore
    {
        public Thon(string name, Gender gender) : base(name, gender)
        {
        }

        public override void Act()
        {
            throw new NotImplementedException();
        }
    }
}
