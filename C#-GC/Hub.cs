//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Media;
//using NAudio.Wave;

//namespace C__GC
//{

//    internal class Hub
//    {
//        private int _hubIndex;
//        private string _prompt;
//        str_func[] _hubInfo;

//        public const str_func[] _mainMenuPreset = [
//                new str_func("New Game", NewGame),
//                new str_func("Continue", Continue),
//                new str_func("Options", Option),
//                new str_func("Credits", Credit),
//                new str_func("Exit", Exit)
//                ];

//        public const str_func[] _optionsPreset = [
//                new str_func("Window Size", ResizeConsoleWindow),
//                new str_func("Language", null),
//                new str_func("Music", Music),
//                new str_func("Exit", Exit)
//                ];

//        public int Volume;

//        public Hub(){}

//        public void InitHub(string prompt, str_func[] HubInfo)
//        {
//            _prompt = prompt;
//            _hubInfo = HubInfo;
//            _hubIndex = 0;
//        }

//        private void OverlayOption()
//        {
//            Console.WriteLine(_prompt);
//            for (int i = 0; i < _hubInfo.Length; i++)
//            {
//                string ActChoise;
//                string CurrentOption = _hubInfo[i].Str;

//                if (i == _hubIndex)
//                {
//                    ActChoise = "->";
//                    Console.ForegroundColor = ConsoleColor.Black;
//                    Console.BackgroundColor = ConsoleColor.Gray;
//                }
//                else
//                {
//                    ActChoise = "  ";
//                    Console.ForegroundColor = ConsoleColor.White;
//                    Console.BackgroundColor = ConsoleColor.Black;
//                }
//                Console.WriteLine($"{ActChoise}  {CurrentOption}");
//            }
//            Console.ResetColor();
//        }

//        public int SwapIndex(int i)
//        {
//            ConsoleKey KeyPress;
//            byte isClosed;

//            do
//            {
//                do
//                {
//                    Console.Clear();
//                    OverlayOption();

//                    ConsoleKeyInfo KeyInfo = Console.ReadKey(true);
//                    KeyPress = KeyInfo.Key;

//                    if (KeyPress == ConsoleKey.UpArrow)
//                    {
//                        _hubIndex--;
//                        if (_hubIndex == -1)
//                        {
//                            _hubIndex = _hubInfo.Length - 1;
//                        }
//                    }
//                    else if (KeyPress == ConsoleKey.DownArrow)
//                    {
//                        _hubIndex++;
//                        if (_hubIndex == _hubInfo.Length)
//                        {
//                            _hubIndex = 0;
//                        }
//                    }
//                } while (KeyPress != ConsoleKey.Spacebar);

//                isColsed = _hubInfo[_hubIndex].Func(0);

//            } while (isClosed != 1);

//            return _hubIndex;
//        }

//        public int NewGame(int i)
//        {
//            return 0;
//        }

//        public int Continue(int i)
//        {
//            return 0;
//        }

//        public int Option(int i)
//        {
//            InitHub(_prompt, Hub.optionsPreset);
//            SwapIndex(0);
//            return 0;
//        }

//        public int Credit(int i)
//        {
//            Console.Clear();
//            Console.WriteLine("\n Game designed by Gwent\n Dev: Tom (holland), Valentin (Saint), Quentin (Avion)");
//            Console.ReadKey(true);
//            return 0;
//        }

//        public int Exit(int i)
//        {
//            Environment.Exit(0);
//            return 0;
//        }

//        private int ResizeConsoleWindow(int i)
//        {
//            Console.WriteLine("Enter the new window width (in pixels '400 min'):");

//            int newWidth;
//            while (!int.TryParse(Console.ReadLine(), out newWidth) || newWidth < 400)
//            {
//                Console.WriteLine("Invalid width. Please enter a valid positive integer.");
//                Console.WriteLine("Enter the new window width (in pixels):");
//            }

//            Console.WriteLine("Enter the new window height (in pixels):");
//            int newHeight;
//            while (!int.TryParse(Console.ReadLine(), out newHeight) || newHeight < 400)
//            {
//                Console.WriteLine("Invalid height. Please enter a valid positive integer.");
//                Console.WriteLine("Enter the new window height (in pixels '400 min'):");
//            }

//            int consoleWidth = (int)Math.Ceiling((double)newWidth / 8); // Convertie Pixel to Console Size, and rounded up the value
//            int consoleHeight = (int)Math.Ceiling((double)newHeight / 16);

//            try
//            {
//                Console.SetWindowSize(Math.Min(consoleWidth, Console.LargestWindowWidth), Math.Min(consoleHeight, Console.LargestWindowHeight));
//                Console.WriteLine($"Window size set to {newWidth} x {newHeight}.");
//            }
//            catch (ArgumentOutOfRangeException)
//            {
//                Console.WriteLine("The new window size would force the console buffer size to be too large.");
//                Console.WriteLine("Please try again with a smaller window size.");
//            }
//            return 0;
//        }

//        private int Music(int i)
//        {
//            ConsoleKeyInfo KeyPress;

//            do
//            {
//                Console.Clear();
//                Console.WriteLine($"Volume : {Volume * 10}%");

//                switch (Volume)
//                {
//                    case 0:
//                        Console.WriteLine("[          ]   (Volume : 0%)");
//                        break;
//                    case 1:
//                        Console.WriteLine("[░         ]   (Volume : 10%)");
//                        break;
//                    case 2:
//                        Console.WriteLine("[░░        ]   (Volume : 20%)");
//                        break;
//                    case 3:
//                        Console.WriteLine("[░░▒       ]   (Volume : 30%)");
//                        break;
//                    case 4:
//                        Console.WriteLine("[░░▒▒      ]   (Volume : 40%)");
//                        break;
//                    case 5:
//                        Console.WriteLine("[░░▒▒▓     ]   (Volume : 50%)");
//                        break;
//                    case 6:
//                        Console.WriteLine("[░░▒▒▒▓    ]   (Volume : 60%)");
//                        break;
//                    case 7:
//                        Console.WriteLine("[░░▒▒▒▓▓   ]   (Volume : 70%)");
//                        break;
//                    case 8:
//                        Console.WriteLine("[░░▒▒▒▓▓▓  ]   (Volume : 80%)");
//                        break;
//                    case 9:
//                        Console.WriteLine("[░░▒▒▒▓▓▓█ ]   (Volume : 90%)");
//                        break;
//                    case 10:
//                        Console.WriteLine("[░░▒▒▒▓▓▓██]   (Volume : 100%)");
//                        break;
//                    default:
//                        Console.WriteLine("Invalid volume");
//                        break;
//                }

//                KeyPress = Console.ReadKey();

//                if (KeyPress.Key == ConsoleKey.UpArrow)
//                {
//                    Volume++;
//                    if (Volume > 10)
//                    {
//                        Volume = 10;
//                    }
//                }
//                else if (KeyPress.Key == ConsoleKey.DownArrow)
//                {
//                    Volume--;
//                    if (Volume < 0)
//                    {
//                        Volume = 0;
//                    }
//                }
//            } while (KeyPress.Key != ConsoleKey.Spacebar); // Sortir de la boucle lorsque l'utilisateur appuie sur Escape

//            return Volume;
//        }
//    }
//}


///*-------------------------------------------------------
// * |                                                    |
// * |        Utilisation de Nugets Naudio                |                     
// * |                                                    |
// * ------------------------------------------------------

///*        private IWavePlayer player;
//        private AudioFileReader audioFile;
//        // Méthode pour démarrer la musique
//        private void StartMusic(string filePath)
//        {
//            // Créer un lecteur audio
//            player = new WaveOutEvent();

//            // Charger le fichier audio
//            audioFile = new AudioFileReader(filePath);

//            // Attacher le fichier audio au lecteur
//            player.Init(audioFile);

//            // Commencer la lecture
//            player.Play();
//        }

//        // Méthode pour arrêter la musique
//        private void StopMusic()
//        {
//            // Arrêter la lecture
//            player.Stop();

//            // Libérer les ressources
//            player.Dispose();
//            audioFile.Dispose();
//        }*/