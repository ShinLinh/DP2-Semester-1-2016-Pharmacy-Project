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
        private decimal _totalPrice;

        public Sale(int date, int month, int year, int id, int amount, decimal totalPrice)
        {
            _date = date;
            _month = month;
            _year = year;
            _id = id;
            _amount = amount;
            _totalPrice = totalPrice;
        }

        public int Date
        {
            get
            {
                return _date;
            }
        }

        public int Month
        {
            get
            {
                return _month;
            }
        }

        public int Year
        {
            get
            {
                return _year;
            }
        }

        public int ID
        {
            get
            {
                return _id;
            }
        }

        public int Amount
        {
            get
            {
                return _amount;
            }
        }

        public decimal TotalPrice
        {
            get
            {
                return _totalPrice;
            }
        }

    }
}
