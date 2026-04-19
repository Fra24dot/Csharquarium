using Csharquarium.Models.Classes.Basics;
using Csharquarium.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Csharquarium.Models.Classes.Feeding
{
    public abstract class Herbivore : Fish
    {
        protected Herbivore(string name, Gender gender) : base(name, gender)
        {
        }

        public SeaWeed SeaWeedPrey { get; set; }

        public override void ToEat()
        {

            if (SeaWeedPrey == null) return;
            SeaWeedPrey.TakeDamage(2);
            Heal(3);

        }
    }
}
