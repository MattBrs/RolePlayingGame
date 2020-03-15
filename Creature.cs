using System;

namespace _021Lab_Gdr {
    public abstract class Creature {
        protected string _name;
        protected int _strength;
        protected int _dexterity;
        protected int _health;
        protected static Random _fate = new Random();            //determines the chance to deal greater damage

        protected Creature(string name, int strength, int dexterity, int health) {
            _name = name;
            _strength = strength;
            _dexterity = dexterity;
            _health = health;
        }

        public string Name {
            get => _name;
            set => _name = value;
        }

        public int Strength {
            get => _strength;
            set => _strength = value;
        }

        public int Dexterity {
            get => _dexterity;
            set => _dexterity = value;
        }

        public int Health {
            get => _health;
            set => _health = value;
        }

        public static Random Fate => _fate;

        public abstract void Attack(Creature c);
        public abstract int Block(int damage);

        public void ReduceHealthBy(int actualDamage) {
            _health -= actualDamage;                       //health decreases by the damage dealt by another creature
        }

        public bool IsAlive() {
            return _health > 0;
        }

        public bool IsDead() {
            return _health < 0;
        }

        public bool IsUnconscious() {
            return _health == 0;
        }

        public override string ToString() {
            return string.Format($"Name: {_name}  Health: {_health}  Strength: {_strength}  Dexterity:  {_dexterity}");
        }
    }
}