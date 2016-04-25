using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace InventoryManagement
{
    public class SalesRecord
    {
        private List<Sale> _record;
        string recordFile;
        public SalesRecord(string salesFile)
        {
            recordFile = salesFile;
            File.SetAttributes(salesFile, FileAttributes.Normal);
            _record = new List<Sale>();
            string[] records = File.ReadAllLines(salesFile);
           //Console.WriteLine(records.Length);
            for (int i = 0; i < records.Length; i++)
            {
                //Console.WriteLine(records[i]);
                _record.Add(TextToRecord(records[i]));
            }
        }

        public int Count
        {
            get
            {
                return _record.Count;
            }
        }

        public void AddRecord(Sale sale)
        {
            _record.Add(sale);
            addRecordToFile(sale);
        }

        public Sale TextToRecord(string recordTextLine)
        {
            char[] _c;
            int _elementNo = 0;
            string _readText = System.String.Empty;
            int _date = new int();
            int _month = new int();
            int _year = new int();
            int _id = new int();
            int _amount = new int();
            decimal _totalPrice = new decimal();
            
            _c = recordTextLine.ToCharArray(0, recordTextLine.Length);

            for (int i = 0; i < _c.Length; i++)
            {
                    //onsole.WriteLine(_c[i]);
                    if (_c[i] == ',')
                    {
                        int _num;
                        decimal _price;

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
                        else if (decimal.TryParse(_readText, out _price))
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

                        _readText = System.String.Empty;
                        _elementNo++;
                    }
                    else
                        _readText += _c[i];
            }

            return new Sale(_date, _month, _year, _id, _amount, _totalPrice);
        }

        public string RecordToText(Sale record)
        {
            string _outputText = String.Empty;
            //string _value = String.Empty;

            _outputText += Convert.ToString(record.Date) + ','
                + Convert.ToString(record.Month) + ','
                + Convert.ToString(record.Year) + ','
                + Convert.ToString(record.ID) + ','
                + Convert.ToString(record.Amount) + ','
                + Convert.ToString(record.TotalPrice) + ',';
            //Console.WriteLine(Convert.ToString(record.TotalPrice));
            //Console.WriteLine(_outputText);
            return _outputText;
        }

        public void addRecordToFile(Sale record)
        {
            using (StreamWriter file = new StreamWriter(recordFile, true))
            {
                file.WriteLine(RecordToText(record));
            }
        }

        public Sale this[int i]
        {
            get
            {
                return _record[i];
            }
        }
    }
}
