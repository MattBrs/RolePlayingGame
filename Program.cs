using System;
using System.Collections.Generic;
using System.Linq;

namespace _021Lab_Gdr {
    class Program {
        static void Main(string[] args) {
            Creature goblin1 = new Goblin("prok", 15,6,8);
            Creature goblin2 = new Goblin("krold", 10,8,16);
            Creature warrior1 = new Warrior("Goblin slayer", 25, 20, 51, 1, new Sword(), new PlateArmor());
            Creature warrior2 = new Warrior("Josuke", 32, 25,30,1,new Sword(), new PlateArmor());
            Creature mage1 = new Mage("Merlino",2, 8,25,100,10,new MagicShield(3,50,15),new FireBall(2,50,15) );
            
            //match between two creatures
            Fight(warrior1,mage1);

            //match between 2 armies -> Ith member of the army fight against Ith member of the other army. Wins who has the most survivors.
            int armyCapacity = 25;
            var army1 = new List<Creature>();
            var army2 = new List<Creature>();
            ArmyFight(army1,army2,armyCapacity);
            
        }

        static void Fight(Creature a, Creature b) {
            Console.WriteLine("\nA clash between " + a.Name + " and " + b.Name + " has begun!");
            
            while (a.IsAlive() && b.IsAlive()) {
                Console.WriteLine(a);
                Console.WriteLine(b);
                Console.WriteLine();
                
                a.Attack(b);
                b.Attack(a);
            }
            
            if(a.IsUnconscious()) Console.WriteLine(a.Name + " is unconscious");
            if(b.IsUnconscious()) Console.WriteLine(b.Name + " is unconscious");
            
            Console.Write("match ended: ");
            string champion = (a.IsAlive()) ? a.Name : b.Name;
            Console.WriteLine(champion + " won!");
        }

        static void ArmyFight(List<Creature> army1, List<Creature> army2,int armyCapacity){
            Random rnd = new Random();
            Console.WriteLine("\nA clash between two armies has begun!");
            for (int i = 0; i < armyCapacity; i++) {
                int tmp = rnd.Next(0, 2);
                if(tmp == 0) army1.Add(new Goblin());
                else army1.Add(new Warrior());
                
                tmp = rnd.Next(0, 2);
                if(tmp == 0) army2.Add(new Goblin());
                else army2.Add(new Warrior());
            }

            while (army1.Count > 0 && army2.Count > 0) {
                //Console.WriteLine("name: " + army1[0].Name + "  health: " +army1[0].Health + " vs health: " + army2[0].Health + "  name: "+ army2[0].Name);
                for (int i = 0; i < army1.Count && army2.Count > 0; i++) {
                    try {
                        army1[i].Attack(army2[i]);
                        if (!army2[i].IsAlive()) army2.RemoveAt(i);
                    }
                    catch {
                        // ignored
                    }
                }

                for (int i = 0; i < army2.Count && army1.Count > 0; i++) {
                    try {
                        army2[i].Attack(army1[i]);
                        if (!army1[i].IsAlive()) army1.RemoveAt(i);
                    }
                    catch {
                        // ignored
                    }
                }

                
                

            }

            string winner = "";
            var army1Survivors = army1.Count(x => x.IsAlive());   //count how many survivors there are in the two armies
            var army2Survivors = army2.Count(x => x.IsAlive());
            
            Console.WriteLine("Army 1 survivors: " + army1Survivors);
            Console.WriteLine("Army 2 survivors: " + army2Survivors +"\n");
            
            if (army1Survivors > army2Survivors) winner = "Army 1 is the winner!";
            else if (army1Survivors < army2Survivors) winner = "Army 2 is the winner!";   //determines who won the battle
            else if (army1Survivors == army2Survivors) winner = "No one won...";
            Console.WriteLine(winner);
        }
    }
}