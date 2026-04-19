using Csharquarium.Models.Classes.Feeding;
using Csharquarium.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Csharquarium.Models.Classes.Races
{
    public class PoissonClown : Carnivore
    {
        public PoissonClown(string name, Gender gender) : base(name, gender)
        {
        }

        //Méthode abstraite de LivingBeing implémentée
        public override void Act()
        {
            throw new NotImplementedException();
        }
    }
}
