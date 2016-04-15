using System;

namespace Pass3Spells
{
	/// The Heal class. A subclass of the Spell class. Will always return a single string when Cast() method is called.
	public class Heal : Spell
	{
		/// <summary>
		/// Initializes a new Heal Spell object, taking in a string parameter to use for the name of the spell.
		/// </summary>
		public Heal (string spellName) : base(spellName, SpellKind.Heal)
		{
		}

		/// <summary>
		/// Casts the spell. Returns a fixed string;
		/// </summary>
		public override string Cast ()
		{
			return "Ahhh… you feel better";
		}
	}
}

