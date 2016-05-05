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
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else if (inputArray.Length == 3)
            {
                if (inputArray[0] == "add")
                {
                    if (inputArray[1] == "sale")
                    {
                        string saleTextValue = inputArray[2];
                        if (saleTextValue != null)
                        {
                            _processor.Record.AddRecord(UtilityFunctions.TextToRecord(saleTextValue));
                            ConsoleOutput.OutputMessage("Sale record added");
                        }
                        else
                            ConsoleOutput.OutputMessage("Invalid sale input");
                    }
                    else if (inputArray[1] == "inventory")
                    {
                    }
                    else
                    {
                        return false;
                    }
                }
            } else if (inputArray.Length == 5)
            {
                if (inputArray[0] == "show")
                {
                    if (inputArray[1] == "sales")
                    {
                        if (inputArray[2] == "by")
                        {
                            SalesRecord tempRecord;
                            switch (inputArray[3])
                            {
                                case "date":
                                    tempRecord = new SalesRecord(_processor.Record.searchSaleByDate(Convert.ToInt32(inputArray[4])));
                                    //ConsoleOutput.OutputSalesRecord(tempRecord);
                                    break;
                                case "month":
                                    tempRecord = new SalesRecord(_processor.Record.searchSaleByMonth(Convert.ToInt32(inputArray[4])));
                                    //ConsoleOutput.OutputSalesRecord(tempRecord);
                                    break;
                                case "year":
                                    tempRecord = new SalesRecord(_processor.Record.searchSaleByYear(Convert.ToInt32(inputArray[4])));
                                    break;
                                default:
                                    return false;
                            }

                            ConsoleOutput.OutputHeader("sales");
                            ConsoleOutput.OutputSalesRecord(tempRecord);
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
