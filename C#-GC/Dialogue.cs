using C__GC.DataString;
using System;
using System.Threading;

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

            // Write and display each line of dialogue
            WriteDialogue("Perso 1", "Yo, tu es du coin ?", ConsoleColor.Green);
            Console.WriteLine("Yo, tu es du coin ?", ConsoleColor.Green);
            WaitForResponse(); // Wait for response after each dialogue
            DisplaySystem.Update();

            WriteDialogue("Perso 2", "Ok je vois,  tu connais les monstres du coin ?", ConsoleColor.Red);
            Console.WriteLine("Ok je vois,  tu connais les monstres du coin ?", ConsoleColor.Green);
            WaitForResponse();
            DisplaySystem.Update();

            WriteDialogue("Perso 1", "Il y en as beacoup, sans compter les bandits tu devrais faire attention", ConsoleColor.Green);
            Console.WriteLine("Il y en as beacoup, tu devrais faire attention, tu le feras hein...", ConsoleColor.Green);
            WaitForResponse();
            DisplaySystem.Update();

            // Notify that the dialogue is finished
            Console.WriteLine("Reprend Ton chemin et fais gaffe !  ", ConsoleColor.Green);
        }

        private void WriteDialogue(string speaker, string speech, ConsoleColor consoleColor)
        {
            // Set content, foreground color, and background color of the renderer
            _renderer.content = $"{speaker}: {speech}";
            _renderer.fgColor = consoleColor;
            _renderer.bgColor = ConsoleColor.Black;

            // Update the display system to render the dialogue
            DisplaySystem.Update();
        }


        private void WaitForResponse()
        {
            // Prompt the user for response
            Console.WriteLine("\nRépondez par 'oui' ou 'non': ");
            // Wait for the response
            string response = Console.ReadLine();
            // Invoke the event to notify response received
            OnDialogueResponseReceived(response);
        }

        protected virtual void OnDialogueResponseReceived(string response)
        {
            // Invoke the event to notify response received
            DialogueResponseReceived?.Invoke(this, response);
        }
    }
}
