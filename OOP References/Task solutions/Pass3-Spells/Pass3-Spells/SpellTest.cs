using NUnit.Framework;
using System;

namespace Pass3Spells
{
	[TestFixture ()]
	public class SpellTest
	{
		[Test ()]
		public void TestTeleport()
		{
			Spell spell = new Spell ("Shunkan Idou", SpellKind.Teleport); 

			Assert.IsTrue (spell.Cast () == "Poof… you appear somewhere else");
		}

		[Test()]
		public void TestHeal() 
		{
			Spell spell = new Spell ("Kaifuku", SpellKind.Heal);

			Assert.IsTrue (spell.Cast () == "Ahhh… you feel better");
		}

		[Test()]
		public void TestInvisibility()
		{
			Spell spell = new Spell ("Phase out", SpellKind.Invisibility);

			Assert.IsTrue (spell.Cast () == "Zippp… where am I?"); 	
		}

		[Test()]
		public void NameChangeTest()
		{
			Spell spell = new Spell ("Teleport", SpellKind.Teleport);
			Assert.IsTrue (spell.Name == "Teleport");
			spell.Name = "Warp in";
			Assert.IsFalse (spell.Name == "Teleport");
			Assert.IsTrue (spell.Name == "Warp in");		
		}

		[Test()]
		public void SpellAdditionTest()
		{
			SpellBook myBook = new SpellBook ();
			Spell testSpell = new Spell ("\"Mitch\'s mighty mover\"", SpellKind.Teleport);

			Spell s = testSpell;
			myBook.AddSpell (s);


			Assert.IsNotNull(myBook[0]);
			Assert.AreEqual(myBook[0].Name, "\"Mitch\'s mighty mover\"");
			Assert.AreEqual(myBook[0].Kind, SpellKind.Teleport);
		}

		[Test()]
		public void SpellFetchTest()
		{
			SpellBook myBook = new SpellBook();
			Spell[] testSpell = 
			{
				new Spell ("\"Mitch\'s mighty mover\"", SpellKind.Teleport),
				new Spell ("\"Paul\'s potent poultice\"", SpellKind.Heal),
				new Spell ("\"David\'s dashing disppearance\"", SpellKind.Invisibility)
			};

			for (int i = 0; i < testSpell.Length; i++)
			{
				Spell s = testSpell[i];
				myBook.AddSpell(s);
			}

			Assert.AreEqual(myBook[0], testSpell[0]);
			Assert.AreEqual(myBook[1], testSpell[1]);
			Assert.AreEqual(myBook[2], testSpell[2]);
		}
			
		[Test()]
		public void SpellRemovalTest()
		{
			SpellBook myBook = new SpellBook ();
			Spell[] testSpell = {
				new Spell ("\"Mitch\'s mighty mover\"", SpellKind.Teleport),
				new Spell ("\"Paul\'s potent poultice\"", SpellKind.Heal),
				new Spell ("\"David\'s dashing disppearance\"", SpellKind.Invisibility)
			};

			for (int i = 0; i < testSpell.Length; i++)
			{
				Spell s = testSpell[i];
				myBook.AddSpell(s);
			}

			Assert.AreEqual (myBook [1], testSpell [1]);
			Assert.AreEqual (myBook.SpellCount, 3);

			myBook.RemoveSpell (testSpell [1]);

			Assert.AreNotEqual (myBook [1], testSpell [1]);
			Assert.AreEqual (myBook.SpellCount, 2);
		}
}
}
