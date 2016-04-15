using System;
using SwinGameSDK;
using Color = System.Drawing.Color;
using Point2D = SwinGameSDK.Point2D;
	
namespace MyGame
{
	public class Shape
	{
		private Color _color;
		private float _x, _y;
		private int _width, _height;
		private bool _selected;

		public Shape(Color color, float x, float y, int width, int height)
		{
			_color = color;
			_x = x;
			_y = y;
			_width = width;
			_height = height;
			_selected = false;
		}

		public Shape() : this (Color.Green, 0, 0, 100, 100)
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

		public int Width
		{
			get
			{
				return _width;
			}
			set
			{
				_width = value;
			}
		}

		public int Height
		{
			get
			{
				return _height;
			}
			set
			{
				_height = value;
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


		public void DrawOutline()
		{
			SwinGame.DrawRectangle ( Color.Black, _x, _y, _width, _height);	
		}


		public void Draw()
		{
			SwinGame.FillRectangle ( _color, _x, _y, _width, _height);		
		}

		public bool IsAt(Point2D pt)
		{
			return (SwinGame.PointInRect(pt, _x, _y, Convert.ToSingle(_width), Convert.ToSingle(_height))); 
		}


	}
}
