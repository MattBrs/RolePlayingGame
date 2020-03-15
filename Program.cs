using System;
using System.Collections.Generic;
using System.Linq;

namespace _021Lab_Gdr {
    class Program {
        static void Main(string[] args) {
            Creature goblin1 = new Goblin("prok", 15,6,8);
            Creature goblin2 = new Goblin("krold", 10,8,16);
            Creature warrior1 = new Warrior("Goblin slayer", 30, 20, 50, 1, new Sword(), new PlateArmor());
            
            //match between a goblin and a warrior
            Console.WriteLine("A clash between " + goblin1.Name + " and " + warrior1.Name + " has begun");
            
            while (goblin1.IsAlive() && warrior1.IsAlive()) {
                goblin1.Attack(goblin2);
                warrior1.Attack(goblin1);
            }
            
            Console.Write("match ended: ");
            string champion = (goblin1.IsAlive()) ? goblin1.Name : warrior1.Name;
            Console.WriteLine(champion + " won!");
            
            //match between 2 armies -> Ith member of the army fight against Ith member of the other army. Wins who has the most survivors.
            int totalDeaths = 0, armyCapacity = 25;
            Random rnd = new Random();
            var army1 = new List<Creature>();
            var army2 = new List<Creature>();
            
            for (int i = 0; i < armyCapacity; i++) {
                int tmp = rnd.Next(0, 2);
                if(tmp == 0) army1.Add(new Goblin());
                else army1.Add(new Warrior());
                
                tmp = rnd.Next(0, 2);
                if(tmp == 0) army2.Add(new Goblin());
                else army2.Add(new Warrior());
                
            }

            while (totalDeaths < armyCapacity) {
                for (int i = 0; i < armyCapacity; i++) {
                    army1[i].Attack(army2[i]);
                    Console.WriteLine(army1[i].Name + " vs " + army2[i].Name);
                    army2[i].Attack(army1[i]);
                    if (army1[i].IsDead()) totalDeaths++;
                    if (army2[i].IsDead()) totalDeaths++;
                }
            }

            string winner = "";
            var army1Survivors = army1.Count(x => x.IsAlive());
            var army2Survivors = army2.Count(x => x.IsAlive());
            
            Console.WriteLine(army1Survivors);
            Console.WriteLine(army2Survivors);
            
            if (army1Survivors > army2Survivors) winner = "Army 1 is the winner";
            else if (army1Survivors < army2Survivors) winner = "Army 2 is the winner";
            else if (army1Survivors == army2Survivors) winner = "No one won";
            Console.WriteLine(winner);

        }
    }
}