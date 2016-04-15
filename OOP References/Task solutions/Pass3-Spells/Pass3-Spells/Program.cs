using System;

namespace Pass3Spells
{
	class MainClass
	{
		public static void CastAll (Spell[] spells)
		{
			for (int i = 0; i < spells.Length; i++)
			{
				Console.Write ("Casting {0} ... ", spells [i].Name);
				Console.WriteLine(spells[i].Cast());
			}
		}

		public static void Main (string[] args)
		{
			Spell[] spells = new Spell[5];

			spells [0] = new Spell ("\"Mitch\'s mighty mover\"", SpellKind.Teleport);
			spells [1] = new Spell ("\"Paul\'s potent poultice\"", SpellKind.Heal);
			spells [2] = new Spell ("\"David\'s dashing disppearance\"", SpellKind.Invisibility);
			spells [3] = new Spell ("\"Stan\'s stunning shifter\"", SpellKind.Teleport);
			spells [4] = new Spell ("\"Lachlan\'s lavish longetivity\"", SpellKind.Heal);

			MainClass.CastAll (spells);
		}
	}
}
