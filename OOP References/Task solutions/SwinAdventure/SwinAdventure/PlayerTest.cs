using NUnit.Framework;
using System;

namespace SwinAdventure
{
	[TestFixture ()]
	public class PlayerTest
	{
		[Test ()]
		public void TestPlayerIdentifiable ()
		{
			Player testPlayer = new Player ("bob", "the player");

			Assert.IsTrue (testPlayer.AreYou("me"));
			Assert.IsTrue (testPlayer.AreYou("inventory"));
		}

		[Test()]
		public void TestPlayerLocateItem()
		{
			Player testPlayer = new Player ("bob", "the player");

			Item[] testItem = new Item[] {
				new Item (new string[] { "shovel", "tool" }, "shovel", "a shovel"),
				new Item (new string[] { "sword", "weapon" }, "sword", "a sword")
			};
				
			for (int i = 0; i < testItem.Length; i++) 
			{
				testPlayer.Inventory.Put (testItem [i]);
			}

			Assert.AreEqual (testPlayer.Locate ("sword"), testItem [1]);
			Assert.IsTrue (testPlayer.Inventory.HasItem ("sword"));
			Assert.AreEqual (testPlayer.Locate("sword"), testPlayer.Inventory.Fetch("sword"));
			Assert.IsTrue (testPlayer.Inventory.HasItem ("sword"));
		}

		[Test()]
		public void TestPlayerLocateItself()
		{
			Player testPlayer = new Player ("bob", "the player");

			Assert.AreSame (testPlayer, testPlayer.Locate("me"));
			Assert.AreSame (testPlayer, testPlayer.Locate("inventory"));
		}

		[Test()]
		public void TestPlayerLocateNothing()
		{

			Player testPlayer = new Player ("bob", "the player");

			Item[] testItem = new Item[] {
				new Item (new string[] { "shovel", "tool" }, "shovel", "a shovel"),
				new Item (new string[] { "sword", "weapon" }, "sword", "a sword")
			};

			for (int i = 0; i < testItem.Length; i++) 
			{
				testPlayer.Inventory.Put (testItem [i]);
			}

			Assert.IsFalse (testPlayer.Inventory.HasItem ("gun"));
			Assert.IsNull (testPlayer.Locate ("gun"));
		}

		[Test()]
		public void TestPlayerFullDescription()
		{
			Player testPlayer = new Player ("bob", "the player");

			Item[] testItem = new Item[] {
				new Item (new string[] { "shovel", "tool" }, "shovel", "a shovel"),
				new Item (new string[] { "sword", "weapon" }, "sword", "a sword")
			};

			for (int i = 0; i < testItem.Length; i++) 
			{
				testPlayer.Inventory.Put (testItem [i]);
			}

			string testString = string.Format ("You are {0} {1}{2}You are carrying{3}{4}", testPlayer.Name, testPlayer.ShortDescription, Environment.NewLine, Environment.NewLine, testPlayer.Inventory.ItemList);
			//string testString = "You are bob the player \nYou are carrying\na shovel(shovel)\na sword(sword)\n"
			Assert.AreEqual (testPlayer.FullDescription, testString);
		}
	}
}

