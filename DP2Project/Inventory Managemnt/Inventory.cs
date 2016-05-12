using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace InventoryManagement
{
    public class Inventory
    {
        private List<Item> _inventory;
        private string _inventoryFile;

        public Inventory()
        {
        }

        public Inventory(string inventoryFile)
        {
            // Test on your own time :). take note of the inventoryFile parameter
            /*string file = "db.csv";
            if (!File.Exists(file))
            {
                FileStream fs = File.Create(file);
            }*/


            //makes the object remember the file directory
            _inventoryFile = inventoryFile;

            //Set attributes, since apparently it will not let you write on otherwise (consent)
            File.SetAttributes(inventoryFile, FileAttributes.Normal);

            //refresh the sales record object with an empty list
            _inventory = new List<Item>();

            //Read the lines one by one and turn each line into one element of a string array
            string[] records = File.ReadAllLines(inventoryFile);

            //Convert each of the element in the string array into a record item and add to the list
            for (int i = 0; i < records.Length; i++)
            {
                _inventory.Add(UtilityFunctions.TextToItem(records[i]));
            }
        }

        public List<Item> List
        {
            get
            {
                return _inventory;
            }
        }

        public void addItemToFile(Item item)
        {
            using (StreamWriter file = new StreamWriter(_inventoryFile, true))
            {
                file.WriteLine(UtilityFunctions.ItemToText(item));
            }
        }

        public void AddItem(Item item)
        {
            _inventory.Add(item);
            
            addItemToFile(item);
        }

        public Item this[int id]
        {

            get
            {
                Item result = null;
                foreach (Item item in _inventory)
                {
                    if (item.ID == id)
                    {
                        result = item;
                    }
                }
                return result;
            }
        }

    }
}
