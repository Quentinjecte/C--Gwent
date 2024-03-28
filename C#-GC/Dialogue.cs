
﻿using C__GC.DataString;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__GC
{ 
    public class Dialogue
    {
        DisplayElement _renderer;

        public Dialogue()
        {
            _renderer = new DisplayElement("", 50, 0, 0);
        }

        public void Start()
        {
            DisplaySystem.Subscribe(_renderer);

            WriteDialogue("Perso 1", "Yo, comment ça va ?", ConsoleColor.Green);

            WriteDialogue("Perso 2", "Ca va bien, merci, et toi ?", ConsoleColor.Red);

            WriteDialogue("Perso 1", "Chill", ConsoleColor.Green);

            WriteDialogue("Personnage 1", "Voulez-vous venir avec moi ?", ConsoleColor.Green);

            // Attendre la réponse
            string response = GetResponse(() => Console.ReadLine());


            if (response.ToLower() == "oui")
            {
                WriteDialogue("Personnage 2", "D'accord, allons-y !", ConsoleColor.Red);
            }
            else
            {
                WriteDialogue("Personnage 2", "D'accord, peut-être une autre fois alors.", ConsoleColor.Red);
            }

            DisplaySystem.Update();
        }


        private void WriteDialogue(string speaker, string speech, ConsoleColor consoleColor)
        {
            _renderer.content = $"{speaker}: {speech}";
            _renderer.fgColor = consoleColor;
            _renderer.bgColor = ConsoleColor.Black;

            DisplaySystem.Update();
            Console.ReadLine();
        }

        public string GetResponse(Func<string> inputReader)
        {
            Console.WriteLine("\nRépondez par 'oui' ou 'non': ");
            string response = inputReader.Invoke();
            return response;
        }

    }
}
