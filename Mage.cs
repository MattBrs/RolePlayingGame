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
        
        public Mage(string name, int strength, int dexterity, int health, int maximumMana, int level, Spell recoverySpell, Spell destructiveSpell,Armor armor) : base(name, strength, dexterity,
            health) {
            _level = level;
            _recoverySpell = recoverySpell;
            _destructiveSpell = destructiveSpell;
            _maximumMana = maximumMana;
            _lightArmor = armor;
            _mana = maximumMana;
        }

        public int Mana {
            get => _mana;
            set => _mana = value;
        }

        public int Level => _level;
        public override void Attack(Creature enemy) {
            if (IsAlive() && enemy.IsAlive()) {
                if (_mana < _maximumMana) {
                    _mana += 10;                       //mana regeneration
                    if (_mana > _maximumMana)
                        _mana = _maximumMana;
                }
                
                if (Health <= (Health / 2) && _recoverySpell != null && _mana >= _recoverySpell.ManaRequirement) {
                    if (typeof(MagicShield) == _recoverySpell.GetType() && !((MagicShield) _recoverySpell).IsActive()
                    ) //if the recovery spell is a magicShield, check if it's already active before throwing.
                        _recoverySpell.Throw(this, enemy);
                    else //else (the spell is a cure spell) throw it
                        _recoverySpell.Throw(this, enemy);
                }
                else if (_destructiveSpell != null &&
                         _destructiveSpell
                             .IsUsable(
                                 this) && //if the mage has enough health, he decides to attack the enemy with an attack spell
                         _mana >= _destructiveSpell.ManaRequirement) {
                    _destructiveSpell.Throw(this, enemy);
                }
            }
        }

        public override int Block(int damage) {
            if (typeof(MagicShield) == _recoverySpell.GetType()) {                                                   //if the spell is a magicShield
                if (!((MagicShield) _recoverySpell).IsActive() && ((MagicShield) _recoverySpell).Duration <= 0) {  //checks if it's active and if it still has duration
                    _dexterity -= ((MagicShield) _recoverySpell).Protection(this);                                        //reduces the dexterity
                    ((MagicShield) _recoverySpell).Thrown = false;                                                  //set the spell as not thrown  
                    ((MagicShield) _recoverySpell).Duration = 3;                                                    //reset the duration
                }
            }
            return (_dexterity < damage) ? (damage - _dexterity) : 0;
        }

        public override void ChangeArmor(Armor armor) {
            if (armor.Type == "light") _lightArmor = armor;
            else Console.WriteLine("mages can only equip light armors!");
        }
    }
}