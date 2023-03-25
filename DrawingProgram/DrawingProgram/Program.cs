using DrawingProgram.lib;

namespace DrawingProgram
{
    public class Program
    {
        // enumeration for kinds of shapes 
        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line
        }
        public static void Main()
        {
            //initialize a variable with shapekind enum to keep track of which shape is currently equipped
            ShapeKind kindToAdd = ShapeKind.Circle;

            //initialized coordinates for drawing a line, each to hold 2 mouse clicks 
            float startX = 0;
            float startY = 0;
            float endX = 0;
            float endY = 0;

            Drawing drawing = new Drawing();

            Window window = new Window("Shape Drawer", 800, 600);

            //event loop starts here 
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                //change shape kind depending on key pressed
                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }
                if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }
                if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }

                // add new shape
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    //new rectangle 
                    if (kindToAdd == ShapeKind.Rectangle)
                    {
                        // make the new shape, assign coordinates and add it to the drawing list 
                        MyRectangle newRect = new MyRectangle();
                        newRect.X = SplashKit.MouseX();
                        newRect.Y = SplashKit.MouseY();
                        drawing.AddShape(newRect);
                    }
                    //new circle 
                    else if (kindToAdd == ShapeKind.Circle)
                    {
                        MyCircle newCircle = new MyCircle();
                        newCircle.X = SplashKit.MouseX();
                        newCircle.Y = SplashKit.MouseY();
                        drawing.AddShape(newCircle);
                    }
                    //new line 
                    else if (kindToAdd == ShapeKind.Line)
                    {
                        // check here if mouse has been clicked once or twice. on first click assign start coordinates,
                        //on 2nd click assign end values and reset both values so they can be used for the next line 
                        if (startX == 0 && startY == 0)
                        {
                            startX = SplashKit.MouseX();
                            startY = SplashKit.MouseY();
                        }
                        else if (endX == 0 && endY == 0)
                        {
                            endX = SplashKit.MouseX();
                            endY = SplashKit.MouseY();

                            MyLine newLine = new MyLine();
                            newLine.X = startX;
                            newLine.Y = startY;
                            newLine.X2 = endX;
                            newLine.Y2 = endY;
                            drawing.AddShape(newLine);

                            startX = 0;
                            startY = 0;
                            endX = 0;
                            endY = 0;
                        }
                    }
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

                // save drawing
                if (SplashKit.KeyTyped(KeyCode.SKey))
                {
                    drawing.Save("/Users/shahn/Desktop/TestDrawing.txt");
                }

                //load drawing 
                if (SplashKit.KeyTyped(KeyCode.OKey))
                {
                    try
                    {
                        drawing.Load("C:/Users/shahn/Desktop/TestDrawing.txt");
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine($"Error loading file: {e.Message}");
                    }
                }

                drawing.Draw();
                SplashKit.RefreshScreen();

            } while (!window.CloseRequested);
        }
    }
}
