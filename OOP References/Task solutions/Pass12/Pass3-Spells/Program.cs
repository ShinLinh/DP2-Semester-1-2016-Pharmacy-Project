using System;

namespace Pass3Spells
{
	class MainClass
	{
		public static void CastAll (SpellBook spellBook)
		{
			for (int i = 0; i < spellBook.SpellCount; i++)
			{
				//Console.Write ("Casting {0} ... ", myGrimoire [i].Name);
				//Console.WriteLine(spells[i].Cast());

				Console.WriteLine ("Casting {0} ... {1}", spellBook[i].Name, spellBook[i].Cast ());
			}
		}

		public static void Main (string[] args)
		{
			Spell[] spells = new Spell[5];
			SpellBook myGrimoire = new SpellBook ();

			spells [0] = new Teleport ("\"Mitch\'s mighty mover\"");
			spells [1] = new Heal ("\"Paul\'s potent poultice\"");
			spells [2] = new Invisibility ("\"David\'s dashing disppearance\"");
			spells [3] = new Teleport ("\"Stan\'s stunning shifter\"");
			spells [4] = new Heal ("\"Lachlan\'s lavish longetivity\"");

			for (int i = 0; i < 5; i++) 
			{
				myGrimoire.AddSpell (spells [i]);
			}
			MainClass.CastAll (myGrimoire);
		}
	}
}
