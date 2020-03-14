using System;

namespace _021Lab_Gdr {
    public class Goblin : Creature {
        public Goblin(string name, int strength, int dexterity, int health) : base(name, strength, dexterity, health) {
        }

        public override void Attack(Creature enemy) {
            int damage = fate.Next(0,strength + 1);                   //damage is a random value between 0 and the actual strength of the creature
            enemy.ReduceHealthBy(enemy.Block(damage));
        }

        public override int Block(int damage) {
            return (dexterity < damage) ? (damage - dexterity) : 0;         //if the creature dexterity it's higher than the damage -> damage = 0.   else -> damage = damage - dexterity.
        }

        public override string ToString() {
            return String.Format("Goblin-  ") + base.ToString();
        }
    }
}
