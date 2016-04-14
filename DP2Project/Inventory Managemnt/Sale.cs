using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement
{
    public class Sale
    {
        private int _date;
        private int _month;
        private int _year;
        private int _id;
        private int _amount;
        private float _totalPrice;

        public Sale(int date, int month, int year, int id, int amount, float totalPrice)
        {
            _date = date;
            _month = month;
            _year = year;
            _id = id;
            _amount = amount;
            _totalPrice = totalPrice;
        }
    }
}
