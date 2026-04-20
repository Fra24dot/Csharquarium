

using Csharquarium;
using Csharquarium.Models.Classes.Basics;
using Csharquarium.Models.Classes.Races;
using Csharquarium.Models.Enums;

//Création d'un nouveau aquarium
Aquarium aquarium = new Aquarium();


//On ajout des poissons

// Carnivores
aquarium.AddFish(new Thon("Nemo", Gender.Male));
aquarium.AddFish(new Merou("Goliath", Gender.Male));
aquarium.AddFish(new PoissonClown("Coral", Gender.Female));

// Herbivores
aquarium.AddFish(new Carpe("Bob", Gender.Female));
aquarium.AddFish(new Bar("Luna", Gender.Female));
aquarium.AddFish(new Sole("Plato", Gender.Male));

// Algues
aquarium.AddSeaWeed(new SeaWeed());
aquarium.AddSeaWeed(new SeaWeed());
aquarium.AddSeaWeed(new SeaWeed());


//On fait tourner la simulation
for (int i = 0; i < 10; i++)
{
    aquarium.NextTurn();
}