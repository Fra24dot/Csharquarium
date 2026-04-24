using Csharquarium.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Csharquarium.Models.Classes.Basics
{
    public class SeaWeed: LivingBeing
    {
        public SeaWeed() : base() { }
        public SeaWeed(int initialPv) : base(initialPv) { } // PV personnalisé
        //Méthode abstraite de LivingBeing implémentée
        public override void Act()
        {

            Heal(1);
        }

        public SeaWeed? TryReproduce()
        {
            if (Pv >= 10)
            {
                int babyPv = Pv / 2;
                // l'algue se divise et perd la moitié de ses PV
                TakeDamage(babyPv);
                return new SeaWeed(babyPv); // nouvelle algue avec 10 PV de base
            }
            return null;
        }
    }
}
