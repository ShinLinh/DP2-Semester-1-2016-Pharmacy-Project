using NUnit.Framework;
using System;
using SwinGameSDK;
using Color = System.Drawing.Color;
using System.Collections.Generic;

namespace MyGame
{
	[TestFixture ()]
	public class DrawingUnitTest
	{
		[Test ()]
		public void TestDefaultInitialization ()
		{
			Drawing drawing = new Drawing ();

			Assert.IsTrue (drawing.Background == Color.White);
		}

		[Test()]
		public void TestInitializeWithColor()
		{
			Drawing drawing = new Drawing (Color.Red);

			Assert.IsTrue (drawing.Background == Color.Red);
		}

		[ Test()]
		public void TestAddShape ( )
		{
			Drawing myDrawing = new Drawing();
			int count = myDrawing.ShapeCount;

			Assert.AreEqual( 0, count, "Drawing should start with no shapes" ); 

			myDrawing.AddShape( new Shape() );
			myDrawing.AddShape( new Shape() );
			count = myDrawing.ShapeCount; 

			Assert.AreEqual( 2, count, "Adding two shapes should increasethe count to 2" );
		}

		[Test()]
		public void TestSelectShape ( )
		{
			Drawing myDrawing = new Drawing();
			Shape[] testShapes = {
				new Shape(Color.Red, 25, 25, 50, 50),
				new Shape(Color.Green, 25, 10, 50, 50),
				new Shape(Color.Blue, 10, 25, 50, 50) }; 
			for (int i = 0; i < testShapes.Length; i++)
			{
				myDrawing.AddShape (testShapes [i]);
			}

			List<Shape> selected;
			Point2D point;

			point = SwinGame.PointAt (70, 70);
			myDrawing.SelectShapesAt (point);
			selected = myDrawing.SelectedShapes;
			CollectionAssert.Contains (selected, testShapes [0]);
			Assert.AreEqual (1, selected.Count);

			point = SwinGame.PointAt (70,50);
			myDrawing.SelectShapesAt (point);
			selected = myDrawing.SelectedShapes;
			CollectionAssert.Contains(selected, testShapes[0]);
			CollectionAssert.Contains(selected, testShapes[1]);
			Assert.AreEqual(2, selected.Count);

			point = SwinGame.PointAt(50,50);
			myDrawing.SelectShapesAt (point);
			selected = myDrawing.SelectedShapes;
			CollectionAssert.Contains(selected, testShapes[0]);
			CollectionAssert.Contains(selected, testShapes[1]);
			CollectionAssert.Contains(selected, testShapes[2]);
			Assert.AreEqual(3, selected.Count);
		}

		[Test()]
		public void RemoveShapesTest()
		{
			Drawing myDrawing = new Drawing();
			Shape[] testShapes = {
				new Shape(Color.Red, 25, 25, 50, 50),
				new Shape(Color.Green, 25, 10, 50, 50),
				new Shape(Color.Blue, 10, 25, 50, 50) };
			for (int i = 0; i < testShapes.Length; i++)
			{
				myDrawing.AddShape (testShapes [i]);
			}

			Assert.AreEqual(myDrawing.ShapeCount, 3);

			myDrawing.RemoveShape (testShapes[1]);

			Assert.AreEqual(myDrawing.ShapeCount, 2);
		}
	}
}

