using System;

namespace _021Lab_Gdr {
    public class Goblin : Creature {
        public Goblin(string name, int strength, int dexterity, int health) : base(name, strength, dexterity, health) {
        }

        public Goblin() : this("goblin", 14, 5, 10) {
            
        }
        
        public override void Attack(Creature enemy) {
            if (this.IsAlive() && enemy.IsAlive()) {
                int damage = _fate.Next(0, _strength + 1); //damage is a random value between 0 and the actual strength of the creature
                enemy.ReduceHealthBy(enemy.Block(damage));
            }
        }

        public override int Block(int damage) {
            return (_dexterity < damage) ? (damage - _dexterity) : 0;         //if the creature dexterity it's higher than the damage -> damage = 0.   else -> damage = damage - dexterity.
        }

        public override string ToString() {
            return String.Format("Goblin-  ") + base.ToString();
        }

        public override void ChangeArmor(Armor armor) {
            Console.WriteLine("goblin cannot have an armor");
        }
    }
}
