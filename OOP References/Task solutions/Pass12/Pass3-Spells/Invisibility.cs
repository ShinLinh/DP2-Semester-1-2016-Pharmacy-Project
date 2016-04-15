using System;

namespace Pass3Spells
{
	/// <summary>
	/// The Invisibility class. A subclass of the Spell class. Can only be cast once.
	/// </summary>
	public class Invisibility : Spell
	{
		private bool _wasCast = false;

		/// <summary>
		/// Initializes a new Invisibility Spell object, taking in a string parameter to use for the name of the spell.
		/// </summary>
		public Invisibility (string spellName) : base(spellName, SpellKind.Invisibility)
		{
		}

		/// <summary>
		/// Gets the value of _wasCast field, which indicates whether the spell has been cast at least once or not.
		/// </summary>
		public bool WasCast
		{
			get
			{
				return _wasCast;
			}
		}

		/// <summary>
		/// Casts the spell. Returns a string depending on the value in the _wasCast field.
		/// </summary>
		public override string Cast()
		{
			if (!_wasCast) 
			{
				_wasCast = true;
				return "Zippp… where am I?";
			} else 
			{
				return "pzzzzit";
			}
		}
	}
}

