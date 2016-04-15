using System;
using SwinGameSDK;
using Color = System.Drawing.Color;

namespace MyGame
{
	public class Line : Shape
	{
		private float _endX;
		private float _endY;

		public Line (Color clr, float x, float y, float endX, float endY) : base(clr)
		{
			base.X = x;
			base.Y = y;
			_endX = endX;
			_endY = endY;
		}

		public Line () : this (Color.Blue, 0, 0, 50, 0)
		{
		}

		public float EndX
		{
			get
			{
				return _endX;
			}
			set
			{
				_endX = value;
			}
		}

		public float EndY
		{
			get
			{
				return _endY;
			}
			set
			{
				_endY = value;
			}
		}

		public override void DrawOutline()
		{
			SwinGame.DrawCircle(Color.Black, X, Y, 2);
			SwinGame.DrawCircle(Color.Black, _endX, _endY, 2);
		}

		public override void Draw()
		{
			SwinGame.DrawLine (Colour, X, Y, _endX, _endY);		
		}

		public override bool IsAt(Point2D pt)
		{
			return (SwinGame.PointOnLine (pt, X, Y, _endX, _endY)); 
		}
	}
}

