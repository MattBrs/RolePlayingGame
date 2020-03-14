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
            if( dexterity > damage)
                return 0;
            else
                return damage - dexterity;
        }

        public override string ToString() {
            return String.Format("Goblin-  ") + base.ToString();
        }
    }
}
