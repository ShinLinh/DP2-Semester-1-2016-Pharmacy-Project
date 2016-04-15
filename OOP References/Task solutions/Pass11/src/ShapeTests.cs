using System;
using NUnit.Framework;
using Color = System.Drawing.Color;
using SwinGameSDK;

namespace MyGame
{
	[TestFixture()]
	public class ShapeTest
	{
		[Test()]
		public void TestShapeAt()
		{
			Rectangle s = new Rectangle();

			s.X = 25;
			s.Y = 25;
			s.Width = 50;
			s.Height = 50;

			Assert.IsTrue(s.IsAt(SwinGame.PointAt(50,50)));
			Assert.IsTrue(s.IsAt(SwinGame.PointAt(25,25)));
			Assert.IsFalse(s.IsAt(SwinGame.PointAt(10,50)));
			Assert.IsFalse(s.IsAt(SwinGame.PointAt(50,10)));
		}

		[Test()]
		public void TestShapeAtWhenMove()
		{
			Rectangle s = new Rectangle ();

			s.X = 50;
			s.Y = 50;
			s.Width = 50;
			s.Height = 50;

			Assert.IsTrue (s.IsAt (SwinGame.PointAt (75, 75)));

			s.X = 200;
			s.Y = 200;

			Assert.IsFalse (s.IsAt (SwinGame.PointAt (75, 75)));
		}

		[Test()]
		public void TestShapeAtWhenResized()
		{
			Rectangle s = new Rectangle ();

			s.X = 50;
			s.Y = 50;
			s.Width = 100;
			s.Height = 100;

			Assert.IsTrue (s.IsAt (SwinGame.PointAt (120, 120)));

			s.Width = 10;
			s.Height = 10;

			Assert.IsFalse (s.IsAt (SwinGame.PointAt (120, 120)));
		}

		[Test()]
		public void TestIsSelected()
		{
			Rectangle myShape = new Rectangle ();

			Assert.IsFalse (myShape.IsSelected);

			myShape.IsSelected = true;

			Assert.IsTrue(myShape.IsSelected);
		}

		[Test()]
		public void ShapeConstructionTest ()
		{
			Rectangle myShape = new Rectangle (Color.Green, 50,75, 100, 150);

			Assert.AreEqual(myShape.X, 50);
			Assert.AreEqual(myShape.Y, 75);
			Assert.AreEqual(myShape.Width, 100);
			Assert.AreEqual(myShape.Height, 150);
		}
	}
}
