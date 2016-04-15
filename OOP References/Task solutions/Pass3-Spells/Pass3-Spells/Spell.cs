using System;

namespace Pass3Spells
{	
	/// <summary>
	/// The Spell class. Contains the name and kind of each spell, as well as a cast method to 
	/// return a string depending on the type of spell. 
	/// </summary>
	public class Spell
	{
		private string _name;
		private SpellKind _kind;

		/// <summary>
		/// Initializes a new instance of the Spell class.
		/// </summary>
		/// <param name="name">Name. Name of the spell</param>
		/// <param name="kind">Kind.Type of spell. Will determine result string for Cast method</param>
		public Spell (string name, SpellKind kind)
		{
			_name = name;
			_kind = kind;
		}

		/// <summary>
		/// Gets or sets the value for the _name field
		/// </summary>
		/// <value>_name</value>
		public string Name
		{
			get 
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}

		/// <summary>
		/// Gets or sets the value for the _kind field
		/// </summary>
		/// <value>_kind</value>
		public SpellKind Kind
		{
			get
			{
				return _kind;
			}
		}

		/// <summary>
		/// Casts the spell. Returns a string depending on the value in the _kind field.
		/// </summary>
		public string Cast()
		{
			switch (_kind)
			{
			case SpellKind.Teleport:
				return "Poof… you appear somewhere else";
				//break;
			case SpellKind.Heal:
				return "Ahhh… you feel better";
				//break;
			case SpellKind.Invisibility:
				return "Zippp… where am I?";
				//break;
			default:
				return "Nothing's happening?";
				//break;
			}
		}
	}
}

