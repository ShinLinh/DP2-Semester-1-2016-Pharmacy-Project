using System;

namespace SwinAdventure
{
	public class Item : GameObject
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SwinAdventure.Item"/> class.
		/// </summary>
		/// <param name="ids">Identifiers.</param>
		/// <param name="name">Name.</param>
		/// <param name="desc">Desc.</param>
		public Item (string [] ids, string name, string desc) : base(ids, name, desc)
		{
		}
	}
}

