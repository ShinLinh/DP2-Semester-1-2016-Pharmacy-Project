using System;
using System.Collections.Generic;

namespace Pass3Spells
{
	public class SpellBook
	{
		private readonly List<Spell> _spells;

		/// <summary>
		/// Initialize a new SpellBook object
		/// </summary>
		public SpellBook ()
		{
			_spells = new List<Spell> ();
		}

		/// <summary>
		/// Add a new spell to the spell book
		/// </summary>
		public void AddSpell (Spell addition)
		{
			_spells.Add (addition);
		}

		/// <summary>
		/// Remove an existing spell from the spell book
		/// </summary>
		public void RemoveSpell(Spell remove)
		{
			_spells.Remove (remove);
		}

		/// <summary>
		/// A property indicating the number of spells recorded in the spell book
		/// </summary>
		public int SpellCount
		{
			get
			{
				return _spells.Count;
			}
		}

		/// <summary>
		/// Indexer allows direct access to indexed objects in the _spells field of the SpellBook object
		/// </summary>
		public Spell this[int i]
		{
			get
			{
				return _spells [i];	
			}
		}
	}
}

