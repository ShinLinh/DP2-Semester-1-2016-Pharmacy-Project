using System;
using System.Collections.Generic;

namespace SwinAdventure
{
	public class Location : GameObject, IHaveInventory
	{
		private Inventory _inventory = new Inventory();
		private List<Path> _paths = new List<Path>();

		public Location (string[] ids, string name, string desc) : base(ids, name, desc)
		{
		}

		public GameObject Locate (string id)
		{
			if (this.AreYou (id)) {
				return this;
			} else 
			{
				return _inventory.Fetch (id);
			}
		}

		public Path PathLocate(string id)
		{
			Path result = null;
			for (int i = 0; i < _paths.Count; i++) 
			{
				if (_paths [i].FirstId == id) 
				{
					result = _paths [i];
				}
			}

			return result;
		}
		
		public void AddPath(Path newPath)
		{
			for (int i = 0; i < _paths.Count; i++) 
			{
				if (_paths [i].FirstId == newPath.FirstId) 
				{
					return;
				}
			}
			_paths.Add (newPath);
		}
			
		public string PathList
		{
			get
			{
				string result = System.String.Empty;

				for (int i = 0; i < _paths.Count; i++) 
				{
					if ((_paths.Count > 1)) {
						if (i == _paths.Count - 1)
							result = result + "and " + _paths [i].FirstId + ".";
						else
							result = result + _paths [i].FirstId + ", ";
					} else
						result = _paths [i].FirstId + ".";
				}

				return result;
			}
		}

		public override string FullDescription
		{
			get
			{
				string fullDesc = System.String.Empty;

				if (_paths.Count > 0) {
					fullDesc = String.Format ("{0}{1}There are exits to the {2}{3}In this room I can see:{4}{5}", _description, Environment.NewLine, PathList, Environment.NewLine, Environment.NewLine, _inventory.ItemList);
				} else 
				{
					fullDesc = String.Format ("{0}{1}You cannot find any exit in this room{2}In this room I can see:{3}{4}", _description, Environment.NewLine, Environment.NewLine, Environment.NewLine, _inventory.ItemList);
				}

				return fullDesc;
			}
		}

		public Inventory Inventory
		{
			get
			{
				return _inventory;
			}
		}
	}
}

