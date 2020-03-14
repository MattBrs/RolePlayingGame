using System;

namespace _021Lab_Gdr {
    class Program {
        static void Main(string[] args) {
            Creature goblin1 = new Goblin("el goblino", 4,13,8);
            Creature goblin2 = new Goblin("scum", 2,8,16);
            Console.WriteLine("match started");
            while (goblin1.IsAlive() && goblin2.IsAlive()) {
                Console.WriteLine(goblin1);
                Console.WriteLine(goblin2);
                goblin1.Attack(goblin2);
                goblin2.Attack(goblin1);
                
            }

            Console.WriteLine("match ended");
            
            
        }
    }
}