using System;

namespace SwinAdventure 
{
	public class Bag : Item, IHaveInventory
	{
		private Inventory _inventory = new Inventory();

		public Bag (string[] ids, string name, string desc) : base(ids, name, desc)
		{			
		}


		/// <summary>
		/// Locate the a game object using a string id
		/// </summary>
		/// <param name="id">Identifier.</param>
		public GameObject Locate (string id)
		{
			if (this.AreYou (id)) {
				return this;
			} else 
			{
				return _inventory.Fetch (id);
			}
		}

		/// <summary>
		/// Full description of a game object
		/// </summary>
		/// <value>The full description.</value>
		public override string FullDescription
		{
			get
			{
				string fullDesc = string.Format ("In the {0} you can see:{1}{2}", this.Name, Environment.NewLine, _inventory.ItemList);
				return fullDesc;
			}
		}

		/// <summary>
		/// Returns the inventory of a bag
		/// </summary>
		/// <value>The inventory.</value>
		public Inventory Inventory
		{
			get
			{
				return _inventory;
			}
		}
	}
}

