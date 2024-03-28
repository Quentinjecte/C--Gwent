using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace TU_C_
{
    [TestClass]
    public class UnitTestDialogue
    {
        public void TestDialogue_WithYesResponse()
        {
            // Préparer les données du test
            string response = "oui";
            string expectedOutput = "Perso 1: Yo, comment ça va ?\r\n" +
                                    "Perso 2: Ca va bien, merci, et toi ?\r\n" +
                                    "Perso 1: Chill\r\n" +
                                    "Personnage 1: On part à l'aventure ?\r\n" +
                                    "\r\nRépondez par 'oui' ou 'non': \r\n" +
                                    "Personnage 2: D'accord, let's go !\r\n";

            // Exécuter le test
            string actualOutput = RunDialogueTest(response);

            // Vérifier le résultat
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestDialogue_WithNoResponse()
        {
            // Préparer les données du test
            string response = "non";
            string expectedOutput = "Perso 1: Yo, comment ça va ?\r\n" +
                                    "Perso 2: Ca va bien, merci, et toi ?\r\n" +
                                    "Perso 1: Chill\r\n" +
                                    "Personnage 1: On part à l'aventure ?\r\n" +
                                    "\r\nRépondez par 'oui' ou 'non': \r\n" +
                                    "Personnage 2: D'accord, peut-être une autre fois alors.\r\n";

            // Exécuter le test
            string actualOutput = RunDialogueTest(response);

            // Vérifier le résultat
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        private string RunDialogueTest(string response)
        {
            // Créer une instance de StringWriter pour intercepter la sortie console
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Créer une instance de Dialogue
                Dialogue dialogue = new Dialogue();

                // Simuler une réponse utilisateur pour le test
                using (StringReader sr = new StringReader(response))
                {
                    Console.SetIn(sr);

                    // Exécuter le dialogue
                    dialogue.Start();

                    // Retourner la sortie console
                    return sw.ToString();
                }
            }
        }
    }
}
