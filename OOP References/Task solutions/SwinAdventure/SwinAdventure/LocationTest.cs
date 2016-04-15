using System;
using NUnit.Framework;

namespace SwinAdventure
{
	[TestFixture()]
	public class LocationTest
	{
			[Test()]
			public void TestLocationLocateItems()
			{
				Item[] testItem = new Item[] {
					new Item (new string[] { "shovel", "tool" }, "shovel", "a shovel"),
					new Item (new string[] { "sword", "weapon" }, "sword", "a sword")
				};

				Location testLocation = new Location (new string[]{ "test", "location" }, "Testing location", "This is a location used for testing");

				for (int i = 0; i < testItem.Length; i++) 
				{
					testLocation.Inventory.Put (testItem [i]);
				}

				Assert.AreEqual (testLocation.Locate ("sword"), testItem [1]);
				Assert.AreEqual (testLocation.Locate ("shovel"), testItem [0]);
			}

			[Test()]
			public void TestLocationLocateItself()
			{
				Item[] testItem = new Item[] {
					new Item (new string[] { "shovel", "tool" }, "shovel", "a shovel"),
					new Item (new string[] { "sword", "weapon" }, "sword", "a sword")
				};

				Location testLocation = new Location (new string[]{ "test", "location" }, "Testing location", "This is a location used for testing");

				for (int i = 0; i < testItem.Length; i++) 
				{
					testLocation.Inventory.Put (testItem [i]);
				}

				Assert.AreEqual (testLocation.Locate ("location"), testLocation);
			}

			[Test()]
			public void TestLocationLocateNothing()
			{
				Item[] testItem = new Item[] {
					new Item (new string[] { "shovel", "tool" }, "shovel", "a shovel"),
					new Item (new string[] { "sword", "weapon" }, "sword", "a sword")
				};

				Location testLocation = new Location (new string[]{ "test", "location" }, "Testing location", "This is a location used for testing");

				for (int i = 0; i < testItem.Length; i++) 
				{
					testLocation.Inventory.Put (testItem [i]);
				}

				Assert.IsNull (testLocation.Locate ("gem")); 
			}

			[Test()]
			public void TestPlayerLocateLocation()
			{
				Item[] testItem = new Item[] {
					new Item (new string[] { "shovel", "tool" }, "shovel", "a shovel"),
					new Item (new string[] { "sword", "weapon" }, "sword", "a sword")
				};
				
				//Location testLocation = new Location (new string[]{ "test", "location" }, "Testing location", "This is a location used for testing");
				Player testPlayer = new Player ("bob", "programmer");

				for (int i = 0; i < testItem.Length; i++) 
				{
					testPlayer.CurrentLocation.Inventory.Put (testItem [i]);
				}
				
				//Assert.AreEqual(testPlayer.CurrentLocation,testPlayer.Locate("location"));
				Assert.AreSame(testPlayer.Locate("location"), testPlayer.CurrentLocation);
			}
			
			[Test()]
			public void TestPlayerLocateItemInLocation()
			{
				Item[] testItem = new Item[] {
					new Item (new string[] { "shovel", "tool" }, "shovel", "a shovel"),
					new Item (new string[] { "sword", "weapon" }, "sword", "a sword")
				};

				Player testPlayer = new Player ("bob", "programmer");

				for (int i = 0; i < testItem.Length; i++) 
				{
					testPlayer.CurrentLocation.Inventory.Put (testItem [i]);
				}

				Assert.AreEqual (testPlayer.Locate ("sword"), testItem [1]);
			}

			[Test()]
			public void TestLocationFullDesription()
			{
				Item[] testItem = new Item[] {
					new Item (new string[] { "shovel", "tool" }, "shovel", "a shovel"),
					new Item (new string[] { "sword", "weapon" }, "sword", "a sword")
				};

				Location testLocation = new Location (new string[]{ "test", "location" }, "Testing location", "This is a location used for testing");

				for (int i = 0; i < testItem.Length; i++) 
				{
					testLocation.Inventory.Put (testItem [i]);
				}
				string testString = String.Format ("{0}{1}You cannot find any exit in this room{2}In this room I can see:{3}{4}", testLocation.ShortDescription, Environment.NewLine, Environment.NewLine, Environment.NewLine, testLocation.Inventory.ItemList);
				Assert.AreEqual (testLocation.FullDescription, testString);
			}

			[Test()]
			public void TestPathList ()
			{
				Location testLocation = new Location (new string[]{ "testing", "location" }, "Testing destination", "This is a location used as a destination test");
				Path testEastPath = new Path (new string[]{ "east", "path" }, testLocation, "walk through a strange path");
				Path testSouthPath = new Path (new string[]{ "south", "path" }, testLocation, "walk through a strange path");

				testLocation.AddPath (testEastPath);
				testLocation.AddPath (testSouthPath);
				Assert.AreEqual(testLocation.PathList, "east, and south.");
			}

			[Test()]
			public void TestPathAdd()
			{
				Location testLocation = new Location (new string[]{ "testing", "location" }, "Testing destination", "This is a location used as a destination test");
				Path testEastPath = new Path (new string[]{ "east", "path" }, testLocation, "walk through a strange path");

				testLocation.AddPath (testEastPath);
				Assert.AreSame (testLocation.PathLocate("east"), testEastPath);
			}
		}
	}
