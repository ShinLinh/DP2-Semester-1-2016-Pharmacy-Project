using System;
using SwinGameSDK;
using Color = System.Drawing.Color;
using Point2D = SwinGameSDK.Point2D;
	
namespace MyGame
{
	public abstract class Shape
	{
		private Color _color;
		private float _x, _y;
		private bool _selected;

		public Shape(Color color)
		{
			_color = color;
		}

		public Shape() : this (Color.White)
		{
		}
		
		public Color Colour
		{
			get
			{
				return _color;
			}
			set
			{
					_color = value;
			}
		}

		public float X
		{
			get
			{
				return _x;
			}
			set
			{
				_x = value;
			}
		}

		public float Y
		{
			get
			{
				return _y;
			}
			set
			{
				_y = value;
			}
		}

		public bool IsSelected
		{
			get
			{
				return _selected;
			}
			set
			{
				_selected = value;
			}
		}


		public abstract void DrawOutline ();

		public abstract void Draw ();

		public abstract bool IsAt (Point2D pt);
	}
}
