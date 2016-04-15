using System;

namespace SwinAdventure
{
	public class Player : GameObject, IHaveInventory
	{
		private Inventory _inventory = new Inventory();
		private Location _currentLocation = new Location(new string[]{"starting", "location"}, "Starting Location", "Where is this?");

		/// <summary>
		/// Initializes a new instance of the <see cref="SwinAdventure.Player"/> class.
		/// </summary>
		/// <param name="name">Name.</param>
		/// <param name="desc">Desc.</param>
		public Player (string name, string desc) : base (new string[] { "me", "inventory" }, name, desc)
		{
		}

		/// <summary>
		/// Locate the item with the specified id.
		/// </summary>
		/// <param name="id">Identifier.</param>
		public GameObject Locate(string id)
		{
			if (this.AreYou (id)) {
				return this;
			} else 
			{
				if (_inventory.Fetch (id) != null) {
					return _inventory.Fetch (id);
				} else 
				{
					return _currentLocation.Locate (id);
				}
			}
		}

		/// <summary>
		/// Returns the description of the player with their list of items in the inventory
		/// </summary>
		/// <value>The full description.</value>
		public override string FullDescription
		{
			get
			{
				string fullDesc = string.Format ("You are {0} {1}{2}You are carrying{3}{4}", _name, _description, Environment.NewLine, Environment.NewLine, _inventory.ItemList);

				return fullDesc;
			}
		}

		public Location CurrentLocation
		{
			get
			{
				return _currentLocation;
			}
		}

		public void Move(Location location)
		{
			_currentLocation = location;
		}

		/// <summary>
		/// Returns the inventory
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

