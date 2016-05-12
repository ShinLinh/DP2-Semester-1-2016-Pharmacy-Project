using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement
{
    public class SalesProcessor
    {
        private Inventory _inventory;
        private SalesRecord _record;

        public SalesProcessor(string inventory, string record)
        {
            _inventory = new Inventory(inventory);
            _record = new SalesRecord(record);
        }

        public SalesRecord Record
        {
            get
            {
                return _record;
            }
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        public bool SellItem(int id, int amount)
        {
            Item _item;
            DateTime currentTime = DateTime.Now;
            int _date = currentTime.Day;
            int _month = currentTime.Month;
            int _year = currentTime.Year;
            if (_inventory[id] != null)
                _item = _inventory[id];
            else
    
                return false;
            decimal _totalPrice = _item.Price * amount;

            _item.Sell(amount);
            _record.AddRecord(new Sale(_date, _month, _year, id, amount, _totalPrice));
            return true; 
        }

        public bool RestockItem(int id, int amount)
        {
            Item _item;
            if (_inventory[id] != null)
                _item = _inventory[id];
            else
                return false;

            _item.Restock(amount);
            return true;
        }
    }
}
