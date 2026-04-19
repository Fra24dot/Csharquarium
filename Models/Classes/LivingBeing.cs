using System;
using System.Collections.Generic;
using System.Text;

namespace Csharquarium.Models.Entities
{
    public abstract class LivingBeing
    {
        //champs
        public int Age { get; private set; } = 0;
        public int Pv { get; private set; } = 10;
        public bool IsAlive => Pv > 0;

        //méthodes
        public void TakeDamage(int amount) 
        {
            Pv = Math.Max(0, Pv - amount);
        }

        public void Heal(int amount)
        {
            Pv = Math.Min(10, Pv + amount);
        }
        
        public void GrowOlder()
        {
            this.Age++;
            if (this.Age>20)
            {
               Pv = 0;
            }
        }

        public abstract void Act();
    }
}
