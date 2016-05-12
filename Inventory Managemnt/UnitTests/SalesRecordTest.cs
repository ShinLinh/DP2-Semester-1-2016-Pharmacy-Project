using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace InventoryManagement.UnitTests
{
    [TestFixture]
    public class SalesRecordTest
    {
        [Test()]
        public void TestRecordFileRead()
        {
            string _fileName = "SalesRecordTest.txt";
            string path = AppDomain.CurrentDomain.BaseDirectory;
            path += _fileName;
            //Console.WriteLine(path);
            SalesRecord _record = 
                new SalesRecord(path);

            Assert.IsNotNull(_record[0]);
            //Console.WriteLine(_record.Count);
            Assert.IsTrue(_record[0].Date == 05);
            Assert.IsTrue(_record[1].Month == 03);
            Assert.AreEqual(_record[0].Year, _record[2].Year);
            //Console.WriteLine("{0},{1},{2},{3},{4},{5}", _record[_record.Count - 1].Date, _record[_record.Count - 1].Month, _record[_record.Count - 1].Year, _record[_record.Count - 1].ID, _record[_record.Count - 1].Amount, _record[_record.Count - 1].TotalPrice);
        }

        [Test()]
        public void TestAddRecord()
        {
            string _fileName = "SalesRecordTest.txt";
            string path = AppDomain.CurrentDomain.BaseDirectory;
            path += _fileName;
            SalesRecord _record = new SalesRecord(path);
            int _initialCount = _record.Count;
            Sale _testSale = new Sale(12, 5, 2015, 123, 3, 30);
            _record.AddRecord(_testSale);

            Assert.AreEqual(_initialCount + 1, _record.Count);
            Assert.AreSame(_record[_record.Count - 1], _testSale);
            //Console.WriteLine(_record[_record.Count - 1].TotalPrice);
            //Console.WriteLine(_testSale.TotalPrice);

            _record = new SalesRecord(path);
            
            Assert.AreEqual(_initialCount + 1, _record.Count);
            Assert.AreEqual(_record[_record.Count - 1].Date, _testSale.Date);
            Assert.AreEqual(_record[_record.Count - 1].Month, _testSale.Month);
            Assert.AreEqual(_record[_record.Count - 1].Year, _testSale.Year);
            Assert.AreEqual(_record[_record.Count - 1].ID, _testSale.ID);
            Assert.AreEqual(_record[_record.Count - 1].Amount, _testSale.Amount);
            //Console.WriteLine(_record[_record.Count - 1].TotalPrice);
            Assert.AreEqual(_record[_record.Count - 1].TotalPrice, _testSale.TotalPrice);
            //Console.WriteLine("{0},{1},{2},{3},{4},{5}", _record[_record.Count - 1].Date, _record[_record.Count - 1].Month, _record[_record.Count - 1].Year, _record[_record.Count - 1].ID, _record[_record.Count - 1].Amount, _record[_record.Count - 1].TotalPrice);
        }

        //used for testing function, does not need to worry about
        /*[Test()]
        public void TestParse()
        {
            string _testString = "30";
            decimal _testResult = new decimal();
            decimal _testFloat = 30;
            Assert.IsTrue(decimal.TryParse(_testString, out _testResult));
            Assert.AreEqual(_testResult, _testFloat);
        }*/
    }
}
