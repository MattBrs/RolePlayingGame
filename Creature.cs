using System;

namespace _021Lab_Gdr {
    public abstract class Creature {
        protected string name;
        protected int strength;
        protected int dexterity;
        protected int health;
        protected static Random fate = new Random();            //determines the chance to deal greater damage

        protected Creature(string name, int strength, int dexterity, int health) {
            this.name = name;
            this.strength = strength;
            this.dexterity = dexterity;
            this.health = health;
        }

        public string Name {
            get => name;
            set => name = value;
        }

        public int Strength {
            get => strength;
            set => strength = value;
        }

        public int Dexterity {
            get => dexterity;
            set => dexterity = value;
        }

        public int Health {
            get => health;
            set => health = value;
        }

        public static Random Fate => fate;

        public abstract void Attack(Creature c);
        public abstract int Block(int damage);

        public void ReduceHealthBy(int actualDamage) {
            health -= actualDamage;                       //health decreases by the damage dealt by another creature
        }

        public bool IsAlive() {
            return health > 0;
        }

        public bool IsDead() {
            return health < 0;
        }

        public bool IsUnconscious() {
            return health == 0;
        }

        public override string ToString() {
            return string.Format($"Name: {name}  Health: {health}  Strength: {strength}  Dexterity:  {dexterity}");
        }
    }
}