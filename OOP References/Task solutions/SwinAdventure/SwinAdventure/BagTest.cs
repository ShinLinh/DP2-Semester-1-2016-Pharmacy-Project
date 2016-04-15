using NUnit.Framework;
using System;

namespace SwinAdventure
{
	[TestFixture ()]
	public class BagTest
	{
		[Test ()]
		public void TestBagLocatesItems ()
		{
			Item[] testItem = new Item[] {
				new Item (new string[] { "emerald", "gem" }, "emerald", "a green gemstone"),
				new Item (new string[] { "ruby", "gem" }, "ruby", "a red gemstone")
			};

			Bag testBag = new Bag (new string[]{ "bag", "gem_bag" }, "Gem bag", "A bag containing gemstones");
			for (int i = 0; i < testItem.Length; i++) 
			{
				testBag.Inventory.Put (testItem[i]);
			}

			Assert.AreEqual (testItem [0], testBag.Locate ("emerald"));
			Assert.AreEqual (testItem [1], testBag.Locate ("ruby"));
		}

		[Test()]
		public void TestBagLocatesItself()
		{
			Bag testBag = new Bag (new string[]{ "bag", "gem_bag" }, "Gem bag", "A bag containing gemstones");

			Assert.AreSame (testBag.Locate ("bag"), testBag);
			Assert.AreSame (testBag.Locate ("gem_bag"), testBag);
		}

		[Test()]
		public void TestBagLocatesNothing()
		{
			Item[] testItem = new Item[] {
				new Item (new string[] { "emerald", "gem" }, "emerald", "a green gemstone"),
				new Item (new string[] { "ruby", "gem" }, "ruby", "a red gemstone")
			};

			Bag testBag = new Bag (new string[]{ "bag", "gem_bag" }, "Gem bag", "A bag containing gemstones");
			for (int i = 0; i < testItem.Length; i++) 
			{
				testBag.Inventory.Put (testItem[i]);
			}

			Assert.IsNull (testBag.Locate ("sapphire"));
		}

		[Test()]
		public void TestBagFullDescription()
		{
			Item[] testItem = new Item[] {
				new Item (new string[] { "emerald", "gem" }, "emerald", "a green gemstone"),
				new Item (new string[] { "ruby", "gem" }, "ruby", "a red gemstone")
			};

			Bag testBag = new Bag (new string[]{ "bag", "gem_bag" }, "Gem bag", "A bag containing gemstones");
			for (int i = 0; i < testItem.Length; i++) 
			{
				testBag.Inventory.Put (testItem[i]);
			}

			string testString = string.Format ("In the {0} you can see:{1}{2}", testBag.Name, Environment.NewLine, testBag.Inventory.ItemList);

			Assert.AreEqual (testBag.FullDescription, testString);
		}

		[Test()]
		public void TestBagInBag()
		{
			Item[] testItems1 = new Item[] {
				new Item (new string[] { "emerald", "gem" }, "emerald", "a green gemstone"),
				new Item (new string[] { "ruby", "gem" }, "ruby", "a red gemstone")
			};
			Bag testBag1 = new Bag (new string[]{ "bag1", "gem_bag" }, "Gem bag", "A bag containing gemstones");
			for (int i = 0; i < testItems1.Length; i++) 
			{
				testBag1.Inventory.Put (testItems1[i]);
			}

			Item[] testItems2 = new Item[] {
				new Item (new string[] { "sapphire", "gem" }, "emerald", "a blue gemstone"),
				new Item (new string[] { "rock", "gem?" }, "rock", "not exactly a gem")
			};
			Bag testBag2 = new Bag (new string[]{ "bag2", "gem_bag" }, "Gem bag", "Another bag containing gemstones");
			for (int i = 0; i < testItems2.Length; i++) 
			{
				testBag2.Inventory.Put (testItems2[i]);
			}

			testBag1.Inventory.Put (testBag2);

			Assert.AreEqual (testBag1.Locate ("bag2"), testBag2);
			Assert.AreEqual (testBag1.Locate ("emerald"), testItems1[0]);
			Assert.AreEqual (testBag2.Locate ("sapphire"), testItems2[0]);
			Assert.AreNotEqual (testBag1.Locate ("rock"), testBag2.Locate ("rock"));
			Assert.IsNull (testBag1.Locate ("rock"));
		}
	}
}

