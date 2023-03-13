using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        public static void Main()
        {
            Window window = new Window("Shape Drawer", 800, 600);

            Drawing drawing = new Drawing();
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                // add new shape
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    drawing.AddShape(new Shape(SplashKit.MouseX(), SplashKit.MouseY()));
                }

                // delete a shape 
                if (SplashKit.KeyTyped(KeyCode.BackspaceKey) || SplashKit.KeyTyped(KeyCode.DeleteKey))
                {
                    drawing.DeleteShape();
                }
                // select a shape
                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    drawing.SelectShapesAt(SplashKit.MousePosition());
                }

                // change background color
                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    drawing.Background = Color.Random();
                }
              
                drawing.Draw();
                SplashKit.RefreshScreen();
         
            } while (!window.CloseRequested);
        }
    }
}
