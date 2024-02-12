using System;
using SFML.System;
using SFML.Window;
using SFML.Graphics;
using System.ComponentModel;
using System.Drawing;
using System.Diagnostics;
using Color = SFML.Graphics.Color;
using SFML.Audio;
using System.Security.AccessControl;
using System.Reflection.Metadata.Ecma335;
using System.Globalization;
using System.Linq.Expressions;
using System.Collections;
using System.Numerics;
using System.Dynamic;

/* class Flower : CircleShape
{
    // Habe es leider nicht geschafft die Flower Class zum erstellen zu nutzen..
    public Vector2f Position { get; set; }
    public Color Color { get; private set; }
    public float Radius { get; private set; }
    public int Filling { get; set; } // Level of Filings

    public Flower(Vector2f position, int filling)
    {
        Position = position;
        FillColor = Color.Yellow;
        Radius = Buzzdown.FlowerRadius;
        Filling = filling;

    }
} */
class Buzzdown
{
    // SFML Window 16:9
    static uint Height = 900;
    static uint Width = Height / 16 * 9;
    static Color background = Color.Black;
    static RenderWindow sfmlWindow = new RenderWindow(new VideoMode(Width, Height), "Buzzdown");
    public static int Windowsize = (int)sfmlWindow.Size.X;

    // Game structure Elements
    enum Screen
    {
        Intro,
        Menu,
        Pause,
        InGame,
        LoadLevel,
        GameOver,
        End,
        Restart
    }
    static Screen CurrentScreen = Screen.Intro;
    enum Level
    {
        Level0,
        Level1,
        Level2,
        Level3,
        Level4,
        Level5,
        Level6,
        Level7,
        Level8,
        Level9,
        Level10
    }


    static Level CurrentLevel = Level.Level0;
    static Level lastLevel = (Level)Enum.GetValues(typeof(Level)).Length - 1;
    static FloatRect GameWindowBounds;
    static float PlayerWindowBoundsLeft;
    static float PlayerWindowBoundsRight;
    static float GameWindowBoundsRight;
    static Clock gameClock = new Clock();
/*     static float deltaTime; */
    static Vector2f posCorrection;
    static Clock clickClock = new Clock();
    static Time clickDelay = Time.FromSeconds(0.7f);



    // Variables
    static Random r = new Random();
    static float Lives = 5;
    static float PlayerMoveSpeed = 5;
    static int Timer = 0;
    static Vector2f ballVelocity = new Vector2f(5, -5);
    public static int FlowerRadius;
    static int points = 0;
    static uint sizemultiLogo = 5;
    static uint sizemultiOver = 10;
    static int deleteMe = new int();


    // Bools
    static bool playerStartedGame = false;

    static bool musicIsPlaying = false;
    static bool playerMutedMusic = false;
    static bool check = false;
    static bool playerCollision = false;
    static bool flowerCollision = false;



    // Objects
    static RectangleShape buttonPlay = new RectangleShape();
    static RectangleShape buttonresume = new RectangleShape();
    static RectangleShape buttonrestart = new RectangleShape();
    static RectangleShape buttonend = new RectangleShape();

    public static RectangleShape GameWindow = new RectangleShape();
    static RectangleShape Player = new RectangleShape();
    static CircleShape ball = new CircleShape();
    static CircleShape Testflower = new CircleShape();



    // Lists
    static List<CircleShape> Flowerlist;
    static List<int> Pos;
    static List<int> fill;



    // Music
    static Music introMusic = new Music("music/HoneyBee.wav");
    static Music menuMusic = new Music("music/Cloud-Dancer.wav");
    static Music lostMusic = new Music("music/SCP-x6x.wav");
    static Music wonMusic = new Music("music/Happy-Bee.wav");
    static Music extraMusic = new Music("music/Four-Beers-Polka.wav");


    // Colors:
    static Color orange = new Color(255, 165, 80);
    static Color yellow = new Color(255, 190, 80);
    static Color brown = new Color(120, 58, 41);
    static Color black = new Color(30, 0, 0);
    static Color white = new Color(255, 255, 255);
    static Color lightYellow = new Color(250, 250, 200);
    static Color lightLilac = new Color(230, 230, 250);
    static Color lightRed = new Color(250, 200, 210);
    static Color lightBlue = new Color(180, 180, 250);
    //static Color  = new Color();


    // Fonts & Texts
    static Font AlloyInk = new Font("fonts/AlloyInk-nRLyO.ttf");
    static Font Sixtyfour = new Font("fonts/Sixtyfour-Regular.ttf");

    static Text gameName = new Text();
    static Text playText = new Text();
    static Text startGame = new Text();
    static Text introduction = new Text();
    static Text gameNameMini = new Text();
    static Text score = new Text();
    static Text pause = new Text();
    static Text resume = new Text();
    static Text restart = new Text();
    static Text end = new Text();
    static Text inGameInstructions = new Text();
    static Text won = new Text();
    static Text lost = new Text();



    // Textures
    /*     static Texture intro = new Texture("textures/.png");

        static Texture menu = new Texture("textures/.png");*/

    static Texture bee = new Texture("textures/bee.png");

    static Texture flower = new Texture("textures/flower.png");

    static Texture player = new Texture("textures/player.png");




    static void Main()
    {
        sfmlWindow.SetFramerateLimit(60);

        InitAllObjects();

        while (true)
        {
            sfmlWindow.DispatchEvents();
            sfmlWindow.Clear(background);


            PlayMusic();

            GameLoop();

            DeveloperFunctions();

            sfmlWindow.Display();

        }
    }

    static void DeveloperFunctions()
    {
        if (CurrentScreen == Screen.InGame && Keyboard.IsKeyPressed(Keyboard.Key.F12) && clickClock.ElapsedTime >= clickDelay)
        {
            for (int i = 0; i <= Flowerlist.Count - 1; i++)
            {
                Flowerlist.RemoveAt(i);
                i--;
            }
            clickClock.Restart();
        }
    }

    static void InitAllObjects()
    {
        Debug.Write("Debugging: Initiate all Objects");
        //PrintCalc();
        introMusic.Volume = 20;
        introMusic.Loop = true;
        menuMusic.Volume = 20;
        menuMusic.Loop = true;
        lostMusic.Loop = true;
        lostMusic.Volume = 20;
        wonMusic.Loop = true;
        wonMusic.Volume = 20;




        playText = new Text
        {
            DisplayedString = "Play",
            Font = AlloyInk,
            CharacterSize = Width / 10,
            FillColor = yellow,
        };
        FloatRect textBounds = playText.GetLocalBounds();
        playText.Origin = new Vector2f(textBounds.Width / 2, textBounds.Height / 2);
        playText.Position = new Vector2f(Width / 2, Height / 2);

        buttonPlay = new RectangleShape
        {
            Size = new Vector2f(textBounds.Width * 1.4f, textBounds.Height * 1.4f),

            FillColor = brown,
        };
        buttonPlay.Origin = new Vector2f(buttonPlay.Size.X / 2, buttonPlay.Size.Y / 2);
        buttonPlay.Position = playText.Position;




        restart = new Text
        {
            DisplayedString = "Restart",
            Font = AlloyInk,
            CharacterSize = Width / 10,
            FillColor = yellow,
        };
        textBounds = restart.GetLocalBounds();
        restart.Origin = new Vector2f(textBounds.Width / 2, textBounds.Height / 2);
        restart.Position = new Vector2f(Width / 2, Height / 2);


        buttonrestart = new RectangleShape
        {
            Size = new Vector2f(textBounds.Width * 1.4f, textBounds.Height * 1.4f),

            FillColor = brown,
        };
        buttonrestart.Origin = new Vector2f(buttonrestart.Size.X / 2, buttonrestart.Size.Y / 2);
        buttonrestart.Position = restart.Position;


        end = new Text
        {
            DisplayedString = "Exit",
            Font = AlloyInk,
            CharacterSize = Width / 10,
            FillColor = yellow,
        };
        textBounds = end.GetLocalBounds();
        end.Origin = new Vector2f(textBounds.Width / 2, textBounds.Height / 2);
        end.Position = new Vector2f(Width / 2, Height / 2 + 2 * textBounds.Height);


        buttonend = new RectangleShape
        {
            Size = new Vector2f(textBounds.Width * 1.4f, textBounds.Height * 1.4f),

            FillColor = brown,
        };
        buttonend.Origin = new Vector2f(buttonend.Size.X / 2, buttonend.Size.Y / 2);
        buttonend.Position = end.Position;




        resume = new Text
        {
            DisplayedString = "Resume",
            Font = AlloyInk,
            CharacterSize = Width / 10,
            FillColor = yellow,
        };
        textBounds = resume.GetLocalBounds();
        resume.Origin = new Vector2f(textBounds.Width / 2, textBounds.Height / 2);
        resume.Position = new Vector2f(Width / 2, Height / 2);

        buttonresume = new RectangleShape
        {
            Size = new Vector2f(textBounds.Width * 1.4f, textBounds.Height * 1.4f),

            FillColor = brown,
        };
        buttonresume.Origin = new Vector2f(buttonresume.Size.X / 2, buttonresume.Size.Y / 2);
        buttonresume.Position = resume.Position;


        inGameInstructions = new Text
        {
            DisplayedString = "Press P for Pause",
            Font = AlloyInk,
            CharacterSize = Width / 10,
            FillColor = yellow,
        };
        textBounds = inGameInstructions.GetLocalBounds();
        inGameInstructions.Origin = new Vector2f(textBounds.Width / 2, textBounds.Height / 2);
        inGameInstructions.Position = new Vector2f(sfmlWindow.Size.X / 2, sfmlWindow.Size.Y - 3 * textBounds.Height);

        gameName = new Text
        {
            DisplayedString = "BUZZ\nDOWN",
            Font = AlloyInk,
            CharacterSize = Width / 5,
            FillColor = orange,
        };
        FloatRect textBounds2 = gameName.GetLocalBounds();
        gameName.Origin = new Vector2f(textBounds2.Width / 2, textBounds2.Height / 2);
        gameName.Position = new Vector2f(Width / 2, textBounds2.Height);

        introduction = new Text
        {
            DisplayedString = "a Breakout inspired Game\n      by June Schwenk",
            Font = Sixtyfour,
            CharacterSize = Width / 40,
            FillColor = orange,
        };
        textBounds2 = introduction.GetLocalBounds();
        introduction.Origin = new Vector2f(textBounds2.Width / 2, textBounds2.Height / 2);
        introduction.Position = new Vector2f(sfmlWindow.Size.X / 2, sfmlWindow.Size.Y - 3 * textBounds2.Height);

        won = new Text
        {
            DisplayedString = "You won!",
            Font = Sixtyfour,
            CharacterSize = Width / sizemultiOver,
            FillColor = orange,
        };
        textBounds2 = won.GetLocalBounds();
        won.Origin = new Vector2f(textBounds2.Width / 2, textBounds2.Height / 2);
        won.Position = new Vector2f(sfmlWindow.Size.X / 2, sfmlWindow.Size.Y - 5 * textBounds2.Height);


        lost = new Text
        {
            DisplayedString = "You lost!",
            Font = Sixtyfour,
            CharacterSize = Width / sizemultiOver,
            FillColor = orange,
        };
        textBounds2 = lost.GetLocalBounds();
        lost.Origin = new Vector2f(textBounds2.Width / 2, textBounds2.Height / 2);
        lost.Position = new Vector2f(sfmlWindow.Size.X / 2, sfmlWindow.Size.Y - 5 * textBounds2.Height);


        pause = new Text
        {
            DisplayedString = "- Game is paused -",
            Font = Sixtyfour,
            CharacterSize = Width / 40,
            FillColor = orange,
        };
        textBounds2 = pause.GetLocalBounds();
        pause.Origin = new Vector2f(textBounds2.Width / 2, textBounds2.Height / 2);
        pause.Position = new Vector2f(sfmlWindow.Size.X / 2, sfmlWindow.Size.Y - 3 * textBounds2.Height);



        gameNameMini = new Text
        {
            DisplayedString = "BUZZDOWN",
            Font = AlloyInk,
            CharacterSize = Width / 10,
            FillColor = orange,
        };
        textBounds2 = gameName.GetLocalBounds();
        gameName.Origin = new Vector2f(textBounds2.Width / 2, textBounds2.Height / 2);
        gameName.Position = new Vector2f(Width / 2, textBounds2.Height);


        GameWindow = new RectangleShape
        {
            Size = new Vector2f(sfmlWindow.Size.X / 5 * 4, sfmlWindow.Size.Y / 10 * 6),
            FillColor = lightBlue,

        };
        // Console.WriteLine(sfmlWindow.Size);
        GameWindow.Origin = new Vector2f(GameWindow.Size.X / 2, GameWindow.Size.Y / 2);
        GameWindow.Position = new Vector2f(sfmlWindow.Size.X / 2, sfmlWindow.Size.Y / 10 * 4);

        Player = new RectangleShape
        {
            Size = new Vector2f(sfmlWindow.Size.X / 7, sfmlWindow.Size.X / 40),
            FillColor = yellow,
        };
        Player.Origin = new Vector2f(Player.Size.X / 2, Player.Size.Y / 2);
        Player.Position = new Vector2f(sfmlWindow.Size.X / 2, sfmlWindow.Size.Y / 10 * 7 - Player.Size.Y);



        // Precalculating Bounds
        GameWindowBounds = GameWindow.GetGlobalBounds();
        GameWindowBoundsRight = GameWindowBounds.Left + GameWindowBounds.Width;
        PlayerWindowBoundsLeft = GameWindowBounds.Left + (Player.Size.X / 2);
        PlayerWindowBoundsRight = GameWindowBoundsRight - (Player.Size.X / 2);
        Console.WriteLine(GameWindowBounds);

        Testflower = new CircleShape
        {
            Radius = sfmlWindow.Size.X / 50,
            FillColor = lightYellow,
            Texture = flower,
        };

        score = new Text
        {
            Font = Sixtyfour,
            CharacterSize = Width / 40,
            FillColor = orange,
            DisplayedString = "Score: " + points + "     " + CurrentLevel + "    Lives:" + Lives
        };
        textBounds2 = score.GetLocalBounds();
        score.Origin = new Vector2f(textBounds2.Width / 2, textBounds2.Height / 2);
        score.Position = new Vector2f(sfmlWindow.Size.X / 2, GameWindowBounds.Top - 2 * textBounds2.Height);

        ball = new CircleShape
        {
            Radius = sfmlWindow.Size.X / 50,
            FillColor = lightYellow,
            Texture = bee,
        };
        ball.Origin = new Vector2f(ball.Radius, ball.Radius);
        ball.Position = new Vector2f(Player.Position.X, Player.Position.Y - Player.Size.Y / 2 - ball.Radius);

        startGame = new Text
        {
            DisplayedString = "-Press space to start-",
            Font = Sixtyfour,
            CharacterSize = Width / 30,
            FillColor = white,
        };
        FloatRect textBounds3 = startGame.GetLocalBounds();
        startGame.Origin = new Vector2f(textBounds3.Width / 2, textBounds3.Height / 2);
        startGame.Position = new Vector2f(Width / 2, GameWindowBounds.Height);

        Flowerlist = new List<CircleShape>();
        FlowerRadius = Windowsize / 40;
        posCorrection = new Vector2f(GameWindowBounds.Left, GameWindowBounds.Top);
    }



    static void GameLoop()
    {
        switch (CurrentScreen)
        {
            case Screen.Intro:

                DisplayIntro();
                if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && clickClock.ElapsedTime >= clickDelay)
                {
                    StopMusic();
                    clickClock.Restart();
                    CurrentScreen = Screen.Menu;
                }

                break;

            case Screen.Menu:

                DisplayMenu();
                if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && clickClock.ElapsedTime >= clickDelay)
                {
                    StopMusic();
                    clickClock.Restart();
                    CurrentScreen = Screen.LoadLevel;
                }

                break;
            case Screen.LoadLevel:

                LevelControl();
                DisplayLoadLevel();
                CurrentScreen = Screen.InGame;
                break;

            case Screen.InGame:

                DisplayInGame();
                if (Keyboard.IsKeyPressed(Keyboard.Key.B))
                {
                    StopMusic();
                    CurrentScreen = Screen.GameOver;
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.P) && clickClock.ElapsedTime >= clickDelay)
                {
                    StopMusic();
                    clickClock.Restart();
                    CurrentScreen = Screen.Pause;
                }

                break;


            case Screen.Pause:

                DisplayPause();
                if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
                {
                    StopMusic();
                    CurrentScreen = Screen.InGame;
                }
                break;

            case Screen.GameOver:

                DisplayGameOver();

                // End Game
                if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
                {
                    sfmlWindow.Close();
                }
                break;
            case Screen.Restart:
                Displayrestart();
                break;
            case Screen.End:

                sfmlWindow.Close();

                break;
        }
    }
    static void Displayrestart()
    {
        ResetObjects();
        ResetScore();
        CurrentLevel = 0;
        if (points == 0 && Lives == 5 && CurrentLevel == Level.Level0)
        { CurrentScreen = Screen.Menu; }

    }

    static void ResetScore()
    {
        Lives = 5;
        points = 0;

        Flowerlist.Clear();
        StopMusic();

    }


    static void PlayMusic()
    {
        switch (CurrentScreen)
        {
            case Screen.Intro:
                if (!musicIsPlaying)
                {
                    introMusic.Play();
                    musicIsPlaying = true;
                }
                break;
            case Screen.Menu:
                if (!musicIsPlaying)
                {
                    menuMusic.Play();
                    musicIsPlaying = true;
                }
                break;
            case Screen.InGame:
                if (!musicIsPlaying)
                {
                    introMusic.Play();
                    musicIsPlaying = true;
                }
                break;
            case Screen.Pause:
                if (!musicIsPlaying)
                {
                    menuMusic.Play();
                    musicIsPlaying = true;
                }
                break;

            case Screen.GameOver when Lives == 0:
                if (!musicIsPlaying)
                {
                    lostMusic.Play();
                    musicIsPlaying = true;
                }
                break;

            case Screen.GameOver when Lives > 0:
                if (!musicIsPlaying)
                {
                    wonMusic.Play();
                    musicIsPlaying = true;
                }
                break;

        }
    }


    static void DisplayIntro()
    {
        // Music by Kevin MacLeod (incompetech.com)
        // Licensed under Creative Commons: By Attribution 3.0 License
        // http://creativecommons.org/licenses/by/3.0/

        AnimationBump(gameName, sizemultiLogo);
        // Draw the text with the updated font size
        sfmlWindow.Draw(gameName);
        sfmlWindow.Draw(introduction);
        sfmlWindow.Draw(startGame);

    }

    static void DisplayMenu()
    {
        // Console.WriteLine("Debugging: Displaying Menu");

        AnimationBump(gameName, sizemultiLogo);
        sfmlWindow.Draw(gameName);
        sfmlWindow.Draw(buttonPlay);
        sfmlWindow.Draw(playText);
        ButtonClick(buttonPlay, Screen.LoadLevel);
    }

    static void DisplayPause()
    {
        //Console.WriteLine("Debugging: Pause Game");
        sfmlWindow.Draw(pause);
        sfmlWindow.Draw(buttonresume);
        sfmlWindow.Draw(resume);
        sfmlWindow.Draw(gameName);
        AnimationBump(gameName, sizemultiLogo);
        ButtonClick(buttonresume, Screen.InGame);

    }




    static void DisplayInGame()
    {
        // Console.WriteLine("Debugging: Start Game");
        sfmlWindow.Draw(GameWindow);
        sfmlWindow.Draw(Player);
        sfmlWindow.Draw(ball);
        sfmlWindow.Draw(score);
        DrawFlowers();


        PlayerReady();
        Moveball();
        MoveControl();
        MovePlayer();
        WallCollision();
        CheckCollisions();
        ResolveCollisions();

        CheckIfLost();
        CheckForLevelSolved();
        DeleteEmpty();


    }
    static void DrawFlowers()
    {
        for (int i = 0; i <= Flowerlist.Count - 1; i++)
        {
            sfmlWindow.Draw(Flowerlist[i]);
            //Console.WriteLine(Flowerlist[i].Position);
        }
    }
    static void DisplayLoadLevel()
    {
        LevelConditions();

    }




    static void LevelConditions()
    {
        // Check Level-Instructions
        switch (CurrentLevel)
        {
            case Level.Level0:
                break;

            case Level.Level1:
                Pos = new List<int> { 1, 2, 3, 6, 7, 8, 11, 12, 13, 16, 17, 18, 19, 20, 21, 24, 25, 26, 29, 30, 31, 34, 35, 36, 37, 38, 39, 42, 43, 44, 47, 48, 49, 52, 53, 54, 55, 56, 57, 60, 61, 62, 65, 66, 67, 70, 71, 72, 73, 74, 75, 78, 79, 80, 83, 84, 85, 88, 89, 90, 91, 92, 93, 96, 97, 98, 101, 102, 103, 106, 107, 108 };
                fill = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

                InitFlowers();

                break;

            case Level.Level2:
                Pos = new List<int> { 1, 2, 3, 6, 7, 8, 11, 12, 13, 16, 17, 18, 19, 20, 21, 24, 25, 26, 29, 30, 31, 34, 35, 36, 40, 41, 45, 46, 50, 51, 58, 59, 63, 64, 68, 69, 73, 74, 75, 78, 79, 80, 83, 84, 85, 88, 89, 90, 91, 92, 93, 96, 97, 98, 101, 102, 103, 106, 107, 108 };
                fill = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

                InitFlowers();

                Console.WriteLine(Pos.Count);
                Console.WriteLine(fill.Count);
                break;

            case Level.Level3:
                Pos = new List<int> { 20, 21, 22, 24, 25, 26, 29, 30, 31, 33, 34, 35, 38, 39, 40, 42, 43, 44, 47, 48, 49, 51, 52, 53, 57, 58, 59, 60, 67, 68, 69, 70, 75, 76, 77, 78, 85, 86, 87, 88 };
                fill = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };

                InitFlowers();

                Console.WriteLine(Pos.Count);
                Console.WriteLine(fill.Count);


                break;
            case Level.Level4:
                Pos = new List<int> { 19, 20, 21, 23, 24, 25, 26, 27, 28, 30, 31, 32, 34, 35, 36, 37, 38, 39, 41, 42, 43, 45, 46, 48, 49, 50, 52, 53, 54, 73, 74, 75, 77, 78, 79, 81, 82, 84, 85, 86, 88, 89, 90, 91, 92, 93, 95, 96, 97, 99, 100, 102, 103, 104, 106, 107, 108 };
                fill = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

                InitFlowers();

                Console.WriteLine(Pos.Count);
                Console.WriteLine(fill.Count);


                break;

            case Level.Level5:
                Pos = new List<int> { 1, 2, 3, 4, 5, 6, 8, 9, 10, 14, 15, 16, 17, 18, 19, 22, 23, 24, 26, 27, 28, 30, 31, 32, 35, 36, 38, 39, 40, 42, 43, 45, 46, 48, 49, 53, 52, 56, 61, 67, 68, 78, 79, 80, 82, 83, 85, 86, 90, 92, 93, 101, 102, 103 };
                fill = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                InitFlowers();

                Console.WriteLine(Pos.Count);
                Console.WriteLine(fill.Count);
                break;

            case Level.Level6:
                Pos = new List<int> { 1, 2, 3, 4, 8, 9, 10, 11, 15, 16, 17, 18, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 76, 77, 78, 79, 80, 83, 84, 85, 86, 87 };
                fill = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
                InitFlowers();

                Console.WriteLine(Pos.Count);
                Console.WriteLine(fill.Count);
                break;

            case Level.Level7:
                break;

            case Level.Level8:
                break;

            case Level.Level9:
                break;

            case Level.Level10:
                break;

        }

    }

    static void LevelControl()
    {

        CurrentLevel++;
        Console.WriteLine("Current Level: " + CurrentLevel);
    }
    static void InitFlowers()
    {
        for (int i = 0; i < Pos.Count; i++)
        {
            Flowerlist.Add(new CircleShape(Testflower));
            Flowerlist[i].Position = VectorList.PositionList[Pos[i] - 1] + posCorrection;
            Flowerlist[i].FillColor = lightLilac;

        }
    }



    static void DisplayGameOver()
    {

        //Console.WriteLine("Debugging: Display Game Over");
        sfmlWindow.Draw(buttonrestart);
        sfmlWindow.Draw(restart);
        sfmlWindow.Draw(buttonend);
        sfmlWindow.Draw(end);
        ButtonClick(buttonrestart, Screen.Restart);

        ButtonClick(buttonend, Screen.End);
        AnimationBump(gameName, sizemultiLogo);
        sfmlWindow.Draw(gameName);


        if (Lives > 0)
        {
            AnimationBump(won, sizemultiOver);
            sfmlWindow.Draw(won);
        }
        else
        {
            AnimationBump(lost, sizemultiOver);
            sfmlWindow.Draw(lost);
        }

    }






    static void StopMusic()
    {
        // Stop all music
        introMusic.Stop();
        menuMusic.Stop();
        lostMusic.Stop();
        wonMusic.Stop();
        // Restart the music playing flag
        musicIsPlaying = false;
    }


    static void MovePlayer()
    {
        if (Keyboard.IsKeyPressed(Keyboard.Key.A) || Keyboard.IsKeyPressed(Keyboard.Key.Left))
        {
            Player.Position += new Vector2f(-PlayerMoveSpeed, 0);
        }

        if (Keyboard.IsKeyPressed(Keyboard.Key.D) || Keyboard.IsKeyPressed(Keyboard.Key.Right))
        {
            Player.Position += new Vector2f(+PlayerMoveSpeed, 0);
        }
    }

    // Stop Player at Walls


    static void MoveControl()
    {
        // check if goes to left
        if (Player.Position.X <= PlayerWindowBoundsLeft)
        {
            Player.Position = new Vector2f(PlayerWindowBoundsLeft, Player.Position.Y);

        }
        // check if goes to right
        if (Player.Position.X >= PlayerWindowBoundsRight)
        {
            Player.Position = new Vector2f(PlayerWindowBoundsRight, Player.Position.Y);

        }

    }

    // Collision Control
    static void CheckCollisions()
    {
        CheckPlayerCollision();
        CheckFlowerCollision();
    }

    static void ResolveCollisions()
    {
        if (playerCollision)
        {
            HandlePlayerCollision();
        }
        if (flowerCollision)
        {
            HandleFlowerCollision(deleteMe);
        }
    }
    static void CheckPlayerCollision()
    {
        if (playerStartedGame && Player.GetGlobalBounds().Intersects(ball.GetGlobalBounds()))
        {
            playerCollision = true;
        }
    }

    static void HandlePlayerCollision()
    {
        double speedX = ballVelocity.X;
        double speedY = ballVelocity.Y;

        // Calculate Ballspeed
        double speedXY = Math.Sqrt(speedX * speedX + speedY * speedY);

        // Calculate Distance
        double posX = (ball.Position.X - Player.Position.X) / (Player.Size.X / 2);

        // Define influence
        double influenceX = 0.75;

        // Adjust X speed limited by influence factor
        speedX = speedXY * posX * influenceX;
        ballVelocity.X = (float)speedX;

        // Calculate Y speed based on X speed
        speedY = Math.Sqrt(speedXY * speedXY - speedX * speedX) *
                 (speedY > 0 ? -1 : 1);
        ballVelocity.Y = (float)speedY * 1.01f;


        /*Hat nicht funktioniert
            deltaTime = gameClock.Restart().AsSeconds();
            if (deltaTime > 0.001f)
            {
                float timeToSimulate = deltaTime;

                while(timeToSimulate >= 0)
                {
                    timeToSimulate -= 0.001f;
                }*/
        playerCollision = false;
    }

    static void CheckFlowerCollision()
    {
        for (int i = Flowerlist.Count - 1; i >= 0; i--)
        {
            FloatRect rectFlower = Flowerlist[i].GetGlobalBounds();
            FloatRect rectball = ball.GetGlobalBounds();

            if (rectFlower.Intersects(rectball))
            {
                fill[i] -= 1;
                points += 10;
                UpdateScore();
                deleteMe = i;
                flowerCollision = true;
                break;

            }
        }
    }

    static void HandleFlowerCollision(int number)
    {
        // Hit was from below the flower
        if (ball.Position.Y <= Flowerlist[number].Position.Y - Flowerlist[number].Radius)
        {
            ballVelocity.Y = -Math.Abs(ballVelocity.Y);
        }
        // Hit was from above the flower
        if (ball.Position.Y >= Flowerlist[number].Position.Y + Flowerlist[number].Radius)
        {
            ballVelocity.Y = Math.Abs(ballVelocity.Y);
        }
        // Hit was on the left side of the flower
        if (ball.Position.X < Flowerlist[number].Position.X - Flowerlist[number].Radius)
        {
            ballVelocity.X = -Math.Abs(ballVelocity.X);
        }
        // Hit was on the right side of the flower
        if (ball.Position.X > Flowerlist[number].Position.X + Flowerlist[number].Radius)
        {
            ballVelocity.X = Math.Abs(ballVelocity.X);
        }
        flowerCollision = false;
    }
    static void DeleteEmpty()
    {
        for (int i = Pos.Count - 1; i >= 0; i--)
        {
            if (fill[i] == 0)
            {
                Flowerlist.RemoveAt(i);
                fill.RemoveAt(i);
                Pos.RemoveAt(i);

            }
        }
    }

    static void WallCollision()
    {
        // Bounce right wall
        if (ball.Position.X >= GameWindowBoundsRight - ball.Radius)
        {
            ballVelocity.X = -Math.Abs(ballVelocity.X);

        }
        // Bounce left wall
        if (ball.Position.X <= GameWindowBounds.Left + ball.Radius)
        {
            ballVelocity.X = Math.Abs(ballVelocity.X);

        }

        // Bounce up wall
        if (ball.Position.Y <= GameWindowBounds.Top + ball.Radius)
        {
            ballVelocity.Y *= -1;

        }
    }


    static void CheckIfLost()
    {
        // Loose when touching down wall 
        if (ball.Position.Y > GameWindowBounds.Top + GameWindow.Size.Y)
        {
            ballVelocity.Y *= -1;
            PointLost();
        }
    }

    static void PointLost()
    {
        // Loose a live and restart positions
        --Lives;
        UpdateScore();
        Console.WriteLine(Lives);

        if (Lives < 0)
        {
            Console.WriteLine("GameOver!");
            StopMusic();
            CurrentScreen = Screen.GameOver;
        }

        else
        {
            ResetObjects();
        }
    }
    static void ResetObjects()
    {
        playerStartedGame = false;
        ballVelocity = new Vector2f(5, -5);
        ball.Position = new Vector2f(Player.Position.X, Player.Position.Y - Player.Size.Y / 2 - ball.Radius);
        Player.Position = new Vector2f(sfmlWindow.Size.X / 2, sfmlWindow.Size.Y / 10 * 7 - Player.Size.Y);
        PlayerReady();
    }


    static void CheckForLevelSolved()
    {
        if (Flowerlist.Count == 0)
        {

            if (CurrentLevel == lastLevel)
            {
                StopMusic();
                PlayerWon();
            }

            else
            {
                CurrentScreen = Screen.LoadLevel;
                ResetObjects();
            }
        }
    }

    static void PlayerWon()
    {
        CurrentScreen = Screen.GameOver;
    }

    static void ButtonClick(RectangleShape Button, Screen screen)
    {
        // Delay for Clicking so no Screen gets overjumped
        if (clickClock.ElapsedTime >= clickDelay)
        {
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                Vector2i mousePosition = Mouse.GetPosition(sfmlWindow);
                FloatRect buttonBounds = Button.GetGlobalBounds();
                if (buttonBounds.Contains(mousePosition.X, mousePosition.Y))
                {
                    CurrentScreen = screen;
                    clickClock.Restart();
                }
            }
        }
    }

    static void AnimationBump(Text text, uint sizemulti)
    {
        // Animate Text
        if (Timer <= 0 && text.CharacterSize > Width / sizemulti)
        {
            text.CharacterSize -= 1; // Decrease font size
            Timer = 7; // Restart the timer
        }

        else if (Timer <= 0 && text.CharacterSize <= Width / sizemulti)
        {
            text.CharacterSize += 1; // Increase font size
            Timer = 7; // Restart the timer
        }

        // Decrement the timer
        if (Timer > 0)
        {
            Timer -= 1;
        }
    }


    static void PlayerReady()
    {
        if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
        {
            playerStartedGame = true;
        }
        if (!playerStartedGame)
        {
            // Send Message how to start Game
            sfmlWindow.Draw(startGame);
        }
    }

    static void Moveball()
    {
        if (playerStartedGame)
        {
            ball.Position += ballVelocity;
        }
        else
        {
            ball.Position = new Vector2f(Player.Position.X, Player.Position.Y - Player.Size.Y / 2 - ball.Radius);
        }
    }


    static void UpdateScore()
    {
        score.DisplayedString = "Score: " + points + "     " + CurrentLevel + "    Lives:" + Lives;
    }

    static bool done = false;
    static void PrintCalc()
    {
        double xcoord = 0.05;
        double ycoord = 0.05;

        while (!done)
        {
            for (int i = 1; i <= 6; i++)
            {
                for (int j = 1; j <= 18; j++)
                {
                    string x = (xcoord * j).ToString(CultureInfo.InvariantCulture);
                    string y = (ycoord * i).ToString(CultureInfo.InvariantCulture);
                    Console.WriteLine("PositionList.Add(new Vector2f(Buzzdown.GameWindow.Size.X * " + x + "f, Buzzdown.GameWindow.Size.Y*0.10f + Buzzdown.GameWindow.Size.X *" + y + ("f));"));
                }

            }
            done = true;
        }
    }
}
