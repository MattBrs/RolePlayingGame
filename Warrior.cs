using System;

namespace _021Lab_Gdr {
    public class Warrior : Creature {
        private int _level;
        private int _weaponStrength;
        private int _armorDexterity;
        private Weapon _weapon;
        private Armor _armor;

        public Warrior(string name, int strength, int dexterity, int health, int level, Weapon weapon, Armor armor) : base(name,strength,dexterity,health) {
            _level = level;
            _weapon = weapon;
            _armor = armor;
            _weaponStrength = (_weapon != null && _weapon.Integrity > 0) ? _weapon.Damage : 0;
            _armorDexterity = (_armor != null && _armor.Integrity > 0) ? _armor.Protection : 0;
        }
        public Warrior() : this("Warrior", 25,28,50,1,new Sword(), new PlateArmor()){}

        public override void Attack(Creature enemy) {
            if (this.IsAlive()  && enemy.IsAlive()) {
                if (_weapon != null && _weapon.Integrity > 0)
                    _weapon.Integrity--; //if the weapon is still intact, decrease it's integrity
                else _weaponStrength = 0; //else set it's bonuses to 0

                int damage = _fate.Next(0, (_strength + _weaponStrength) + 1); //same as goblin but the weapon strength it's added
                enemy.ReduceHealthBy(enemy.Block(damage));
            }
            else {
                enemy.DamageTaken = 0;
            }
        }

        public override int Block(int damage) {
            if (_armor != null && _armor.Integrity > 0) _armor.Integrity--;   //if the armor is still intact, decrease it's integrity
            else _armorDexterity = 0;                                         //else set it's bonuses to 0
            
            return ((_dexterity + _armorDexterity) < damage) ? (damage - (_dexterity + _armorDexterity)) : 0;
        }
        public override string ToString() {
            return String.Format("Warrior-  ") + base.ToString();
        }
        public override void ChangeArmor(Armor armor) {
            _armor = armor;
        }
    }
}