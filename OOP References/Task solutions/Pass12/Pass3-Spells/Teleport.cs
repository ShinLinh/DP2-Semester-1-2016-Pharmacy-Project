using System;

namespace Pass3Spells
{
	/// The Teleport class. A subclass of the Spell class. Has 50% chance of failure.
	public class Teleport : Spell
	{
		private static Random _random = new Random();
		private bool _succeeded;

		/// <summary>
		/// Initializes a new Teleport Spell object, taking in a string parameter to use for the name of the spell
		/// </summary>
		public Teleport (string spellName) : base(spellName, SpellKind.Teleport)
		{
		}

		/// <summary>
		/// A property for getting the _succeeded field, which indicates whether the spell was successful or not.
		/// </summary>
		public bool Success
		{
			get
			{
				return _succeeded;
			}
		}

		/// <summary>
		/// Casts the spell. Retursn a string depending on the value in the _succeeded field
		/// </summary>
		public override string Cast ()
		{
			if (_random.NextDouble () < 0.5) 
			{
				_succeeded = true;

			} else 
			{
				_succeeded = false;
			}

			if (_succeeded) {
				return "Poof… you appear somewhere else";
			} else 
			{
				return "arrr… I'm too tired to move";
			}
		}
	}
}

