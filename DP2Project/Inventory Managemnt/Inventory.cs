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

        public Inventory(string inventoryFile)
        {
            string file = "db.csv";
            if (!File.Exists(file))
            {
                FileStream fs = File.Create(file);
            }
        }
    }
}
