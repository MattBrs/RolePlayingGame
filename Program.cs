using System;

namespace _021Lab_Gdr {
    class Program {
        static void Main(string[] args) {
            Creature goblin1 = new Goblin("el goblino", 15,6,8);
            Creature goblin2 = new Goblin("scum", 10,8,16);
            Console.WriteLine("match started\n\n");
            while (goblin1.IsAlive() && goblin2.IsAlive()) {
                goblin1.Attack(goblin2);
                goblin2.Attack(goblin1);
            }

            Console.WriteLine("\n");
            string champion = (goblin1.IsAlive()) ? goblin1.Name : goblin2.Name;
            Console.WriteLine(champion + " won!");
            
            
        }
    }
}