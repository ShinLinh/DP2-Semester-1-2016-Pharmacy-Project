using System;
using System.Collections.Generic;

namespace SwinAdventure
{
	public class Inventory
	{
		private List<Item> _items = new List<Item>();

		/// <summary>
		/// Initializes a new instance of the <see cref="SwinAdventure.Inventory"/> class.
		/// </summary>
		public Inventory ()
		{
		}

		/// <summary>
		/// Determines whether this instance has item the specified id.
		/// </summary>
		/// <returns><c>true</c> if this instance has item the specified id; otherwise, <c>false</c>.</returns>
		/// <param name="id">Identifier.</param>
		public bool HasItem(string id)
		{
			bool result = false;

			for (int i = 0; i < _items.Count; i++)
			{
				if (_items[i].AreYou (id))
				{
					result = true;
					break;
				}
			}

			return result;
		}

		/// <summary>
		/// Add an item object to the inventory
		/// </summary>
		/// <param name="itm">Itm.</param>
		public void Put(Item itm)
		{
			_items.Add (itm);
		}

		/// <summary>
		/// Remove the item with identifier identical to string id
		/// </summary>
		/// <param name="id">Identifier.</param>
		public Item Take(string id)
		{
			Item result = null;

			for (int i = 0; i < _items.Count; i++)
			{
				if (_items[i].AreYou (id))
				{
					result = _items[i];
					_items.Remove (_items [i]);
					break;
				}
			}

			return result;
		}

		/// <summary>
		/// Fetch the item with the specified id.
		/// </summary>
		/// <param name="id">Identifier.</param>
		public Item Fetch(string id)
		{
			Item result = null;

			for (int i = 0; i < _items.Count; i++)
			{
				if (_items[i].AreYou (id))
				{
					result = _items[i];
					break;
				}
			}

			return result;
		}

		/// <summary>
		/// Returns the list of items in the inventory as a string
		/// </summary>
		/// <value>The item list.</value>
		public string ItemList 
		{
			get
			{
				string itmList = System.String.Empty;

				for (int i = 0; i < _items.Count; i++)
				{
					string newItemString = string.Format (" {0} ({1}){2}", _items [i].ShortDescription, _items [i].FirstId, Environment.NewLine);
					itmList += newItemString;
				}

				return itmList;
			}
		}
	}
}

