using System;
using System.Reflection;
using SwinGameSDK;
using Color = System.Drawing.Color;

namespace MyGame
{
    public class GameMain
    {
        public static void Main()
        {
			Shape myShape = new Shape();
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

                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.White);
                SwinGame.DrawFramerate(0,0);
				myShape.Draw ();
				if (SwinGame.MouseClicked (MouseButton.LeftButton))
				{
					pt.X = SwinGame.MouseX ();
					pt.Y = SwinGame.MouseY ();

					if (!myShape.IsAt (pt))
					{
						myShape.X = pt.X;
						myShape.Y = pt.Y;
					}
				}


				if (SwinGame.KeyTyped (KeyCode.vk_SPACE))
				{
					pt.X = SwinGame.MouseX ();
					pt.Y = SwinGame.MouseY ();
					if (myShape.IsAt (pt))
					{
						myShape.Colour = SwinGame.RandomRGBColor (255);
					}
				}

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