using NUnit.Framework;
using System;

namespace SwinAdventure
{
	[TestFixture ()]
	public class PathTest
	{
		[Test()]
		public void TestPathMove ()
		{
			Player testPlayer = new Player ("bob", "warrior");
			Location testLocation = new Location (new string[]{ "testing", "location" }, "Testing destination", "This is a location used as a destination test");
			Path testEastPath = new Path (new string[]{ "east", "path" }, testLocation, "a strange path");

			testPlayer.CurrentLocation.AddPath (testEastPath);
			Path currentPath = testPlayer.CurrentLocation.PathLocate ("east");
			currentPath.MovePlayer (testPlayer);
			Assert.AreSame (testPlayer.CurrentLocation, testLocation);
		}

		[Test()]
		public void TestPathDescription()
		{
			Location testLocation = new Location (new string[]{ "testing", "location" }, "Testing destination", "This is a location used as a destination test");
			Path testPath = new Path (new string[]{ "east", "path" }, testLocation, "a strange path");
		
			Assert.AreEqual (testPath.Description, "a strange path");
		}
	}
}

