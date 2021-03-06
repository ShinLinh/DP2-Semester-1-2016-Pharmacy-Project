﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using InventoryManagement;

namespace TestCore
{
    class Program
    {
        private List<Item> _price = new List<Item>();
        static void Main(string[] args)
        {
            //_price.ForEach(Console.WriteLine); //For each is not viable because no field exist yet. Dynamic containers have no fields at initialization.
            //Console.ReadLine();

            //public Item(int id, string name, float price, int inStock)
            string _recordFile = "SalesRecordTest.txt";
            string _inventoryFile = "InventoryTest.txt";
            string path = AppDomain.CurrentDomain.BaseDirectory;
            //string path = @"C:\Users\darkp\Documents\DP2Project\TestCore\";
            
            string _recordPath = path + _recordFile;
            string _inventoryPath = path + _inventoryFile; 
            Console.WriteLine(path);
            SalesProcessor _processor = new SalesProcessor(_inventoryPath, _recordPath);

            InputHandler inputHandler = new InputHandler(_processor);
            inputHandler.TakeInput();
        }
    }
}
