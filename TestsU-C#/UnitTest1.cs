using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace C__GC.Tests
{
    [TestClass]
    public class DialogueTests
    {
        [TestMethod]
        public void TestDialogue_WithYesResponse()
        {
            var dialogue = new Dialogue();
            string input = "oui";

            string response = dialogue.GetResponse(() => input.ToLower());

            Assert.AreEqual("oui", response, ignoreCase: true); // Expects "oui" to be returned
        }

        [TestMethod]
        public void TestDialogue_WithNoResponse()
        {
            var dialogue = new Dialogue();
            string input = "non";

            string response = dialogue.GetResponse(() => input.ToLower());

            Assert.AreEqual("non", response, ignoreCase: true); // Expects "non" to be returned
        }
    }
}
