namespace _021Lab_Gdr {
    public abstract class Weapon {
        protected int damage;
        protected int integrity;
        protected double price;

        public Weapon(int damage, int integrity, double price) {
            this.damage = damage;
            this.integrity = integrity;
            this.price = price;
        }
        public Weapon() : this(5, 100,30){}

        public int Damage => damage;

        public int Integrity {
            get => integrity;
            set => integrity = value;
        }

        public double Price => price;
    }
    
}