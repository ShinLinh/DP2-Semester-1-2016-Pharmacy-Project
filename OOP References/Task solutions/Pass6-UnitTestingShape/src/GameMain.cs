using System;
using System.Reflection;
using SwinGameSDK;
using Color = System.Drawing.Color;
using System.Collections.Generic;

namespace MyGame
{
    public class GameMain
    {
        public static void Main()
        {
			Drawing myDrawing = new Drawing();
			Point2D pt = new Point2D();

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
                
				if (SwinGame.MouseClicked (MouseButton.LeftButton))
				{
					pt.X = SwinGame.MouseX();
					pt.Y = SwinGame.MouseY();
					Shape newShape = new Shape (Color.Green, pt.X, pt.Y, 100,100);

					myDrawing.AddShape (newShape);
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