using Csharquarium.Models.Classes.Basics;
using Csharquarium.Models.Classes.Feeding;
using Csharquarium.Models.Entities;
using Csharquarium.Models.Enums;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Xml.Linq;


namespace Csharquarium
{
    public class Acquarium
    {
        private List<Fish> _fishes = new List<Fish>();

        private List<SeaWeed> _seaWeeds = new List<SeaWeed>();
        private Random _random = new Random();


        public void AddFish(Fish fish)
        {
            if (fish == null) return;
            _fishes.Add(fish);
        }
        public void AddSeaWeed(SeaWeed seaWeed)
        {
            if (seaWeed == null) return;
            _seaWeeds.Add(seaWeed);

        }

        public List<Fish> Get_fishes1()
        {
            return _fishes;
        }

        public void NextTurn()
        {
            // tout le monde vieillit
            foreach (LivingBeing being in _fishes.Cast<LivingBeing>().Concat(_seaWeeds))
            {
                being.GrowOlder();
            }

            // supprimer les morts
            _fishes.RemoveAll(f => !f.IsAlive);
            _seaWeeds.RemoveAll(s => !s.IsAlive);

            // assigner les proies
            foreach (Fish fish in _fishes)
                AssignPrey(fish);


            // chaque être vivant agit

            foreach (LivingBeing being in _fishes.Cast<LivingBeing>().Concat(_seaWeeds))
            {
                being.Act();
            }

            // supprimer les morts à nouveau 
            _fishes.RemoveAll(f => !f.IsAlive);
            _seaWeeds.RemoveAll(s => !s.IsAlive);


        }


        // méthode pour assigner les proies
        private void AssignPrey(Fish fish)
        {
            if (fish is Herbivore herbivore)
            {
                if (_seaWeeds.Count == 0) return;
                int index = _random.Next(0, _seaWeeds.Count);
                herbivore.SeaWeedPrey = _seaWeeds[index];
            }
            else if (fish is Carnivore carnivore)
            {
                List<Fish> eligiblePrey = _fishes
                    .Where(f => f != carnivore                       
                        && f.GetType() != carnivore.GetType())   
                    .ToList();

                if (eligiblePrey.Count == 0) return; 
                int index = _random.Next(0, eligiblePrey.Count);
                carnivore.Prey = eligiblePrey[index];
            }
        }
    }
}


