namespace _021Lab_Gdr {
    public abstract class Armor {
        protected string _type;   //can be light or heavy
        protected int _protection;
        protected int _integrity;
        protected double _price;
        
        public Armor(int protection, int integrity, double price, string type) {
            _protection = protection;
            _integrity = integrity;
            _price = price;
            _type = type;
        }

        public Armor() : this(2, 100, 50,"light") {
            
        }

        public string Type => _type;

        public int Protection => _protection;

        public int Integrity {
            get => _integrity;
            set => _integrity = value;
        }

        public double Price => _price;
    }
    
}