namespace _021Lab_Gdr {
    public abstract class Armor {
        protected int _protection;
        protected int _integrity;
        protected double _price;
        
        public Armor(int protection, int integrity, double price) {
            this._protection = protection;
            this._integrity = integrity;
            this._price = price;
        }

        public Armor() : this(2, 100, 50) {
            
        }
        
        public int Protection => _protection;

        public int Integrity {
            get => _integrity;
            set => _integrity = value;
        }

        public double Price => _price;
    }
    
}