using System;

namespace _021Lab_Gdr {
    public class Goblin : Creature {
        public Goblin(string name, int strength, int dexterity, int health) : base(name, strength, dexterity, health) {
        }

        public override void Attack(Creature c) {
            int damage = fate.Next(0,strength + 1);
            c.ReduceHealthBy(c.Block(damage));
        }

        public override int Block(int damage) {
            return (dexterity < damage) ? (damage - dexterity) : 0;
        }

        public override string ToString() {
            return String.Format("Goblin-  ") + base.ToString();
        }
    }
}
