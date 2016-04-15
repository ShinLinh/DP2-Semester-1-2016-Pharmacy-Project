using NUnit.Framework;
using System;

namespace SwinAdventure
{
	[TestFixture ()]
	public class CommandProcessorTest
	{
		[Test()]
		public void TestProcessingMoveCommand ()
		{
			CommandProcessor testProcessor = new CommandProcessor ();
			Player testPlayer = new Player ("bob", "warrior");
			Location testLocation = new Location (new string[]{ "testing", "location" }, "Testing destination", "This is a location used as a destination test");
			Path testEastPath = new Path (new string[]{ "east", "path" }, testLocation, "a strange path");

			testPlayer.CurrentLocation.AddPath (testEastPath);
			string testString = String.Format ("You head {0}.{1}You {2}.{3}You arrived in {4}", testEastPath.FirstId, Environment.NewLine, testEastPath.Description, Environment.NewLine, testLocation.FullDescription);
			Assert.AreEqual(testProcessor.ExecuteCommand(testPlayer, "move east"), testString);
			Assert.AreEqual(testProcessor.ExecuteCommand(testPlayer, "go east"), "No exit in that direction in the current location");
			Assert.AreEqual(testProcessor.ExecuteCommand(testPlayer, "head east"), "No exit in that direction in the current location");
		}

		[Test()]
		public void TestProcessingLookInLocationCommand()
		{
			CommandProcessor testProcessor = new CommandProcessor ();
			Item[] testItem = new Item[] {
				new Item (new string[] { "shovel", "tool" }, "shovel", "a shovel"),
				new Item (new string[] { "sword", "weapon" }, "sword", "a sword")
			};

			Player testPlayer = new Player ("bob", "programmer");

			for (int i = 0; i < testItem.Length; i++) 
			{
				testPlayer.CurrentLocation.Inventory.Put (testItem [i]);
			}

			Assert.AreEqual (testProcessor.ExecuteCommand (testPlayer, "look at sword"), testItem [1].FullDescription);
		}

		public void TestProcessingLookInBag()
		{
			CommandProcessor testProcessor = new CommandProcessor ();
			Item[] testItem = new Item[] {
				new Item (new string[] { "emerald", "gem" }, "emerald", "a green gemstone"),
				new Item (new string[] { "ruby", "gem" }, "ruby", "a red gemstone")
			};

			Player testPlayer = new Player ("bob", "programmer");

			Bag testBag = new Bag (new string[]{ "bag", "gem_bag" }, "Gem bag", "A bag containing gemstones");
			for (int i = 0; i < testItem.Length; i++) {
				testBag.Inventory.Put (testItem [i]);
			}
				
			testPlayer.Inventory.Put (testBag);
			Assert.AreEqual (testProcessor.ExecuteCommand (testPlayer, "look at ruby in bag"), testItem [1].FullDescription);
			Assert.AreEqual (testProcessor.ExecuteCommand (testPlayer, "look at bag"), testBag.FullDescription);
		}

		[Test()]
		public void TestProcessingLookInInventory()
		{
			CommandProcessor testProcessor = new CommandProcessor ();
			Item[] testItem = new Item[] {
				new Item (new string[] { "emerald", "gem" }, "emerald", "a green gemstone"),
				new Item (new string[] { "ruby", "gem" }, "ruby", "a red gemstone")
			};
	
			Player testPlayer = new Player ("bob", "programmer");

			for (int i = 0; i < testItem.Length; i++) {
				testPlayer.Inventory.Put (testItem [i]);
			}

			Assert.AreEqual (testProcessor.ExecuteCommand (testPlayer, "look at ruby"), testItem [1].FullDescription);
		}

		[Test()]
		public void TestProcessingLookAtMe()
		{
			CommandProcessor testProcessor = new CommandProcessor ();
			Item[] testItem = new Item[] {
				new Item (new string[] { "emerald", "gem" }, "emerald", "a green gemstone"),
				new Item (new string[] { "ruby", "gem" }, "ruby", "a red gemstone")
			};

			Player testPlayer = new Player ("bob", "programmer");

			for (int i = 0; i < testItem.Length; i++) {
				testPlayer.Inventory.Put (testItem [i]);
			}

			Assert.AreEqual (testProcessor.ExecuteCommand (testPlayer, "look at me"), testPlayer.FullDescription);
			Assert.AreEqual (testProcessor.ExecuteCommand (testPlayer, "look at inventory"), testPlayer.FullDescription);
		}
	}
}

