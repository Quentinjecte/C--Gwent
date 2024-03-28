using C__GC.DataString;
using System;
using System.Collections.Generic;

namespace C__GC
{
    public class Dialogue
    {
        public DisplayElement _renderer;
        public event EventHandler<string> DialogueResponseReceived;

        public Dialogue()
        {
            _renderer = new DisplayElement("", 50, 0, 0);
        }

        public void Start()
        {
            DisplaySystem.Subscribe(_renderer);

            WriteDialogue("Perso 1", "Yo, comment ça va ?", ConsoleColor.Green);
            DisplaySystem.Update();

            WriteDialogue("Perso 2", "Ca va bien, merci, et toi ?", ConsoleColor.Red);
            DisplaySystem.Update();

            WriteDialogue("Perso 1", "Chill", ConsoleColor.Green);
            DisplaySystem.Update();

            WriteDialogue("Personnage 1", "Tu veux venir avec moi ?", ConsoleColor.Green);
            DisplaySystem.Update();

            // Attendre la réponse
            string response = GetResponse(() => Console.ReadLine());

            OnDialogueResponseReceived(response);

            DisplaySystem.Update();
        }

        private void WriteDialogue(string speaker, string speech, ConsoleColor consoleColor)
        {
            _renderer.content = $"{speaker}: {speech}";
            _renderer.fgColor = consoleColor;
            _renderer.bgColor = ConsoleColor.Black;

            // Affichez l'élément d'affichage
            DisplaySystem.Subscribe(_renderer);
            DisplaySystem.Update();

            Thread.Sleep(3000);
        }



        public string GetResponse(Func<string> inputReader)
        {
            Console.WriteLine("\nRépondez par 'oui' ou 'non': ");
            string response = inputReader.Invoke();
            return response;
        }

        protected virtual void OnDialogueResponseReceived(string response)
        {
            DialogueResponseReceived?.Invoke(this, response);
        }
    }
}
