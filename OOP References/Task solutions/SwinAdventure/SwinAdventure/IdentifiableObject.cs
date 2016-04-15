using System;
using System.Collections.Generic;

namespace SwinAdventure
{
	public class IdentifiableObject
	{
		private List<string> _identifiers = new List<string>(); 

		public IdentifiableObject (string[] idents)
		{
			foreach (string id in idents) 
			{
				_identifiers.Add (id.ToLower());
			}
		}

		/// <summary>
		/// Checks if the identifiable object is the same as the one requested or not using a string ID
		/// </summary>
		/// <returns><c>true</c>, if you was ared, <c>false</c> otherwise.</returns>
		/// <param name="id">Identifier.</param>
		public bool AreYou (string id)
		{
			return _identifiers.Contains (id);
		}

		/// <summary>
		/// Returns the first ID of the object
		/// </summary>
		/// <value>The first identifier.</value>
		public string FirstId
		{
			get 
			{
				if (_identifiers.Count > 0) 
				{
					return _identifiers [0];
				} else 
				{
					return "";
				}
			}
		}

		/// <summary>
		/// Adds identifier to the __identifiers field
		/// </summary>
		/// <param name="id">Identifier.</param>
		public void AddIdentifier(string id)
		{
			_identifiers.Add (id.ToLower ());
		}
	}
}

