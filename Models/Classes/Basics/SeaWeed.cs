using Csharquarium.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Csharquarium.Models.Classes.Basics
{
    public class SeaWeed: LivingBeing
    {
        //Méthode abstraite de LivingBeing implémentée
        public override void Act()
        {
            Heal(1);
        }
    }
}
