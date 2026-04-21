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

        public Fish? Partner { get; set; }

        public Fish (string name, Gender gender)
        {
            Name = name;
            Gender = gender;
      
        }
        public abstract void ToEat();
        public abstract Fish GiveBirth(string name, Gender gender);
        public override void Act()
        {
            // perdre 1 PV de faim
             TakeDamage(1);

            // si PV <= 5 on mange
            if (Pv <= 5)
             {
               ToEat(); 
             }
            



        }
        private static Random _random = new Random();
        public Fish? TryReproduce()
        {
            if (Partner == null) return null;
            if (!Partner.IsAlive) return null;
            if (Partner.Gender == Gender) return null;
            if (Age == 0) return null;

            Gender babyGender = _random.Next(0, 2) == 0 ? Gender.Male : Gender.Female;
            return GiveBirth("Baby", babyGender);

        }
    }
}
