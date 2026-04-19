using System;
using System.Collections.Generic;
using System.Text;
using Csharquarium.Models.Entities;
using Csharquarium.Models.Enums;


namespace Csharquarium.Models.Classes.Basics
{
    public abstract class Fish: LivingBeing
    {
        public string Name { get; private set; }

        public Gender Gender { get; private set; }

        public Fish (string name, Gender gender)
        {
            Name = name;
            Gender = gender;
      
        }
        public abstract void ToEat();
    }
}
