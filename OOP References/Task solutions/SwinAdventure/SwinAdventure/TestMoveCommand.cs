using NUnit.Framework;
using System;

namespace SwinAdventure
{
	[TestFixture ()]
	public class TestMoveCommand
	{
		[Test()]
		public void TestInvalidMoveCommand ()
		{
			MoveCommand move = new MoveCommand ();
			Player testPlayer = new Player ("bob", "warrior");
			Location testLocation = new Location (new string[]{ "testing", "location" }, "Testing destination", "This is a location used as a destination test");
			Path testEastPath = new Path (new string[]{ "east", "path" }, testLocation, "a strange path");

			testPlayer.CurrentLocation.AddPath (testEastPath);
			Assert.AreEqual (move.Execute (testPlayer, new string[]{ "look", "there" }), "I cannot move like that");
			Assert.AreEqual (move.Execute (testPlayer, new string[]{ "move" }), "I cannot move like that");
		}

		[Test()]
		public void TestInvalidDirectionCommand()
		{
			MoveCommand move = new MoveCommand ();
			Player testPlayer = new Player ("bob", "warrior");
			Location testLocation = new Location (new string[]{ "testing", "location" }, "Testing destination", "This is a location used as a destination test");
			Path testEastPath = new Path (new string[]{ "east", "path" }, testLocation, "a strange path");

			testPlayer.CurrentLocation.AddPath (testEastPath);
			Assert.AreEqual (move.Execute (testPlayer, new string[]{ "move", "sub"}), "That is not a direction");
		}

		[Test()]
		public void TestPlayerMoveSuccess()
		{
			MoveCommand move = new MoveCommand ();
			Player testPlayer = new Player ("bob", "warrior");
			Location testLocation = new Location (new string[]{ "testing", "location" }, "Testing destination", "This is a location used as a destination test");
			Path testEastPath = new Path (new string[]{ "east", "path" }, testLocation, "a strange path");

			testPlayer.CurrentLocation.AddPath (testEastPath);
			string testString = String.Format ("You head {0}.{1}You {2}.{3}You arrived in {4}", testEastPath.FirstId, Environment.NewLine, testEastPath.Description, Environment.NewLine, testLocation.FullDescription);
			Assert.AreEqual (move.Execute (testPlayer, new string[]{ "move", "east"}), testString);
			Assert.AreSame (testPlayer.CurrentLocation, testLocation);
		}

		[Test()]
		public void TestPlayerMoveFailure()
		{
			MoveCommand move = new MoveCommand ();
			Player testPlayer = new Player ("bob", "warrior");
			Location testLocation = new Location (new string[]{ "testing", "location" }, "Testing destination", "This is a location used as a destination test");
			Path testEastPath = new Path (new string[]{ "east", "path" }, testLocation, "a strange path");

			testPlayer.CurrentLocation.AddPath (testEastPath);
			Assert.AreEqual (move.Execute (testPlayer, new string[]{ "move", "south"}), "No exit in that direction in the current location" );
		}
	}
}

