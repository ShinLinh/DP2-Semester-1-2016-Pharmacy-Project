using System;
using NUnit.Framework;


namespace SwinAdventure
{
	[TestFixture ()]
	public class InventoryTest
	{
		[Test()]
		public void TestFindItem ()
		{
			Item[] testItem = new Item[] {
				new Item (new string[] { "shovel", "tool" }, "shovel", "a shovel"),
				new Item (new string[] { "sword", "weapon" }, "sword", "a sword")
			};
			
			Inventory testInventory = new Inventory ();
			for (int i = 0; i < testItem.Length; i++) 
			{
				testInventory.Put (testItem [i]);
			}

			Assert.IsTrue(testInventory.HasItem("shovel"));
			Assert.IsTrue(testInventory.HasItem("sword"));
		}

		[Test()]
		public void TestNoItemFound()
		{
			Item[] testItem = new Item[] {
				new Item (new string[] { "shovel", "tool" }, "shovel", "a shovel"),
				new Item (new string[] { "sword", "weapon" }, "sword", "a sword")
			};

			Inventory testInventory = new Inventory ();
			for (int i = 0; i < testItem.Length; i++) 
			{
				testInventory.Put (testItem [i]);
			}

			Assert.IsFalse(testInventory.HasItem("shoes"));
		}

		[Test()]
		public void TestFetchItem()
		{
			Item[] testItem = new Item[] {
				new Item (new string[] { "shovel", "tool" }, "shovel", "a shovel"),
				new Item (new string[] { "sword", "weapon" }, "sword", "a sword")
			};

			Inventory testInventory = new Inventory ();
			for (int i = 0; i < testItem.Length; i++) 
			{
				testInventory.Put (testItem [i]);
			}

			Assert.AreEqual (testInventory.Fetch ("sword"), testItem [1]);
			Assert.AreEqual (testInventory.Fetch ("shovel"), testItem [0]);
		}


		[Test()]
		public void TestTakeItem()
		{
			Item[] testItem = new Item[] {
				new Item (new string[] { "shovel", "tool" }, "shovel", "a shovel"),
				new Item (new string[] { "sword", "weapon" }, "sword", "a sword")
			};

			Inventory testInventory = new Inventory ();
			for (int i = 0; i < testItem.Length; i++) 
			{
				testInventory.Put (testItem [i]);
			}

			Assert.IsTrue(testInventory.HasItem ("sword"));

			Assert.AreEqual (testInventory.Take ("sword"), testItem [1]);
			Assert.IsFalse (testInventory.HasItem ("sword"));
		}

		[Test()]
		public void TestItemList()
		{
			Item[] testItem = new Item[] {
				new Item (new string[] { "shovel", "tool" }, "shovel", "a shovel"),
				new Item (new string[] { "sword", "weapon" }, "sword", "a sword")
			};

			string testString = string.Format (" a shovel (shovel){0} a sword (sword){1}", Environment.NewLine, Environment.NewLine); 
				
			Inventory testInventory = new Inventory ();
			for (int i = 0; i < testItem.Length; i++) 
			{
				testInventory.Put (testItem [i]);
			}

			Assert.AreEqual (testInventory.ItemList, testString);
		}
	}
}

