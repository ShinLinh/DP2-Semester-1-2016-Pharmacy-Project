using NUnit.Framework;
using System;

namespace SwinAdventure
{
	[TestFixture ()]
	public class ItemTest
	{
		[Test ()]
		public void TestIdentifiable ()
		{
			Item itm = new Item(new string[] {"shovel", "tool"}, "shovel", "a shovel");

			Assert.IsTrue(itm.AreYou("shovel"));
			Assert.IsTrue(itm.AreYou("tool"));
		}

		[Test()]
		public void TestShortDescription()
		{
			Item itm = new Item(new string[] {"shovel", "tool"}, "shovel", "a shovel");

			Assert.AreEqual (itm.ShortDescription, "a shovel");
		}

		[Test()]
		public void TestFullDescription()
		{
			Item itm = new Item(new string[] {"shovel", "tool"}, "shovel", "a shovel");

			Assert.AreEqual (itm.FullDescription, "a shovel");
		}
	}
}

