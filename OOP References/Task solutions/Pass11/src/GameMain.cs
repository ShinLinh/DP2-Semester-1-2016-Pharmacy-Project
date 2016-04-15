using System;
using System.Reflection;
using SwinGameSDK;
using Color = System.Drawing.Color;
using System.Collections.Generic;

namespace MyGame
{
    public class GameMain
    {
		private enum ShapeKind
		{
			Rectangle,
			Circle,
			Line
		}

		private static ShapeKind kindToAdd = ShapeKind.Circle;

        public static void Main()
        {
			bool lineSet = false;
			Drawing myDrawing = new Drawing();
			Point2D pt = new Point2D();
			Point2D startPoint = new Point2D ();

            //Start the audio system so sound can be played
            SwinGame.OpenAudio();
            
            //Open the game window
            SwinGame.OpenGraphicsWindow("GameMain", 800, 600);
            SwinGame.ShowSwinGameSplashScreen();
            
            //Run the game loop
            while(false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
				SwinGame.ProcessEvents();
                
				if (SwinGame.KeyTyped (KeyCode.vk_r))
				{
					kindToAdd = ShapeKind.Rectangle;
				}

				if (SwinGame.KeyTyped (KeyCode.vk_c))
				{
					kindToAdd = ShapeKind.Circle;
				}

				if (SwinGame.KeyTyped (KeyCode.vk_l))
				{
					kindToAdd = ShapeKind.Line;
				}

				if (SwinGame.MouseClicked (MouseButton.LeftButton))
				{
					Shape newShape = new Rectangle(); 

					if (kindToAdd == ShapeKind.Rectangle)
					{
						Rectangle newRect = new Rectangle ();
						newRect.X = SwinGame.MouseX ();
						newRect.Y = SwinGame.MouseY ();
						newShape = newRect;
					}
					else if (kindToAdd == ShapeKind.Circle)
					{
						Circle newCircle = new Circle ();
						newCircle.X = SwinGame.MouseX ();
						newCircle.Y = SwinGame.MouseY ();
						newShape = newCircle;
					} else if (kindToAdd == ShapeKind.Line)
					{
						Line newLine = new Line ();

						//newLine.X = SwinGame.MouseX ();
						//newLine.Y = SwinGame.MouseY ();
						//newLine.EndX = newLine.X + 50;
						//newLine.EndY = newLine.Y + 50;

						if (!lineSet)
						{
							startPoint.X = SwinGame.MouseX ();
							startPoint.Y = SwinGame.MouseY ();
							lineSet = true;
						} else
						{
							newLine.X = startPoint.X;
							newLine.Y = startPoint.Y;
							newLine.EndX = SwinGame.MouseX ();
							newLine.EndY = SwinGame.MouseY ();
							lineSet = false;

							newShape = newLine;
						}
					}
					if (kindToAdd != ShapeKind.Line)
					{
						lineSet = false;
						myDrawing.AddShape (newShape);
					}
					else
					{
						if (!lineSet)
						{
							myDrawing.AddShape (newShape);
						}
					}
				}

				if (SwinGame.KeyTyped (KeyCode.vk_SPACE))
				{
					myDrawing.Background = SwinGame.RandomRGBColor (255);
				}

				if (SwinGame.MouseClicked(MouseButton.RightButton)) 
				{
					pt.X = SwinGame.MouseX();
					pt.Y = SwinGame.MouseY();

					myDrawing.SelectShapesAt (pt);
				}

				if (SwinGame.KeyTyped (KeyCode.vk_BACKSPACE) | SwinGame.KeyTyped (KeyCode.vk_DELETE))
				{
					List<Shape> selected= myDrawing.SelectedShapes;
					for (int i = 0; i < selected.Count; i++)
					{
						myDrawing.RemoveShape (selected [i]);
					}
				}
				myDrawing.Draw ();
				//Draw FPS
				SwinGame.DrawFramerate(0,0);
                //Draw onto the screen
                SwinGame.RefreshScreen();
            }
            
            //End the audio
            SwinGame.CloseAudio();
            
            //Close any resources we were using
            SwinGame.ReleaseAllResources();
        }
    }
}