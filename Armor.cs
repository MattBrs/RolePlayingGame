namespace _021Lab_Gdr {
    public abstract class Armor {
        protected int protection;
        protected int integrity;
        protected double price;
        
        public Armor(int protection, int integrity, double price) {
            this.protection = protection;
            this.integrity = integrity;
            this.price = price;
        }

        public Armor() : this(2, 100, 50) {
            
        }

        public int Protection => protection;

        public int Integrity {
            get => integrity;
            set => integrity = value;
        }

        public double Price => price;
    }
    
}