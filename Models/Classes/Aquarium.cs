using Csharquarium.Models.Classes.Basics;
using Csharquarium.Models.Classes.Feeding;
using Csharquarium.Models.Entities;
using Csharquarium.Models.Enums;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Xml.Linq;


namespace Csharquarium
{
    public class Aquarium
    {
        private List<Fish> _fishes = new List<Fish>();

        private List<SeaWeed> _seaWeeds = new List<SeaWeed>();
        private Random _random = new Random();
        private int _turn = 0;
        


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

        public IReadOnlyList<Fish> Get_fishes()
        {
            return _fishes.AsReadOnly();
        }

        public void NextTurn()
        {
            _turn++;

            foreach (Fish fish in _fishes)
            {
                if (fish is Herbivore h) h.SeaWeedPrey = null;
                else if (fish is Carnivore c) c.Prey = null;
                fish.Partner = null;
            }

            // tout le monde vieillit
            foreach (LivingBeing being in _fishes.Cast<LivingBeing>().Concat(_seaWeeds))
            {
                being.GrowOlder();
            }

            // supprimer les morts
            _fishes.RemoveAll(f => !f.IsAlive);
            _seaWeeds.RemoveAll(s => !s.IsAlive);


            List<SeaWeed> availableSeaWeeds = new List<SeaWeed>(_seaWeeds);
            // assigner les proies
            foreach (Fish fish in _fishes)
                AssignTarget(fish, availableSeaWeeds);


            // chaque être vivant agit

            foreach (LivingBeing being in _fishes.Cast<LivingBeing>().Concat(_seaWeeds))
            {
                being.Act();
            }

            List<Fish> babies = new List<Fish>();
            foreach (Fish fish in _fishes)
            {
                Fish? baby = fish.TryReproduce();
                if (baby != null) babies.Add(baby);
            }
            _fishes.AddRange(babies);

            // supprimer les morts à nouveau 
            _fishes.RemoveAll(f => !f.IsAlive);
            _seaWeeds.RemoveAll(s => !s.IsAlive);

            DisplayReport();


        }

        
        // méthode pour assigner les proies
        private void AssignTarget(Fish fish, List<SeaWeed> availableSeaWeeds)
        {

            if (fish is Herbivore herbivore)
            {
                if (herbivore.Pv > 5) return;
                if (availableSeaWeeds.Count == 0) return;
                int index = _random.Next(0, availableSeaWeeds.Count);
                herbivore.SeaWeedPrey = availableSeaWeeds[index];
                Console.WriteLine($"Liste avant RemoveAt : {availableSeaWeeds.Count} algues");
                availableSeaWeeds.RemoveAt(index);
                Console.WriteLine($"Liste après RemoveAt : {availableSeaWeeds.Count} algues");
            }
            else if (fish is Carnivore carnivore)
            {
                if (carnivore.Pv > 5) return;
                List<Fish> eligiblePrey = _fishes
                    .Where(f => f != carnivore                       
                        && f.GetType() != carnivore.GetType())   
                    .ToList();

                if (eligiblePrey.Count == 0) return; 
                int index = _random.Next(0, eligiblePrey.Count);
                carnivore.Prey = eligiblePrey[index];

            }

            Fish? partner = _fishes
                .Where(f => f != fish && f.GetType() == fish.GetType())
                .OrderBy(f => _random.Next())
                .FirstOrDefault();

            fish.Partner = partner;

        }

        private void DisplayReport()
        {
            Console.WriteLine($"=== Tour {_turn} ===");
            Console.WriteLine($"Algues vivantes : {_seaWeeds.Count}");
            Console.WriteLine("Poissons :");
            foreach (Fish fish in _fishes)
            {
                Console.WriteLine($"- {fish.Name} ({fish.GetType().Name}) - {fish.Gender} - {fish.Pv} PV");
            }
        }
    }
}


