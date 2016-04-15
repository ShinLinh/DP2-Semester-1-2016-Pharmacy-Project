using NUnit.Framework;
using System;

namespace SwinAdventure
{
	[TestFixture ()]
	public class TestLookCommand
	{
		[Test ()]
		public void TestLookAtMe()
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

			Player p = new Player ("bob", "ad");
			p.Inventory.Put (testBag);	
			LookCommand look = new LookCommand ();

			Assert.AreEqual (look.Execute (p, new string[]{ "look", "at", "inventory" }), p.FullDescription);
		}

		[Test()]
		public void LookAtGem()
		{
			Item[] testItem = new Item[] {
				new Item (new string[] { "emerald", "gem" }, "emerald", "a green gemstone"),
				new Item (new string[] { "ruby", "gem" }, "ruby", "a red gemstone")
			};
			LookCommand look = new LookCommand ();
			Player p = new Player ("bob", "ad");
			for (int i = 0; i < testItem.Length; i++) 
			{
				p.Inventory.Put (testItem[i]);
			}

			Assert.AreEqual (look.Execute (p, new string[]{ "look", "at", "ruby" }), testItem[1].FullDescription);
		}

		[Test()]
		public void LookAtUnk()
		{
			Player p = new Player ("bob", "ad");
			LookCommand look = new LookCommand ();
			Assert.AreEqual (look.Execute (p, new string[]{ "look", "at", "ruby" }), "I cannot find the ruby");
		}

		[Test()]
		public void TestLookAtGemInMe()
		{
			Item[] testItem = new Item[] {
				new Item (new string[] { "emerald", "gem" }, "emerald", "a green gemstone"),
				new Item (new string[] { "ruby", "gem" }, "ruby", "a red gemstone")
			};
			LookCommand look = new LookCommand ();
			Player p = new Player ("bob", "ad");
			for (int i = 0; i < testItem.Length; i++) 
			{
				p.Inventory.Put (testItem[i]);
			}

			Assert.AreEqual (look.Execute (p, new string[]{ "look", "at", "ruby", "in", "me" }), testItem[1].FullDescription);
			Assert.AreEqual (look.Execute (p, new string[]{ "look", "at", "ruby", "in", "inventory" }), testItem[1].FullDescription);
		}

		[Test()]
		public void TestLookAtGemInBag()
		{
			Item[] testItem = new Item[] {
				new Item (new string[] { "emerald", "gem" }, "emerald", "a green gemstone"),
				new Item (new string[] { "ruby", "gem" }, "ruby", "a red gemstone")
			};

			Bag testBag = new Bag (new string[]{ "bag", "gem_bag" }, "Gem bag", "A bag containing gemstones");
			for (int i = 0; i < testItem.Length; i++) {
				testBag.Inventory.Put (testItem [i]);
			}

			Player p = new Player ("bob", "ad");
			p.Inventory.Put (testBag);	
			LookCommand look = new LookCommand ();

			Assert.AreEqual (look.Execute (p, new string[]{ "look", "at", "ruby", "in", "bag" }), testItem [1].FullDescription);
			Assert.AreEqual (look.Execute (p, new string[]{ "look", "at", "emerald", "in", "bag" }), testItem [0].FullDescription);
		}

		[Test()]
		public void TestLookAtGemInNoBag()
		{
			Item[] testItem = new Item[] {
				new Item (new string[] { "emerald", "gem" }, "emerald", "a green gemstone"),
				new Item (new string[] { "ruby", "gem" }, "ruby", "a red gemstone")
			};
			LookCommand look = new LookCommand ();
			Player p = new Player ("bob", "ad");
			for (int i = 0; i < testItem.Length; i++) 
			{
				p.Inventory.Put (testItem[i]);
			}

			Assert.AreEqual (look.Execute (p, new string[]{ "look", "at", "ruby", "in", "bag" }), "I cannot find the bag");
		}

		[Test()]
		public void TestLookAtNoGemInBag()
		{
			Bag testBag = new Bag (new string[]{ "bag", "gem_bag" }, "Gem bag", "A bag containing gemstones");
			Player p = new Player ("bob", "ad");
			p.Inventory.Put (testBag);
			LookCommand look = new LookCommand ();

			Assert.AreEqual (look.Execute (p, new string[]{ "look", "at", "ruby", "in", "bag" }), "I cannot find the ruby in the bag");
		}

		[Test()]
		public void TestInvalidLook()
		{
			Player p = new Player ("bob", "ad");
			LookCommand look = new LookCommand ();

			Assert.AreEqual (look.Execute (p, new string[]{ "yo", "hello"}), "I don't know how to look like that");
			Assert.AreEqual (look.Execute (p, new string[]{ "see", "at", "stuff" }), "Error in look input");
			Assert.AreEqual (look.Execute (p, new string[]{ "look", "in", "stuff" }), "What do you want to look at?");
			Assert.AreEqual (look.Execute (p, new string[]{ "look", "at", "stuff", "at", "bag" }), "What do you want to look in?");
		}
	}
}

