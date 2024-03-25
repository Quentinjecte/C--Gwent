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

        /*
        ------------------------------------------------------
        |             Initialize Varialbe Hub.cs             |                     
        ------------------------------------------------------
        */
        //MapParser Parser = new();
        Player Player = new Player();

        private int HubIndex, 
            _hubIndex, 
            newWidth, 
            newHeight, 
            Volume, 
            isClosed;

        private string _prompt, 
            Prompt;
        private string[] HubInfo;


        str_func[] _hubInfo;
        public str_func[] _mainMenuPreset, 
            _OptionMenuPreset, 
            _OptionWindows;

        public string map;

/*
    ------------------------------------------------------
    |             Initialize Function Hub.cs             |                     
    ------------------------------------------------------
*/

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
                new str_func(CharactereData.OptionInfo[3], () => Back(CharactereData.Prompt, _mainMenuPreset), 3),
            };

            _mainMenuPreset = new[] {
                new str_func(CharactereData.HubInfo[0], NewGame, 0),
                new str_func(CharactereData.HubInfo[1], Continue, 1),
                new str_func(CharactereData.HubInfo[2], () => Option(CharactereData.Prompt, _OptionMenuPreset), 2),
                new str_func(CharactereData.HubInfo[3], Credit, 3),
                new str_func(CharactereData.HubInfo[4], Exit, 4),
            };

            _hubIndex = 0;

            map = "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%\n" +
    "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%\n" +
    "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%\n" +
    "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%\n" +
    "%%%%%#########%%%%%%%%%%%%%%%%%%@@%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%#####%%%%%%%%%%%%%%%%%%%%%%%%%%%\n" +
    "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%\n" +
    "%%%%%%%%##########%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%\n" +
    "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%\n" +
    "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%\n" +
    "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%\n" +
    "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%\n" +
    "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%\n" +
    "####################################################################################################";
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
        private void NewGame()
        {
            Console.Clear();
            string assetsPath = Path.Combine(Directory.GetCurrentDirectory(), "assets", "B:\\repos\\C--Gwent\\C#-GC\\assets\\testMap.bmp");

            

            //string map = Parser.ParseBitmap(assetsPath, 102);
            // Print the parsed bitmap to console


            string map = "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%\n" +
                "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%\n" +
                "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%\n" +
                "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%\n" +
                "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%@@%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%#####%%%%%%%%%%%%%%%%%%%%%%%%%%%\n" +
                "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%\n" +
                "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%\n" +
                "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%\n" +
                "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%\n" +
                "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%\n" +
                "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%\n" +
                "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%\n" +
                "####################################################################################################";
            //Console.WriteLine(map);
            DisplayElement mapDisplay = new DisplayElement();
            mapDisplay.xOffset = 0;
            mapDisplay.yOffset = 0;
            mapDisplay.content = map;
            mapDisplay.width = 101;
            DisplaySystem.Subscribe(mapDisplay);
            DisplaySystem.Update();

            // Create an instance of the Player class and pass the MapParser and Bitmap objects
            Player.InitPlayer(map, 101);

            // Start taking input from the player
            Player.Input(0, 0);
        }
        private void Continue()
        {
        }
        private void Option(string prompt, str_func[] HubInfo)
        {
            Hub HubOptions = new Hub();
            HubOptions.InitHub(prompt, _OptionMenuPreset);
            _hubIndex = HubOptions.SwapIndex();
        }
        private void Credit()
        {
            Console.Clear();
            Console.WriteLine("\n Game designed by Gwent\n Dev: Tom (holland), Valentin (Saint), Quentin (Avion), Mathieu (Mangemort)");
            Console.ReadKey(true);
        }
        private void Exit()
        {
            Environment.Exit(0);
        }
        private void Back(string prompt, str_func[] HubInfo)
        {
            Hub HubOptions = new Hub();
            HubOptions.InitHub(prompt, _mainMenuPreset);
            _hubIndex = HubOptions.SwapIndex();
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