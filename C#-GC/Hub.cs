using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using NAudio.Wave;
using System.Drawing;

namespace C__GC
{

    internal class Hub
    {
        private int HubIndex;
        private string[] HubInfo;
        private string Prompt;

        public int Volume;

        public Hub(string _Prompt, string[] _HubInfo)
        {
            Prompt = _Prompt;
            HubInfo = _HubInfo;
            HubIndex = 0;
        }

        private void OverlayOption()
        {
            Console.WriteLine(Prompt);
            for (int i = 0; i < HubInfo.Length; i++)
            {
                string ActChoise;
                string CurrentOption = HubInfo[i];

                if (i == HubIndex)
                {
                    ActChoise = "  ";
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    ActChoise = "  ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine($"{ActChoise}  {CurrentOption}");
            }
            Console.ResetColor();
        }

        public int SwapIndex()
        {
            ConsoleKey KeyPress;

            do
            {
                Console.Clear();
                OverlayOption();

                ConsoleKeyInfo KeyInfo = Console.ReadKey(true);
                KeyPress = KeyInfo.Key;

                if (KeyPress == ConsoleKey.UpArrow)
                {
                    HubIndex--;
                    if (HubIndex == -1)
                    {
                        HubIndex = HubInfo.Length - 1;
                    }
                }
                else if (KeyPress == ConsoleKey.DownArrow)
                {
                    HubIndex++;
                    if (HubIndex == HubInfo.Length)
                    {
                        HubIndex = 0;
                    }
                }
            }
            while (KeyPress != ConsoleKey.Spacebar);

            return HubIndex;
        }

        public void NewGame()
        {

            Console.Clear();
            Console.WriteLine("Clearing the screen!");

            string assetsPath = Path.Combine(Directory.GetCurrentDirectory(), "assets", "C:\\Users\\qrenaud\\Documents\\GitHub\\C--Gwent\\C#-GC\\assets\\testMap.bmp");

            // Load the bitmap image using the MapParser
            MapParser parser = new MapParser();
            Bitmap mapImage = parser.Load(assetsPath);

            // Print the parsed bitmap to console
            Console.WriteLine(parser.ParseBitmap(assetsPath, 100));

            // Create an instance of the Player class and pass the MapParser and Bitmap objects
            Player player = new Player();

            // Draw the player on the map
            player.DrawPlayer();

            // Start taking input from the player
            player.Input(mapImage, 0, 0);
        }


        public void Continue()
        {

        }

        public void Option(string prompt)
        {
            string[] OptionsInfo = 
                { @"
      █     █░ ██▓ ███▄    █ ▓█████▄  ▒█████   █     █░     ██████  ██▓▒███████▒▓█████ 
     ▓█░ █ ░█░▓██▒ ██ ▀█   █ ▒██▀ ██▌▒██▒  ██▒▓█░ █ ░█░   ▒██    ▒ ▓██▒▒ ▒ ▒ ▄▀░▓█   ▀ 
     ▒█░ █ ░█ ▒██▒▓██  ▀█ ██▒░██   █▌▒██░  ██▒▒█░ █ ░█    ░ ▓██▄   ▒██▒░ ▒ ▄▀▒░ ▒███   
     ░█░ █ ░█ ░██░▓██▒  ▐▌██▒░▓█▄   ▌▒██   ██░░█░ █ ░█      ▒   ██▒░██░  ▄▀▒   ░▒▓█  ▄ 
     ░░██▒██▓ ░██░▒██░   ▓██░░▒████▓ ░ ████▓▒░░░██▒██▓    ▒██████▒▒░██░▒███████▒░▒████▒", @"

      ██▓     ▄▄▄       ███▄    █   ▄████  █    ██  ▄▄▄        ▄████ ▓█████ 
     ▓██▒    ▒████▄     ██ ▀█   █  ██▒ ▀█▒ ██  ▓██▒▒████▄     ██▒ ▀█▒▓█   ▀ 
     ▒██░    ▒██  ▀█▄  ▓██  ▀█ ██▒▒██░▄▄▄░▓██  ▒██░▒██  ▀█▄  ▒██░▄▄▄░▒███   
     ▒██░    ░██▄▄▄▄██ ▓██▒  ▐▌██▒░▓█  ██▓▓▓█  ░██░░██▄▄▄▄██ ░▓█  ██▓▒▓█  ▄ 
     ░██████▒ ▓█   ▓██▒▒██░   ▓██░░▒▓███▀▒▒▒█████▓  ▓█   ▓██▒░▒▓███▀▒░▒████▒", @"

      ███▄ ▄███▓ █    ██   ██████  ██▓ ▄████▄  
     ▓██▒▀█▀ ██▒ ██  ▓██▒▒██    ▒ ▓██▒▒██▀ ▀█  
     ▓██    ▓██░▓██  ▒██░░ ▓██▄   ▒██▒▒▓█    ▄ 
     ▒██    ▒██ ▓▓█  ░██░  ▒   ██▒░██░▒▓▓▄ ▄██▒
     ▒██▒   ░██▒▒▒█████▓ ▒██████▒▒░██░▒ ▓███▀ ░", @"

     ▓█████ ▒██   ██▒ ██▓▄▄▄█████▓
     ▓█   ▀ ▒▒ █ █ ▒░▓██▒▓  ██▒ ▓▒
     ▒███   ░░  █   ░▒██▒▒ ▓██░ ▒░
     ▒▓█  ▄  ░ █ █ ▒ ░██░░ ▓██▓ ░ 
     ░▒████▒▒██▒ ▒██▒░██░  ▒██▒ ░ " 
            };

            Hub HubOptions = new Hub(prompt, OptionsInfo);
            HubIndex = HubOptions.SwapIndex();

            switch(HubIndex) 
            {
                case 0:
                    ResizeConsoleWindow();
                    Option(prompt);
                    break;

                case 1:
                    break;

                case 2:
                    Music();
                    Option(prompt);
                    break;

                case 3:
                    break;
            }
        }

        public void Credit()
        {
            Console.Clear();
            Console.WriteLine("\n Game designed by Gwent\n Dev: Tom (holland), Valentin (Saint), Quentin (Avion), Mathieu (Mangemort)");
            Console.ReadKey(true);
        }

        public void Exit()
        {
            Environment.Exit(0);
        }

        private void ResizeConsoleWindow()
        {
            Console.WriteLine("Enter the new window width (in pixels '400 min'):");

            int newWidth;
            while (!int.TryParse(Console.ReadLine(), out newWidth) || newWidth < 400)
            {
                Console.WriteLine("Invalid width. Please enter a valid positive integer.");
                Console.WriteLine("Enter the new window width (in pixels):");
            }

            Console.WriteLine("Enter the new window height (in pixels):");
            int newHeight;
            while (!int.TryParse(Console.ReadLine(), out newHeight) || newHeight < 400)
            {
                Console.WriteLine("Invalid height. Please enter a valid positive integer.");
                Console.WriteLine("Enter the new window height (in pixels '400 min'):");
            }

            int consoleWidth = (int)Math.Ceiling((double)newWidth / 8); // Convertie Pixel to Console Size, and rounded up the value
            int consoleHeight = (int)Math.Ceiling((double)newHeight / 16);

            try
            {
                Console.SetWindowSize(Math.Min(consoleWidth, Console.LargestWindowWidth), Math.Min(consoleHeight, Console.LargestWindowHeight));
                Console.WriteLine($"Window size set to {newWidth} x {newHeight}.");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("The new window size would force the console buffer size to be too large.");
                Console.WriteLine("Please try again with a smaller window size.");
            }
        }

        private int Music()
        {
            ConsoleKeyInfo KeyPress;

            do
            {
                Console.Clear();
                Console.WriteLine($"Volume : {Volume * 10}%");

                switch (Volume)
                {
                    case 0:
                        Console.WriteLine("[          ]   (Volume : 0%)");
                        break;
                    case 1:
                        Console.WriteLine("[░         ]   (Volume : 10%)");
                        break;
                    case 2:
                        Console.WriteLine("[░░        ]   (Volume : 20%)");
                        break;
                    case 3:
                        Console.WriteLine("[░░▒       ]   (Volume : 30%)");
                        break;
                    case 4:
                        Console.WriteLine("[░░▒▒      ]   (Volume : 40%)");
                        break;
                    case 5:
                        Console.WriteLine("[░░▒▒▓     ]   (Volume : 50%)");
                        break;
                    case 6:
                        Console.WriteLine("[░░▒▒▒▓    ]   (Volume : 60%)");
                        break;
                    case 7:
                        Console.WriteLine("[░░▒▒▒▓▓   ]   (Volume : 70%)");
                        break;
                    case 8:
                        Console.WriteLine("[░░▒▒▒▓▓▓  ]   (Volume : 80%)");
                        break;
                    case 9:
                        Console.WriteLine("[░░▒▒▒▓▓▓█ ]   (Volume : 90%)");
                        break;
                    case 10:
                        Console.WriteLine("[░░▒▒▒▓▓▓██]   (Volume : 100%)");
                        break;
                    default:
                        Console.WriteLine("Invalid volume");
                        break;
                }

                KeyPress = Console.ReadKey();

                if (KeyPress.Key == ConsoleKey.UpArrow)
                {
                    Volume++;
                    if (Volume > 10)
                    {
                        Volume = 10;
                    }
                }
                else if (KeyPress.Key == ConsoleKey.DownArrow)
                {
                    Volume--;
                    if (Volume < 0)
                    {
                        Volume = 0;
                    }
                }
            } while (KeyPress.Key != ConsoleKey.Spacebar); // Sortir de la boucle lorsque l'utilisateur appuie sur Escape

            return Volume;
        }
    }
}


/*-------------------------------------------------------
 * |                                                    |
 * |        Utilisation de Nugets Naudio                |                     
 * |                                                    |
 * ------------------------------------------------------

/*        private IWavePlayer player;
        private AudioFileReader audioFile;
        // Méthode pour démarrer la musique
        private void StartMusic(string filePath)
        {
            // Créer un lecteur audio
            player = new WaveOutEvent();

            // Charger le fichier audio
            audioFile = new AudioFileReader(filePath);

            // Attacher le fichier audio au lecteur
            player.Init(audioFile);

            // Commencer la lecture
            player.Play();
        }

        // Méthode pour arrêter la musique
        private void StopMusic()
        {
            // Arrêter la lecture
            player.Stop();

            // Libérer les ressources
            player.Dispose();
            audioFile.Dispose();
        }*/