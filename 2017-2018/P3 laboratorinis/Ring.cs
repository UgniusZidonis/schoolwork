namespace P3_laboratorinis
{
    abstract class Ring
    {
        protected string _manufacturer;
        protected string _name;
        protected string _metal;
        protected double _purity;
        protected string _distinction;
        protected int _size;

        public Ring(string manufacturer = "", string name = "", string metal = "", double purity = 0, string distinction = "", int size = 0) {
            _manufacturer = manufacturer;
            _name = name;
            _metal = metal;
            _purity = purity;
            _distinction = distinction;
            _size = size;
        }

        public string GetManufacturer() { return _manufacturer; }
        public string GetName() { return _name; }
        public string GetMetal() { return _metal; }
        public double GetPurity() { return _purity; }
        public string GetDistinction() { return _distinction; }
        public int GetSize() { return _size; }
    }
}
