namespace _021Lab_Gdr {
    public abstract class Weapon {
        protected int _damage;
        protected int _integrity;
        protected double _price;

        public Weapon(int damage, int integrity, double price) {
            _damage = damage;
            _integrity = integrity;
            _price = price;
        }
        public Weapon() : this(5, 100,30){}

        public int Damage => _damage;

        public int Integrity {
            get => _integrity;
            set => _integrity = value;
        }

        public double Price => _price;
    }
    
}