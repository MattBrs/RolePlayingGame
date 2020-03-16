using System;

namespace _021Lab_Gdr {
    public abstract class Spell {
        protected string _name;
        protected int _levelRequirement;
        protected int _manaRequirement;
        protected string _type;
        public string Name => _name;
        public int LevelRequirement => _levelRequirement;
        public int ManaRequirement => _manaRequirement;

        protected Spell(string name, int levelRequirement, int manaRequirement, string type) {
            _name = name;
            _levelRequirement = levelRequirement;
            _manaRequirement = manaRequirement;
            _type = type;
        }

        public bool IsUsable(Mage mage) {
            return (mage.Level >= _levelRequirement) ? true : false;
        }

        public abstract void Throw(Mage mage, Creature enemy);        //abstract class
    }
}