using System;

namespace SwinAdventure
{
	public abstract class Command : IdentifiableObject
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SwinAdventure.Command"/> class.
		/// </summary>
		/// <param name="ids">Identifiers.</param>
		public Command (string[] ids) : base(ids)
		{
		}

		/// <summary>
		/// Execute a command, taking in a player parameter and a string array
		/// </summary>
		/// <param name="p">P.</param>
		/// <param name="text">Text.</param>
		public abstract string Execute (Player p, string[] text); 
	}
}

