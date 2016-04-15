using System;
using System.Collections.Generic;
using SwinGameSDK;
using Color = System.Drawing.Color;

namespace MyGame
{
	public class Drawing
	{
		private readonly List<Shape> _shapes;
		private Color _background;

		public Drawing (Color background)
		{
			_shapes = new List<Shape>();
			_background = background;
		}

		public Drawing () : this (Color.White)
		{
		}

		public Color Background
		{
			get
			{
				return _background;
			}
			set
			{
				_background = value;
			}
		}

		public int ShapeCount
		{
			get
			{
				return _shapes.Count;
			}
		}

		public void AddShape(Shape newShape)
		{
			_shapes.Add (newShape);
		}

		public void SelectShapesAt(Point2D point)
		{
			Shape s;

			for (int i = 0; i < _shapes.Count; i++)
			{
				s = _shapes [i];
				s.IsSelected = s.IsAt (point);
			}
		}

		public List<Shape> SelectedShapes
		{			
			get
			{ 
				List<Shape> result = new List<Shape>();
				Shape s;

				for (int i = 0; i < _shapes.Count; i++)
				{
					s = _shapes[i];
					if (s.IsSelected)
					{
						result.Add(s);
					}
				}
				return result;
			}
		}

		public void RemoveShape (Shape shape)
		{
			_shapes.Remove (shape);
		}

		public void Draw()
		{
			SwinGame.ClearScreen (_background);

			for (int i = 0; i < _shapes.Count; i++)
			{
				_shapes [i].Draw ();
				if (_shapes [i].IsSelected)
				{
					_shapes [i].DrawOutline();
				}
			}
		}


	}
}

