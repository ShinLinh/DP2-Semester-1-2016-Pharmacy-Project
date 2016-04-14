using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement
{
    public class Item
    {
        private int _id;
        private string _name;
        private float _price;
        private int _inStock;

        public Item(int id, string name, float price, int inStock)
        {
            _id = id;
            _name = name;
            _price = price;
            _inStock = inStock;
        }

        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public float Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }

        public int InStock
        {
            get
            {
                return _inStock;
            }
            set
            {
                _inStock = value;
            }
        }
    }
}
