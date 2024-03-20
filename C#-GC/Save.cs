using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace C__GC
{
    public class Data
    {
        public int PlayerX { get; set; }
        public int PlayerY { get; set; }

        public string fileName = "../../../BloupSaveData.json";
    }

    public class SaveLoad
    {
        Data IDCard = new Data
        {
            PlayerX = 0 /*Get playerX*/,
            PlayerY = 0 /*Get playerY*/
        };

        public void Save()
        {

            using (var stream = new StreamWriter(IDCard.fileName))
            {
                stream.Write(JsonSerializer.Serialize(IDCard));
            }

            // Console.WriteLine(File.ReadAllText(fileName));
        }
        public void Load()
        {
            Console.WriteLine(File.ReadAllText(IDCard.fileName));
        }

    }
}
