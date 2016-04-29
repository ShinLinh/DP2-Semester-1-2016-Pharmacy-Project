using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement;

namespace TestCore
{
    public static class ConsoleOutput
    {
        public static void OutputMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void OutputPrompt(string prompt)
        {
            Console.Write("{0}: ", prompt);
        }

        public static void OutputHeader(string headerType)
        {
            if (headerType == "sales")
            {
                Console.WriteLine("Date, Month, Year, Item ID, Amount, Total Price,");
            }
            else
            {
                Console.WriteLine("ID, Item name, Price, Remaning in stock");
            }
        }

        public static void OutputSalesRecord(SalesRecord record)
        {
            foreach (Sale value in record.List)
            {
                Console.WriteLine(UtilityFunctions.RecordToText(value));
            }
        }

        public static void OutputInventory(Inventory inventory)
        {
            /*foreach (Item value in inventory.List)
            {
                Console.WriteLine(UtilityFunctions.RecordToText(value));
            }*/
        }
    }
}
