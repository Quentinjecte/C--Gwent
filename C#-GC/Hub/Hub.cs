﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using NAudio.Wave;
using C__GC.DataString;
using System.Drawing;

namespace C__GC.Hub
{
    internal class Hub
    {
        private int _hubIndex;
        private string _prompt;

        str_func[] _hubInfo;
        public str_func[] _mainMenuPreset;
        public str_func[] _OptionMenuPreset;
        public str_func[] _OptionWindows;

        int Volume;
        int isClosed;

        public Hub()
        {
            _OptionWindows = new[] { 
                new str_func(CharactereData.OptionWindowSize[0]),
                new str_func(CharactereData.OptionWindowSize[1]), // Language pas fait
                new str_func(CharactereData.OptionWindowSize[2]),
            };

            _OptionMenuPreset = new[] { 
                new str_func(CharactereData.OptionInfo[0], () => ResizeConsoleWindow(CharactereData.Prompt, _OptionWindows), 0),
                new str_func(CharactereData.OptionInfo[1], Exit, 1), // Language pas fait
                new str_func(CharactereData.OptionInfo[2], Music, 2),
                new str_func(CharactereData.OptionInfo[3], Exit, 3),
            };

            _mainMenuPreset = new[] { 
                new str_func(CharactereData.HubInfo[0], NewGame, 0),
                new str_func(CharactereData.HubInfo[1], Continue, 1),
                new str_func(CharactereData.HubInfo[2], () => Option(CharactereData.Prompt, _OptionMenuPreset), 2),
                new str_func(CharactereData.HubInfo[3], Credit, 3),
                new str_func(CharactereData.HubInfo[4], Save, 4),
                new str_func(CharactereData.HubInfo[5], Exit, 5),
            };


            _hubIndex = 0;
        }

        public void InitHub(string prompt, str_func[] HubInfo)
        {
            _prompt = prompt;
            _hubInfo = HubInfo;
            _hubIndex = 0;
        }

        private void OverlayOption()
        {
            Console.WriteLine(_prompt);
            for (int i = 0; i < _hubInfo.Length; i++)
            {
                string ActChoise;
                string CurrentOption = _hubInfo[i].Str;

                if (i == _hubIndex)
                {
                    ActChoise = "  ";
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    ActChoise = " ";
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
                do
                {
                    Console.Clear();
                    OverlayOption();

                    ConsoleKeyInfo KeyInfo = Console.ReadKey(true);
                    KeyPress = KeyInfo.Key;

                    if (KeyPress == ConsoleKey.UpArrow)
                    {
                        _hubIndex--;
                        if (_hubIndex == -1)
                        {
                            _hubIndex = _hubInfo.Length - 1;
                        }
                    }
                    else if (KeyPress == ConsoleKey.DownArrow)
                    {
                        _hubIndex++;
                        if (_hubIndex == _hubInfo.Length)
                        {
                            _hubIndex = 0;
                        }
                    }
                } while (KeyPress != ConsoleKey.Spacebar);

                _hubInfo[_hubIndex].ExecuteAction();

            } while (isClosed != 1);

            return _hubIndex;
        }

        public void NewGame()
        {
            Console.Clear();
            Console.WriteLine("Clearing the screen!");

            string assetsPath = Path.Combine(Directory.GetCurrentDirectory(), "assets", "C:\\Users\\Tom\\source\\repos\\C--Gwent\\C#-GC\\assets\\testMap.bmp");

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
            ProgramTest programTest = new ProgramTest();
            Console.Clear();
            programTest.Load();
            Console.ReadKey(true);
        }

        public void Option(string prompt, str_func[] HubInfo)
        {
            Hub HubOptions = new Hub();
            HubOptions.InitHub(prompt, _OptionMenuPreset);
            _hubIndex = HubOptions.SwapIndex();
        }

        public void Credit()
        {
            Console.Clear();
            Console.WriteLine("\n Game designed by Gwent\n Dev: Tom (holland), Valentin (Saint), Quentin (Avion), Mathieu (Mangemort)");
            Console.ReadKey(true);
        }

        public void Save()
        {
            ProgramTest programTest = new ProgramTest();
            Console.Clear();
            programTest.Save();
        }

        public void Exit()
        {
            Environment.Exit(0);
        }

        private void ResizeConsoleWindow(string prompt, str_func[] HubInfo)
        {
            //RCW -> ResizeConsoleWindow
            Hub HubOptionsRCW = new Hub();
            HubOptionsRCW.InitHub(prompt, _OptionWindows);
            _hubIndex = HubOptionsRCW.SwapIndex();

            int newWidth = 0;
            int newHeight = 0;

            switch (_hubIndex)
            {
                case 0:
                    newWidth = Console.LargestWindowWidth;
                    newHeight = Console.LargestWindowHeight;
                    break;

                case 1:
                    newWidth = 1600;
                    newHeight = 1200;
                    break;

                case 2:
                    newWidth = 1280;
                    newHeight = 1024;
                    break;
            }

            int consoleWidth = (int)Math.Ceiling((double)newWidth / 8); // Convert Pixel to Console Size
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

        private void Music()
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

                if (KeyPress.Key == ConsoleKey.UpArrow || KeyPress.Key == ConsoleKey.Z)
                {
                    Volume++;
                    if (Volume > 10)
                    {
                        Volume = 10;
                    }
                }
                else if (KeyPress.Key == ConsoleKey.DownArrow || KeyPress.Key == ConsoleKey.S)
                {
                    Volume--;
                    if (Volume < 0)
                    {
                        Volume = 0;
                    }
                }
            } while (KeyPress.Key != ConsoleKey.Spacebar); // Sortir de la boucle lorsque l'utilisateur appuie sur Escape
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