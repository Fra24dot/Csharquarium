A C# console application simulating an aquarium ecosystem, built as an exercise in Object-Oriented Programming.

📖 Description
Csharquarium simulates the life of fish and seaweed in an aquarium over multiple turns. Each turn, living beings age, eat, reproduce, and may die. The simulation demonstrates core OOP principles in C#.
This project is based on the classic "Csharquarium" exercise from OpenClassrooms, adapted for a C# OOP course.

🏗️ Architecture
LivingBeing (abstract)
├── SeaWeed
└── Fish (abstract)
    ├── Herbivore (abstract) → Carpe, Bar, Sole
    └── Carnivore (abstract) → Thon, Merou, PoissonClown
    
Class responsibilities

LivingBeing — base class for all living entities. Manages health points (PV), age, damage, and healing.
SeaWeed — gains 1 PV per turn, reproduces by splitting when PV ≥ 10.
Fish — has a name and gender, loses 1 PV per turn from hunger, eats when PV ≤ 5, reproduces with a partner of the same species and opposite gender.
Herbivore — eats seaweed (+3 PV), seaweed loses 2 PV.
Carnivore — eats fish of a different species (+5 PV), prey loses 4 PV.
Aquarium — orchestrates each turn: aging, death, prey assignment, actions, reproduction, and reporting.


💡 OOP Concepts Demonstrated

Abstraction — LivingBeing and Fish are abstract classes that cannot be instantiated directly
Inheritance — SeaWeed and Fish inherit from LivingBeing, Herbivore and Carnivore inherit from Fish
Polymorphism — Act() and ToEat() behave differently depending on the concrete class
Encapsulation — PV and Age use private set, only modified through TakeDamage(), Heal(), and GrowOlder()
Null safety — null checks throughout to prevent NullReferenceException


🎮 Simulation Rules
RuleDetailStarting PV10 for all living beingsDeathPV reaches 0, or age exceeds 20 turnsHungerFish lose 1 PV per turnEating thresholdFish eat 
when PV ≤ 5Herbivore meal+3 PV for fish, -2 PV for seaweedCarnivore meal+5 PV for fish, -4 PV for preyFish reproductionSame species, opposite gender, 
not hungrySeaweed reproductionSplits in two when PV ≥ 10Carnivore restrictionCannot eat itself or its own species

🚀 How to Run
Prerequisites

.NET 10 SDK

Run the project
bashgit clone https://github.com/your-username/Csharquarium.git
cd Csharquarium
dotnet run
Save the simulation state
The simulation can be saved to a JSON file at any point:
csharpaquarium.Save("sauvegarde.json");

📁 Project Structure
Csharquarium/
├── Models/
│   ├── Entities/
│   │   └── LivingBeing.cs
│   ├── Classes/
│   │   ├── Basics/
│   │   │   ├── Fish.cs
│   │   │   └── SeaWeed.cs
│   │   ├── Feeding/
│   │   │   ├── Herbivore.cs
│   │   │   └── Carnivore.cs
│   │   └── Races/
│   │       ├── Carpe.cs
│   │       ├── Bar.cs
│   │       ├── Sole.cs
│   │       ├── Thon.cs
│   │       ├── Merou.cs
│   │       └── PoissonClown.cs
│   └── Enums/
│       └── Gender.cs
├── Aquarium.cs
└── Program.cs

👩‍💻 Author
Francesca Russo — Junior .NET Developer
Developed as part of a C# OOP training course.
