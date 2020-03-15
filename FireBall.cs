namespace _021Lab_Gdr {
    public class FireBall : Spell {
        private int _damage;
        private string _type;
         
        public FireBall( int levelRequirement, int manaRequirement, int damage) : base("Fireball", levelRequirement, manaRequirement) {
            _damage = damage;
            _type = "attack";
        }

        public string Type => _type;

        public int Damage => _damage;
        public override void Throw(Mage mage, Creature enemy) {
            if (this.IsUsable(mage) && mage.Mana >= this._manaRequirement) {   //checks if the mage has enough mana and if he can use the spell
                enemy.ReduceHealthBy(this.Damage);              //directly attacks the enemy ignoring any type of armor
            }
        }
    }
}