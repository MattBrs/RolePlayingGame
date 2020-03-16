using System;

namespace _021Lab_Gdr {
    public class MagicShield : Spell {
        private int _protection;
        private int _duration;
        private bool _thrown;
        
        public MagicShield(int levelRequirement, int manaRequirement, int protection) : base("magicShield", levelRequirement, manaRequirement, "defence") {
            _protection = protection;
            _duration = 3;
            _thrown = false;
        }

        public int Protection(Mage mage) {
            return _protection + Convert.ToInt32(1.25f * (mage.Level - this._levelRequirement));      //improves the spell strength by the level of the mage
        }

        public string Type => _type;

        public bool Thrown {
            get => _thrown;
            set => _thrown = value;
        }

        public int Duration {
            get => _duration;
            set => _duration = value;
        }

        public override void Throw(Mage mage, Creature enemy) {
            if (IsUsable(mage) && mage.Mana >= _manaRequirement && !_thrown) {   //checks is the mage can use the spell , the mage has enough mana and if the spell has been already thrown
                _thrown = true;
                mage.Dexterity += Protection(mage);                                   //sets the thrown status on true, augment the dexterity and reduces the mana
                mage.Mana -= _manaRequirement;
            }
            
        }

        public bool IsActive() => _thrown;                                      //checks if the spell has been thrown
    }
}