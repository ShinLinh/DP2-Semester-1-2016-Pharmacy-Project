using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace InventoryManagement
{
    /// <summary>
    ///Records all sales data
    /// </summary>
    public class SalesRecord
    {
        private List<Sale> _record;
        string recordFile;

        public SalesRecord(List<Sale> record)
        {
            _record = record;
        }

        /// <summary>
        /// Creates a record object within the program (preferrably during runtime
        /// </summary>
        /// <param name="salesFile">directory of the file the object is going to read from</param>
        public SalesRecord(string salesFile)
        {
            //makes the object remember the file directory
            recordFile = salesFile;

            //Set attributes, since apparently it will not let you write on otherwise (consent)
            File.SetAttributes(salesFile, FileAttributes.Normal);
            
            //refresh the sales record object with an empty list
            _record = new List<Sale>();
            
            //Read the lines one by one and turn each line into one element of a string array
            string[] records = File.ReadAllLines(salesFile);
            //Console.WriteLine(records.Length);

            //Convert each of the element in the string array into a record item and add to the list
            for (int i = 0; i < records.Length; i++)
            {
                //Console.WriteLine(records[i]);

                _record.Add(TextToRecord(records[i]));
            }
        }

        /// <summary>
        /// returns the number of sales recorded
        /// </summary>
        public int Count
        {
            get
            {
                return _record.Count;
            }
        }

        /// <summary>
        /// Add sale to record
        /// </summary>
        /// <param name="sale">Sale occured, containing data about the sale</param>
        public void AddRecord(Sale sale)
        {
            //Add sale to the record
            _record.Add(sale);
            //Write said record to file
            addRecordToFile(sale);
        }

        /// <summary>
        /// Convert from text format data into a sale record
        /// </summary>
        /// <param name="recordTextLine"></param>
        /// <returns>Record</returns>
        public Sale TextToRecord(string recordTextLine)
        {
            //the character read in each loop of the function
            char[] _c;

            //The number of the element that the function is going to read next
            int _elementNo = 0;

            //the entire text 
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
        /// Add the record as text format to the record file
        /// </summary>
        /// <param name="record"></param>
        public void addRecordToFile(Sale record)
        {
            using (StreamWriter file = new StreamWriter(recordFile, true))
            {
                file.WriteLine(UtilityFunctions.RecordToText(record));
            }
        }

        /// <summary>
        /// Return sale value based on index
        /// </summary>
        /// <param name="i">index</param>
        /// <returns>Sale recorded</returns>
        public Sale this[int i]
        {
            get
            {
                return _record[i];
            }
        }
        
        public List<Sale> List
        {
            get
            {
                return _record;
            }
        }

        /// <summary>
        /// Return a list of sales recorded on the day provided
        /// </summary>
        /// <param name="date"></param>
        /// <returns>List of sale according to criteria provided</returns>
        public List<Sale> searchSaleByDate(int date)
        {
            List<Sale> result = new List<Sale>();

            foreach (Sale value in _record)
            {
                if (value.Date == date)
                {
                    result.Add(value);
                }
            }

            return result;
        }

        /// <summary>
        /// Return a list of sales recorded in the month provided
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        public List<Sale> searchSaleByMonth(int month)
        {
            List<Sale> result = new List<Sale>();

            foreach (Sale value in _record)
            {
                if (value.Month == month)
                {
                    result.Add(value);
                }
            }

            return result;
        }

        /// <summary>
        /// Return a list of sales recorded in the year provided
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public List<Sale> searchSaleByYear(int year)
        {
            List<Sale> result = new List<Sale>();

            foreach (Sale value in _record)
            {
                if (value.Year == year)
                {
                    result.Add(value);
                }
            }

            return result;
        }
    }
}
