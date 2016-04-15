using System;

namespace SwinAdventure
{
	public class LookCommand : Command
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SwinAdventure.LookCommand"/> class.
		/// </summary>
		public LookCommand () : base(new string[]{"look", "command"})
		{
		}

		/// <summary>
		/// Execute a command, taking in a player parameter and a string array
		/// </summary>
		/// <param name="p">P.</param>
		/// <param name="text">Text.</param>
		public override string Execute(Player p, string[] text)
		{
			string result = System.String.Empty;

			if (text.Length == 3 || text.Length == 5) 
			{
				if (text [0] == "look") 
				{
					if (text [1] == "at") 
					{
						if (text.Length == 3) 
						{
							result = LookAtIn (p, text [2], "inventory");
						} else 
						{
							if (text [3] == "in") {
								result = LookAtIn (p, text [2], text [4]);
							} else 
							{
								result = "What do you want to look in?";
							}
						}
					} else 
					{
						result = "What do you want to look at?";
					}
				} else 
				{
					result = "Error in look input";
				} 
			} else 
			{
				result = "I don't know how to look like that";
			}

			return result;
		}

		/// <summary>
		///	Locate the object in specified container and return its full description string
		/// </summary>
		/// <returns>The at in.</returns>
		/// <param name="p">P.</param>
		/// <param name="thingId">Thing identifier.</param>
		/// <param name="containerId">Container identifier.</param>
		public string LookAtIn(Player p, string thingId, string containerId)
		{
			string result = System.String.Empty;

			if (containerId == "inventory") 
			{
				if (p.Locate ("inventory") == p) 
				{
					if (p.Locate (thingId) != null) {
						result = p.Locate (thingId).FullDescription;
					} else 
					{
						result = String.Format("I cannot find the {0}", thingId);
					}
				} else
				{
					result = "Inventory not found";
				}
			} else
			{
				if (p.Locate (containerId) != null) 
				{
					GameObject obj = p.Locate (containerId);
					IHaveInventory container = obj as IHaveInventory;

					if (container.Locate (thingId) != null) {
						result = container.Locate (thingId).FullDescription;
					} else {	
						result = String.Format ("I cannot find the {0} in the {1}", thingId, containerId);
					}

				} else 
				{
					return String.Format ("I cannot find the {0}", containerId);
				}
			}

			return result;
		}
	}
}

