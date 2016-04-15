using System;

namespace SwinAdventure
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Item[] testItem = new Item[] {
				new Item (new string[] { "emerald", "gem" }, "emerald", "a green gemstone"),
				new Item (new string[] { "ruby", "gem" }, "ruby", "a red gemstone")
			};
			Item betaSword = new Item (new string[]{"sword"}, "sword", "not a really sharp weapon");
			string playerName = System.String.Empty;
			string playerDesc = System.String.Empty;

			LookCommand look = new LookCommand ();
			MoveCommand move = new MoveCommand ();
			CommandProcessor commandHandler = new CommandProcessor ();
			Bag testBag = new Bag (new string[]{ "bag", "gem_bag" }, "Gem bag", "A bag containing gemstones");
			for (int i = 0; i < testItem.Length; i++) 
			{
				testBag.Inventory.Put (testItem[i]);
			}

			Location testLocation = new Location(new string[]{"test", "location"}, "Testing location", "a location used for testing");
			Path testPath = new Path (new string[]{ "east", "path" }, testLocation, "walk through a strange path");
			Path testPath2 = new Path (new string[]{ "south", "path" }, testLocation, "walk through a strange path");

			while (playerName == System.String.Empty) {
				Console.Write ("Enter your name: ");
				playerName = Console.ReadLine ();
			}
			while (playerDesc == System.String.Empty) {
				Console.Write ("Enter a description of you: ");
				playerDesc = Console.ReadLine ();
			}

			Player p = new Player (playerName, playerDesc);
			testLocation.Inventory.Put (testBag);
			p.Inventory.Put (betaSword);

			p.CurrentLocation.AddPath (testPath);
			p.CurrentLocation.AddPath (testPath2);
			string command = System.String.Empty;
			//string[] commandStringArray = new string[]{};
			Console.WriteLine (p.CurrentLocation.FullDescription);
			Console.WriteLine (p.FullDescription);

			do 
			{
				//Console.WriteLine(commandStringArray.Length);
				if (command != System.String.Empty)
				{
					Console.WriteLine(commandHandler.ExecuteCommand(p, command));
				}

				Console.Write("Enter command -> ");
				command = Console.ReadLine ();
				//Console.Write(command);
				//Console.WriteLine("Enter command -> ");
			} while (command != "exit"); 

		}
	}
}
