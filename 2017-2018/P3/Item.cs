using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3
{
    abstract class Item
    {
        protected string _name;
        protected string _type;
        protected double _price;

        public Item() {
            _name = "-";
            _type = "-";
            _price = 0;
        }

        public Item(string name = "-", string type = "-", double price = 0) {
            _name = name;
            _type = type;
            _price = price;
        }

        public override string ToString() {
            return string.Format(" {0,8} | {1,8} | {2:f2, 10}", _name, _type, _price);
        }

        public int CompareTo(Item rhs) {
            if(_price > rhs._price)
                return -1;
            if(_price == rhs._price) {
                if(_name.CompareTo(rhs._name) < 0)
                    return -1;
                if(_name.CompareTo(rhs._name) == 0)
                    return 0;
            }
            return 1;
        }

        abstract public double Sum();

        abstract public void IncreasePriceTenPercent();
    }
}