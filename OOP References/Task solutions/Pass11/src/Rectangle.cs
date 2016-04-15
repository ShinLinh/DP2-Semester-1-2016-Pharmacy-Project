using System;
using Color = System.Drawing.Color;
using SwinGameSDK;

namespace MyGame
{
	public class Rectangle : Shape
	{
		private int _width, _height;

		public Rectangle (Color clr, float x, float y, int width, int height) : base(clr)
		{
			//base.Colour = clr;
			base.X = x;
			base.Y = y;
			_width = width;
			_height = height;
		}

		public Rectangle () : this (Color.Green, 0, 0, 100, 100)
		{
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

		public override void DrawOutline()
		{
			SwinGame.DrawRectangle ( Color.Black, X-2, Y-2, _width+4, _height+4);	
		}

		public override void Draw()
		{
			SwinGame.FillRectangle ( Colour, X, Y, _width, _height);		
		}

		public override bool IsAt(Point2D pt)
		{
			return (SwinGame.PointInRect(pt, X, Y, Convert.ToSingle(_width), Convert.ToSingle(_height))); 
		}
	}
}

