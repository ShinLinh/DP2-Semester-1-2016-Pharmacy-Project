using System;

namespace SwinAdventure
{
	public class MoveCommand : Command
	{
		public MoveCommand () : base(new string[]{"move", "go", "head", "command"})
		{
		}

		public override string Execute (Player p, string[] text)
		{
			string result = null;
			string[] directions = new string[]{ "east", "southeast", "south", "southwest", "west", "northwest", "north", "up", "down" };

			if (text.Length != 2) 
			{
				result = "I cannot move like that";
			}
			else if (text[0] == "move" || text[0] == "head" || text[0] == "go")
			{
				bool directionIsValid = false;

				for (int i = 0; i < directions.Length; i++) 
				{
					if (text [1] == directions [i]) 
					{
						directionIsValid = true;
						break;
					}
				}

				if (directionIsValid)
				{
					result = MovePlayerWithPath (p, text[1]);
				}
				else
				{
					result = "That is not a direction";
				}
			} else
			{
				result = "I cannot move like that";
			}

			return result;
		}

		public string MovePlayerWithPath(Player p, string path)
		{
			Path usedPath = p.CurrentLocation.PathLocate (path);
			string result;
			if (usedPath != null)
			{
				result = String.Format ("You head {0}.{1}You {2}.{3}You arrived in {4}", usedPath.FirstId, Environment.NewLine, usedPath.Description, Environment.NewLine, usedPath.Destination.FullDescription);
				usedPath.MovePlayer (p);
			} else
				result = "No exit in that direction in the current location";
			
			return result;
		}
	}
}

