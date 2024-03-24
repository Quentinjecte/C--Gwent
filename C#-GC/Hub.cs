﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using NAudio.Wave;
using System.Drawing;
using System.IO;

namespace C__GC
{

    internal class Hub
    {
        private int HubIndex;
        private string[] HubInfo;
        private string Prompt;
        int newWidth;
        int newHeight;

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
            ResourceAllocator allocator = new ResourceAllocator();

            try
            {
                // Get the directory where the executable is located
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

                // Path to the "maps.json" file in the same directory as the executable
                string mapsJsonPath = Path.Combine(baseDirectory, "../../../maps.json");

                // Load maps from the JSON file
                allocator.LoadMapsFromJson(mapsJsonPath);

                // Print contents of _mapStorage for debugging
                Console.WriteLine("Maps loaded:");
                foreach (var kvp in allocator._mapStorage)
                {
                    Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
                }

                // Get the existing map named "map1" from the ResourceAllocator
                string map = allocator.GetMap("map1");

                if (map == null)
                {
                    Console.WriteLine("Map 'map1' not found.");
                }
                else
                {
                    // Display the existing map
                    Console.WriteLine("Existing Map:");
                    Console.WriteLine(map);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while loading maps: " + ex.Message);
            }
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

            while (!int.TryParse(Console.ReadLine(), out newWidth) || newWidth < 400)
            {
                Console.WriteLine("Invalid width. Please enter a valid positive integer.");
                Console.WriteLine("Enter the new window width (in pixels):");
            }

            Console.WriteLine("Enter the new window height (in pixels):");
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