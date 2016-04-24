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
    }
}
