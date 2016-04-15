using System;

namespace SwinAdventure
{
	public abstract class GameObject : IdentifiableObject
	{
		protected string _description;
		protected string _name;

		public GameObject (string[] ids, string name, string desc) : base(ids)
		{
			_description = desc;
			_name = name;
		}

		/// <summary>
		/// Returns the name of the object
		/// </summary>
		/// <value>The name.</value>
		public string Name
		{
			get
			{
				return _name;
			}
		}

		/// <summary>
		/// Return the short description of an object
		/// </summary>
		/// <value>The short description.</value>
		public string ShortDescription
		{
			get
			{
				return _description;
			}
		}

		/// <summary>
		/// Returns the full description of an object
		/// </summary>
		/// <value>The full description.</value>
		public virtual string FullDescription
		{
			get
			{
				return _description;
			}
		}
	}
}

