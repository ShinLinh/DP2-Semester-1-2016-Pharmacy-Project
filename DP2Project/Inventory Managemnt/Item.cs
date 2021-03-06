﻿namespace InventoryManagement
{
    public class Item
    {
        private int _id;
        private string _name;
        private decimal _price;
        private int _inStock;

        public Item(int id, string name, decimal price, int inStock)
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

        public decimal Price
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
        }

        public void Restock(int amount)
        {
            _inStock += amount;
        }

        public void Sell(int amount)
        {
            _inStock -= amount;
        }
    }
}
