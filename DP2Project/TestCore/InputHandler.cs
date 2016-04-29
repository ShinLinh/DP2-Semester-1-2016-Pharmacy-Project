using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement;

namespace TestCore
{
    public class InputHandler
    {
        private SalesProcessor _processor;

        public InputHandler(SalesProcessor processor)
        {
            _processor = processor;
        }

        public void TakeInput()
        {
            string _input = String.Empty;

            do
            {
                ConsoleOutput.OutputPrompt("Enter command");
                _input = Console.ReadLine();
                if (_input != String.Empty)
                {
                    if (!ProcessInput(_input))
                    {
                        ConsoleOutput.OutputMessage("Invalid command");
                    }
                }
                else
                {
                    ConsoleOutput.OutputMessage("Please enter something");
                }
                
            } while (_input != "end");
        }

        public bool ProcessInput(string input)
        {
            string[] inputArray = input.Split(' ');

            if (inputArray.Length == 2)
            {
                if (inputArray[0] == "show")
                {
                    if (inputArray[1] == "sales")
                    {
                        ConsoleOutput.OutputHeader("sales");
                        ConsoleOutput.OutputSalesRecord(_processor.Record);
                    }
                    else if (inputArray[1] == "inventory")
                    {
                        ConsoleOutput.OutputHeader("inventory");
                        ConsoleOutput.OutputInventory(_processor.Inventory);
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
