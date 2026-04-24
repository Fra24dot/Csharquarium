

using Csharquarium;
using Csharquarium.Models.Classes.Basics;
using Csharquarium.Models.Classes.Races;
using Csharquarium.Models.Enums;

//Création d'un nouveau aquarium
Aquarium aquarium = new Aquarium();


//On ajout des poissons

// Thons
aquarium.AddFish(new Thon("Nemo", Gender.Male));
aquarium.AddFish(new Thon("Nadia", Gender.Female));

// Mérous
aquarium.AddFish(new Merou("Goliath", Gender.Male));
aquarium.AddFish(new Merou("Gloria", Gender.Female));

// Poissons-clowns
aquarium.AddFish(new PoissonClown("Coral", Gender.Female));
aquarium.AddFish(new PoissonClown("Cleo", Gender.Male));

// Carpes
aquarium.AddFish(new Carpe("Bob", Gender.Female));
aquarium.AddFish(new Carpe("Bruno", Gender.Male));

// Bars
aquarium.AddFish(new Bar("Luna", Gender.Female));
aquarium.AddFish(new Bar("Leo", Gender.Male));

// Soles
aquarium.AddFish(new Sole("Plato", Gender.Male));
aquarium.AddFish(new Sole("Petra", Gender.Female));

// Algues
aquarium.AddSeaWeed(new SeaWeed());
aquarium.AddSeaWeed(new SeaWeed());
aquarium.AddSeaWeed(new SeaWeed());
aquarium.AddSeaWeed(new SeaWeed());
aquarium.AddSeaWeed(new SeaWeed());

//On fait tourner la simulation
for (int i = 0; i < 30; i++)
{
    aquarium.NextTurn();
}

aquarium.Save(Path.Combine(Directory.GetCurrentDirectory(), "sauvegarde.json"));
Console.WriteLine($"Sauvegardé dans : {Directory.GetCurrentDirectory()}");