using System;
using SwinGameSDK;
using Color = System.Drawing.Color;

namespace MyGame
{
	public class Circle : Shape
	{
		private int _radius;

		public Circle (Color clr, int radius) : base(clr)
		{
			_radius = radius;
		}

		public Circle () : this(Color.Red, 50)
		{
		}

		public int Radius
		{
			get
			{
				return _radius;
			}
			set
			{
				_radius = value;
			}
		}

		public override void Draw ()
		{
			SwinGame.FillCircle (Colour, X, Y, _radius);

			if (IsSelected)
			{
				DrawOutline ();
			}
		}

		public override void DrawOutline()
		{
			SwinGame.DrawCircle (Color.Black, X, Y, _radius + 2);
		}

		public override bool IsAt(Point2D pt)
		{
			return (SwinGame.PointInCircle(pt, X, Y, _radius)); 
		}
	}
}

