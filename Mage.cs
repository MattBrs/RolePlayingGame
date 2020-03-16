using System;
using System.Net.Cache;

namespace _021Lab_Gdr {
    public class Mage : Creature {
        private int _level;
        private int _maximumMana;
        private int _mana;
        private Spell _recoverySpell;
        private Spell _destructiveSpell;
        private Armor _lightArmor;
        private int _maximumHealth;

        public Mage(string name, int strength, int dexterity, int maximumHealth, int maximumMana, int level,
            Spell recoverySpell, Spell destructiveSpell, Armor armor) : base(name, strength, dexterity,
            maximumHealth) {
            _level = level;
            _recoverySpell = recoverySpell;
            _destructiveSpell = destructiveSpell;
            _maximumMana = maximumMana;
            _maximumHealth = maximumHealth;
            _lightArmor = armor;
            _mana = maximumMana;
        }

        public Mage() : this("Mage", 2, 5, 500, 150, 5, new MagicShield(1, 25, 15), new FireBall(1, 25, 30),
            new MageVest()) {
        }

        public int Mana {
            get => _mana;
            set => _mana = value;
        }

        public int Level => _level;

        public override void Attack(Creature enemy) {
            if (IsAlive() && enemy.IsAlive()) {
                if (_mana < _maximumMana) {
                    _mana += 25; //mana regeneration
                    if (_mana > _maximumMana)
                        _mana = _maximumMana;
                }
                if (this.Health <= (_maximumHealth / 2) && _recoverySpell != null && _mana >= _recoverySpell.ManaRequirement &&
                    _recoverySpell.IsUsable(this)) {
                    if (typeof(MagicShield) == _recoverySpell.GetType() && !((MagicShield) _recoverySpell).IsActive()
                    ) //if the recovery spell is a magicShield, check if it's already active before throwing.
                        _recoverySpell.Throw(this, enemy);
                    else if(_recoverySpell.GetType() != typeof(MagicShield))               //UNOPTIMIZED. REVISIT LATER
                        _recoverySpell.Throw(this, enemy);
                    else if (_destructiveSpell != null &&
                             _destructiveSpell.IsUsable(this) && _mana >= _destructiveSpell.ManaRequirement) {
                        //if the mage has enough health, he decides to attack the enemy with an attack spell
                        _destructiveSpell.Throw(this, enemy);
                        _mana -= _destructiveSpell.ManaRequirement;
                    }
                    else
                        enemy.DamageTaken = 0;
                }
                else if (_destructiveSpell != null &&
                         _destructiveSpell.IsUsable(this) && _mana >= _destructiveSpell.ManaRequirement) {
                    //if the mage has enough health, he decides to attack the enemy with an attack spell
                    _destructiveSpell.Throw(this, enemy);
                    _mana -= _destructiveSpell.ManaRequirement;
                }
                else
                    enemy.DamageTaken = 0;
            }
        }

        public override int Block(int damage) {
            if (typeof(MagicShield) == _recoverySpell.GetType()) {
                //if the spell is a magicShield
                if (!((MagicShield) _recoverySpell).IsActive() && ((MagicShield) _recoverySpell).Duration <= 0) {
                    //checks if it's active and if it still has duration
                    _dexterity -= ((MagicShield) _recoverySpell).Protection(this); //reduces the dexterity
                    ((MagicShield) _recoverySpell).Thrown = false; //set the spell as not thrown  
                    ((MagicShield) _recoverySpell).Duration = 3; //reset the duration
                }
            }

            return (_dexterity < damage) ? (damage - _dexterity) : 0;
        }

        public override string ToString() {
            return String.Format("Mage-  ") + base.ToString();
        }

        public override void ChangeArmor(Armor armor) {
            if (armor.Type == "light") _lightArmor = armor;
            else Console.WriteLine("mages can only equip light armors!");
        }
    }
}