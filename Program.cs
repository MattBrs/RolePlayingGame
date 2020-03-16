using System;
using System.Collections.Generic;
using System.Linq;

namespace _021Lab_Gdr {
    class Program {
        static void Main(string[] args) {
            
            //goblins
            Creature goblin1 = new Goblin("prok", 15,6,8);
            Creature goblin2 = new Goblin("krold", 10,8,16);
            //warriors
            Creature warrior1 = new Warrior("Goblin slayer", 25, 20, 105, 1, new Sword(), new PlateArmor());
            Creature warrior2 = new Warrior("Josuke", 30, 25,55,1,new Sword(), new PlateArmor());
            //mages
            Creature mage1 = new Mage("Saruman",2, 8,250,100,10,new MagicShield(3,50,15),new FireBall(2,50,10),new MageVest());
            Creature mage2 = new Mage("Gandalf",1, 4,450,200,8,new MagicShield(2,70,10),new FireBall(4,20,10), new MageVest());
            
            
            //match between two creatures
            Fight(mage1,mage2);

            //match between 2 armies -> Ith member of the army fight against Ith member of the other army. Wins who has the most survivors.
            int armyCapacity = 25;
            var army1 = new List<Creature>();
            var army2 = new List<Creature>();
            ArmyFight(army1,army2,armyCapacity);
            
        }

        static void Fight(Creature a, Creature b) {
            Console.WriteLine("\nA clash between " + a.Name + " and " + b.Name + " has begun!");
            int turn = 1;
            while (a.IsAlive() && b.IsAlive()) {
                Console.WriteLine(a.GetFightStatus());
                Console.WriteLine(b.GetFightStatus());
                Console.WriteLine("-----------------------------");
                Console.WriteLine("turn " + turn);
                a.Attack(b);
                if(a.IsAlive()) Console.WriteLine(a.Name + " reduced " + b.Name + " health by " + b.DamageTaken());
                b.Attack(a);
                if(b.IsAlive()) Console.WriteLine(b.Name + " reduced " + a.Name + " health by " + a.DamageTaken() + "\n");
                turn++;

            }

            Console.WriteLine("-----------------------------");
            Console.WriteLine(a.GetFightStatus());
            Console.WriteLine(b.GetFightStatus());
            
            Console.ForegroundColor = ConsoleColor.Red;
            if(a.IsUnconscious()) Console.WriteLine(a.Name + " is unconscious");
            if(b.IsUnconscious()) Console.WriteLine(b.Name + " is unconscious");
            Console.ForegroundColor = ConsoleColor.White;
            
            string champion = (a.IsAlive()) ? a.Name : b.Name;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(champion + " won!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void ArmyFight(List<Creature> army1, List<Creature> army2,int armyCapacity){
            Random rnd = new Random();
            Console.WriteLine("\nA clash between two armies has begun!");
            for (int i = 0; i < armyCapacity; i++) {
                int tmp = rnd.Next(0, 2);
                if(tmp == 0) army1.Add(new Goblin());     //add random creatures to the army
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
                        if (!army2[i].IsAlive()) army2.RemoveAt(i);                             //they fight all at the same time and if they die/get unconscious they get deleted from the army
                    }
                    catch {
                        // ignored
                    }
                }

                for (int i = 0; i < army2.Count && army1.Count > 0; i++) {
                    try {
                        army2[i].Attack(army1[i]);
                        if (!army1[i].IsAlive()) army1.RemoveAt(i);                            //try-catch to prevent a creature of an army to attack a non-existent creature
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