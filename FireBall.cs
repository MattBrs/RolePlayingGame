using System;

namespace _021Lab_Gdr {
    public class FireBall : Spell {
        private int _damage;
        Random _rnd = new Random();
         
        public FireBall( int levelRequirement, int manaRequirement, int damage) : base("Fireball", levelRequirement, manaRequirement, "attack") {
            _damage = damage;
            _type = "attack";
        }

        public string Type => _type;

        public int Damage(Mage mage) {
            return _rnd.Next(0, _damage) + Convert.ToInt32(1.25f * (mage.Level - this._levelRequirement));         //improves the spell strength by the level of the mage
        }
        public override void Throw(Mage mage, Creature enemy) {
            enemy.ReduceHealthBy(this.Damage(mage));              //directly attacks the enemy ignoring any type of physical armor (only magic armors like magicShields can block magic).
            
        }
    }
}