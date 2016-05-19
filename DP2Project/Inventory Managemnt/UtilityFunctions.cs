using System;

namespace InventoryManagement
{
    public static class UtilityFunctions
    {
        /// <summary>
        /// Convert from text format data into a sale record
        /// </summary>
        /// <param name="recordTextLine"></param>
        /// <returns>Record</returns>
        public static Sale TextToRecord(string recordTextLine)
        {
            //the character read in each loop of the function
            char[] _c;

            //The number of the element that the function is going to read next
            int _elementNo = 0;

            //the entire element we are going to read as string
            string _readText = System.String.Empty;

            int _date = new int(); //elementNo 0
            int _month = new int(); //elementNo 1
            int _year = new int(); //elementNo 2
            int _id = new int(); //elementNo 3
            int _amount = new int(); // elementNo 4
            decimal _totalPrice = new decimal(); // elementNo 5

            // Convert the line given from string to array of char (for reading)
            _c = recordTextLine.ToCharArray(0, recordTextLine.Length);

            // loop for the length of the line of text given to the function
            for (int i = 0; i < _c.Length; i++)
            {
                //onsole.WriteLine(_c[i]);
                //stops reading and convert when reaching a comma
                if (_c[i] == ',')
                {
                    // the converted number (int)
                    int _num;
                    // the converted number (decimal)
                    decimal _price;

                    //Try to convert to int value first (as long as it's not the last element
                    if (Int32.TryParse(_readText, out _num) && _elementNo < 5)
                    {
                        switch (_elementNo)
                        {
                            case 0:
                                _date = _num;
                                break;
                            case 1:
                                _month = _num;
                                break;
                            case 2:
                                _year = _num;
                                break;
                            case 3:
                                _id = _num;
                                break;
                            case 4:
                                _amount = _num;
                                break;
                        }
                    }
                    else if (decimal.TryParse(_readText, out _price)) //  Try to convert to integer value
                    {
                        //Console.WriteLine(_price);
                        _totalPrice = _price;
                    }
                    else
                    {
                        //Console.WriteLine(_readText);
                        Console.WriteLine("Unable to read line");
                        return null;
                    }

                    _readText = System.String.Empty; //refresh the read text string for reading the next value
                    _elementNo++; //increment to make the function know we're working on the next value
                }
                else
                    _readText += _c[i]; //add the character
            }

            //Create a new sale record according to the values we got, then return it
            return new Sale(_date, _month, _year, _id, _amount, _totalPrice);
        }

        /// <summary>
        /// Convert a record item into a text format
        /// </summary>
        /// <param name="record"></param>
        /// <returns>string for writing into record file</returns>
        public static string RecordToText(Sale record)
        {
            string _outputText = String.Empty;

            _outputText += Convert.ToString(record.Date) + ','
                + Convert.ToString(record.Month) + ','
                + Convert.ToString(record.Year) + ','
                + Convert.ToString(record.ID) + ','
                + Convert.ToString(record.Amount) + ','
                + Convert.ToString(record.TotalPrice) + ',';

            return _outputText;
        }

        public static Item TextToItem(string text)
        {
            char[] _c;
            int _elementNo = 0;
            string _readText = System.String.Empty;

            int _id = new int();
            string _name = String.Empty;
            decimal _price = new decimal();
            int _inStock = new int();

            _c = text.ToCharArray(0, text.Length);

            for (int i = 0; i < _c.Length; i++)
            {
                if (_c[i] == ',')
                {
                    switch (_elementNo)
                    {
                        case 0:
                            _id = Convert.ToInt32(_readText);
                            break;
                        case 1:
                            _name = _readText;
                            break;
                        case 2:
                            _price = Convert.ToDecimal(_readText);
                            break;
                        case 3:
                            _inStock = Convert.ToInt32(_readText);
                            break;
                        default:
                            break;
                    }

                    _readText = System.String.Empty; //refresh the read text string for reading the next value
                    _elementNo++; //increment to make the function know we're working on the next value
                }
                else
                    _readText += _c[i];
            }

            return new Item(_id, _name, _price, _inStock);
        }

        public static string ItemToText(Item item)
        {
            string _outputText = String.Empty;

            _outputText += Convert.ToString(item.ID) + ','
                + Convert.ToString(item.Name) + ','
                + Convert.ToString(item.Price) + ','
                + Convert.ToString(item.InStock) + ',';

            return _outputText;
        }
    }

}