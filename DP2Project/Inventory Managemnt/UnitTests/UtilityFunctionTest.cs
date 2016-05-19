using NUnit.Framework;

namespace InventoryManagement.UnitTests
{
    [TestFixture]
    public class UtilityFunctionTest
    {
        [Test()]
        public void TestRecordToText()
        {
            Sale _testSale = new Sale(12, 5, 2015, 123, 3, 30);

            Assert.AreEqual(UtilityFunctions.RecordToText(_testSale), "12,5,2015,123,3,30,");
        }

        [Test()]
        public void TestTextToRecord()
        {
            Sale testSale = new Sale(1, 1, 2011, 115, 20, 30);
            Sale testSale2 = UtilityFunctions.TextToRecord("1,1,2011,115,20,30,\n");
            Assert.IsNotNull(testSale2);
            Assert.AreEqual(testSale2.Date, testSale.Date);
            Assert.AreEqual(testSale2.Month, testSale.Month);
            Assert.AreEqual(testSale2.Year, testSale.Year);
            Assert.AreEqual(testSale2.Amount, testSale.Amount);
            Assert.AreEqual(testSale2.TotalPrice, testSale.TotalPrice);
        }
    }
}
