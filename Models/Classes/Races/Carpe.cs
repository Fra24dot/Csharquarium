using Csharquarium.Models.Classes.Basics;
using Csharquarium.Models.Classes.Feeding;
using Csharquarium.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Csharquarium.Models.Classes.Races
{
    public class Carpe : Herbivore
    {
        public Carpe(string name, Gender gender) : base(name, gender)
        {
        }

        public override Fish GiveBirth(string name, Gender gender)
        {
            return new Carpe(name, gender);
        }
    }
}
