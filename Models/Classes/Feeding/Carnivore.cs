using Csharquarium.Models.Classes.Basics;
using Csharquarium.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Csharquarium.Models.Classes.Feeding
{
    public abstract class Carnivore : Fish
    {
        protected Carnivore(string name, Gender gender) : base(name, gender)
        {
             
        }
        public Fish Prey { get; set; }

        public override void ToEat()
        {
            if (Prey == null) return;
            Prey.TakeDamage(4);
            Heal(5);
            
        }


    }
}
