using System;
using System.Collections.Generic;

namespace SwinAdventure
{
	public class CommandProcessor
	{
		List<Command> _commandList = new List<Command>();

		public CommandProcessor ()
		{
			_commandList.Add(new MoveCommand());
			_commandList.Add(new LookCommand());
		}

		public Command CommandFetch(string id)
		{
			for (int i = 0; i < _commandList.Count; i++)
			{
				if (_commandList[i].AreYou(id))
					return _commandList[i];
			}

			return null;
		}

		public string ExecuteCommand(Player p, string text)
		{
			string[] commandStringArray = text.Split (' ');

			Command commandChosen = null;

			switch (commandStringArray[0])
			{
			case "move":
				commandChosen = CommandFetch("move");
				return commandChosen.Execute(p, commandStringArray);
				//break;
			case "go":
				commandChosen = CommandFetch("move");
				return commandChosen.Execute(p, commandStringArray);
				//break;
			case "head":
				commandChosen = CommandFetch("move");
				return commandChosen.Execute(p, commandStringArray);
				//break;
			case "look":
				commandChosen = CommandFetch("look");
				return commandChosen.Execute(p, commandStringArray);
				//break;
			default:
				return String.Format("I don't understand {0}.", commandStringArray);
			//break;
			}
		}
	}
}

