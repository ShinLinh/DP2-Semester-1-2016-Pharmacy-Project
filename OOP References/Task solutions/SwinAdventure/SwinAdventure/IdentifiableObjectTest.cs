using NUnit.Framework;
using System;

namespace SwinAdventure
{
	[TestFixture ()]
	public class IdentifiableObjectTest
	{
		[Test ()]
		public void TestCreation ()
		{
			string[] s = new string[]{ "id1", "id2" };

			IdentifiableObject testId = new IdentifiableObject (s);

			Assert.IsNotNull (testId);
			Assert.IsTrue(testId.AreYou("id1"));
		}

		[Test()]
		public void TestAreYou()
		{
			string[] s = new string[]{ "bob", "fred" };

			IdentifiableObject testId = new IdentifiableObject (s);

			Assert.IsTrue(testId.AreYou("bob"));
			Assert.IsTrue (testId.AreYou ("fred"));
		}

		[Test()]
		public void TestNotAreYou()
		{
			string[] s = new string[]{ "bob", "fred" };

			IdentifiableObject testId = new IdentifiableObject (s);

			Assert.IsFalse(testId.AreYou("mad"));
			Assert.IsFalse (testId.AreYou ("bro"));
		}

		[Test()]
		public void TestCaseSensitivity()
		{
			string[] s = new string[]{ "bob", "fred" };

			IdentifiableObject testId = new IdentifiableObject (s);

			Assert.IsFalse(testId.AreYou("BOB"));
			Assert.IsFalse (testId.AreYou ("Fred"));
		}

		[Test()]
		public void TestFirstId()
		{
			string[] s = new string[]{ "bob", "fred" };

			IdentifiableObject testId = new IdentifiableObject (s);	

			Assert.AreEqual (testId.FirstId, "bob");
			Assert.AreNotEqual (testId.FirstId, "fred");
		}

		[Test()]
		public void TestAddId()
		{
			string[] s = new string[]{ "bob", "fred" };

			IdentifiableObject testId = new IdentifiableObject (s);

			testId.AddIdentifier ("vader");

			Assert.IsTrue(testId.AreYou("vader"));

			testId.AddIdentifier ("MaX");

			Assert.IsTrue (testId.AreYou ("max"));

		
		}
	} 
}

