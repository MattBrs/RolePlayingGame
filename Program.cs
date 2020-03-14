using System;

namespace _021Lab_Gdr {
    class Program {
        static void Main(string[] args) {
            Creature goblin1 = new Goblin("prok", 15,6,8);
            Creature goblin2 = new Goblin("krold", 10,8,16);
            Creature warrior1 = new Warrior("Goblin slayer", 30, 20, 50, 1, new Sword(), new PlateArmor());
            
            Console.WriteLine("A clash between " + goblin1.Name + " and " + warrior1.Name + " has begun");
            
            while (goblin1.IsAlive() && warrior1.IsAlive()) {
                goblin1.Attack(goblin2);
                warrior1.Attack(goblin1);
            }
            Console.Write("match ended: ");
            string champion = (goblin1.IsAlive()) ? goblin1.Name : warrior1.Name;
            Console.WriteLine(champion + " won!");
        }
    }
}