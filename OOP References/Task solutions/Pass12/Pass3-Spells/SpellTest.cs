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
			Teleport spell = new Teleport ("Shunkan Idou"); 

			string s = spell.Cast ();
				
			if (spell.Success)
			{
				Assert.AreEqual (s, "Poof… you appear somewhere else");

				do 
				{
					s = spell.Cast ();
					if (!spell.Success) 
					{
						Assert.AreEqual (s, "arrr… I'm too tired to move"); 
					}						
				} while (spell.Success); 
			}
			else 
			{
				Assert.AreEqual (s, "arrr… I'm too tired to move");
				do 
				{
					s = spell.Cast ();
					if (spell.Success) 
					{
						Assert.AreEqual (s, "Poof… you appear somewhere else"); 
					}						
				} while (!spell.Success); 
			}
		}

		[Test()]
		public void TestHeal() 
		{
			Heal spell = new Heal ("Kaifuku");

			Assert.IsTrue (spell.Cast () == "Ahhh… you feel better");
		}

		[Test()]
		public void TestInvisibility()
		{
			Invisibility spell = new Invisibility ("Phase out");

			Assert.IsTrue (spell.Cast () == "Zippp… where am I?");
			Assert.AreEqual (spell.WasCast, true);
			Assert.AreEqual (spell.Cast (), "pzzzzit");
		}

		[Test()]
		public void NameChangeTest()
		{
			Teleport spell = new Teleport ("Teleport");
			Assert.IsTrue (spell.Name == "Teleport");
			spell.Name = "Warp in";
			Assert.IsFalse (spell.Name == "Teleport");
			Assert.IsTrue (spell.Name == "Warp in");		
		}

	
	}
}
