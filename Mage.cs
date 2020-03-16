using System;
using System.Net.Cache;

namespace _021Lab_Gdr {
    public class Mage : Creature {
        private int _level;
        private int _mana;
        private Spell _recoverySpell;
        private Spell _destructiveSpell;
        
        public Mage(string name, int strength, int dexterity, int health, int mana, int level, Spell recoverySpell, Spell destructiveSpell) : base(name, strength, dexterity,
            health) {
            _level = level;
            _recoverySpell = recoverySpell;
            _destructiveSpell = destructiveSpell;
            _mana = mana;
        }

        public int Mana {
            get => _mana;
            set => _mana = value;
        }

        public int Level => _level;
        public override void Attack(Creature enemy) {
            if (IsAlive()) {
                if (_health <= (_health * 0.25f) && _recoverySpell != null && _mana >= _recoverySpell.ManaRequirement &&
                    _recoverySpell.IsUsable(this)) {
                    if (typeof(MagicShield) == _recoverySpell.GetType() && !(_recoverySpell as MagicShield).IsActive()
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
                if (!(_recoverySpell as MagicShield).IsActive() && (_recoverySpell as MagicShield).Duration <= 0) {  //checks if it's active and if it still has duration
                    _dexterity -= (_recoverySpell as MagicShield).Protection(this);                                        //reduces the dexterity
                    (_recoverySpell as MagicShield).Thrown = false;                                                  //set the spell as not thrown  
                    (_recoverySpell as MagicShield).Duration = 3;                                                    //reset the duration
                }
            }
            return (_dexterity < damage) ? (damage - _dexterity) : 0;
        }
    }
}