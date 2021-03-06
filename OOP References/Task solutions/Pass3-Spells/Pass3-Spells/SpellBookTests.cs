using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Pass3Spells
{
	[TestFixture ()]
	public class SpellBookTest
	{
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

