namespace _021Lab_Gdr {
    public class MageWarrior : Warrior {
        private int _MaximumMana;
        private Spell _recoverySpell;

        public MageWarrior(string name, int strength, int dexterity, int health, int level, int maximumMana, Weapon weapon, Armor armor) : base(name, strength, dexterity, health, level, weapon, armor) {
        }
    }
}