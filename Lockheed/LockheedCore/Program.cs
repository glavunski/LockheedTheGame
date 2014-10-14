using System;
using System.Diagnostics;
using System.Collections.Generic;


namespace LockHeedCore
{
   
    using SFML.Audio;
    using SFML.Window;
    using SFML.Graphics;

    class Program
    {
        const double Ratio = 16.0 / 9.0;
        const int WindowWidth = 800;
        const int WindowHeight = (int)(WindowWidth / Ratio);
        const float MovementModifier = 5f;

        static float X = WindowWidth / 2f;
        static float Y = WindowHeight / 2f;
        static bool keyArrowLeft = false;
        static bool keyArrowUp = false;
        static bool keyArrowDown = false;
        static bool keyArrowRight = false;

        static void Main(string[] args)
        {
            //create renderer window
            var resolution = new VideoMode(WindowWidth, WindowHeight, 32);
            var windowSettings = new ContextSettings(32, 0, 4);
            var window = new RenderWindow(resolution, "Lockheed the Game", Styles.Close, windowSettings);
            window.Closed += new EventHandler(OnClose);
            window.KeyPressed += new EventHandler<KeyEventArgs>(OnKeyPressed);
            window.KeyReleased += new EventHandler<KeyEventArgs>(OnKeyReleased);
            window.MouseButtonPressed += new EventHandler<MouseButtonEventArgs>(OnMouseButtonPressed);
            window.SetActive();


            List<Obstacle> obstacles = new List<Obstacle>()
            {
            new DeadlyObstacle("level/obstacle/hole.png",300,300),
            new ObstructedObstacle("level/obstacle/rock.png",350,300),
            new ObstructedObstacle("level/obstacle/rock.png",400,300),
            new ChestObstacle("level/obstacle/chest.png",200,150)
            };

            List<Door> doors = new List<Door>()
            {
            new Door(DoorPosition.Top,"level2","level/door/doorTop.png")
            };

            List<Level> levels = new List<Level>()
            {
                new Level("level1","level/baseLevel.png",obstacles,doors)
            };

            Character hero = new Character();
            hero.Mana = 100;
            hero.X = 300;
            hero.Y = 300;


            //BoundingBox
            FloatRect rect = new FloatRect(X,Y,30,30);
           
         

            var player = new Sprite(new Texture("character.png"));





            //game loop
            while (window.IsOpen())
            {
                //input
                window.DispatchEvents(); //process input and events
                //clear screen
                window.Clear(); //clear the screen and buffer
                Level.DrawLevel(levels[0], window);

                ChangePosition(rect);



                player.Position = new Vector2f(X, Y);
              
                rect.Top = Y + 55;
                rect.Left = X + 5;
                //draw             
                
                window.Draw(player); //here we will pass our renderer class that will be IDrawable


                //render
                window.Display(); //call this to draw everything in the buffer
            }
        }

        //this is the event when you press the X of the window
        static void OnClose(object sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }

        static void ChangePosition(FloatRect rect)
        {

            if (keyArrowDown)
            {
                if (rect.Top <= WindowHeight - 80)
                {
                    Y += MovementModifier;
                }
            }
            if (keyArrowUp)
            {
                if (rect.Top >= 60)
                {
                    Y -= MovementModifier;
                }
            }
            if (keyArrowLeft)
            {
                if (rect.Left >= 60)
                {
                    X -= MovementModifier;
                }

            }
            if (keyArrowRight)
            {
                if (rect.Left <= WindowWidth - 85)
                {
                    X += MovementModifier;
                }
            }
        }

        static void OnKeyPressed(object sender, KeyEventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            if (e.Code == Keyboard.Key.Left)
            {
                keyArrowLeft = true;
            }
            else if (e.Code == Keyboard.Key.Right)
            {
                keyArrowRight = true;
            }
            if (e.Code == Keyboard.Key.Up)
            {
                keyArrowUp = true;
            }
            else if (e.Code == Keyboard.Key.Down)
            {
                keyArrowDown = true;
            }
           
        }
        static void OnKeyReleased(object sender, KeyEventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            if (e.Code == Keyboard.Key.Left)
            {
                keyArrowLeft = false;
            }
            else if (e.Code == Keyboard.Key.Right)
            {
                keyArrowRight = false;
            }
            if (e.Code == Keyboard.Key.Up)
            {
                keyArrowUp = false;
            }
            else if (e.Code == Keyboard.Key.Down)
            {
                keyArrowDown = false;
            }

        }
        static void OnMouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            if (e.Button == Mouse.Button.Right)
            { 
            
            }

        }



    }
}

