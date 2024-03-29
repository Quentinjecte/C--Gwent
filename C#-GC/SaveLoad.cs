/*using System;
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

    }

    public class SaveLoad
    {
        public string fileName = "../../../BloupSaveData.json";

        Data IDCard;


        public void Save(Player p)
        {
            IDCard = new Data
            {
                PlayerX = p.playerX,
                PlayerY = p.playerY
            };

            using (var stream = new StreamWriter(fileName))
            {
                stream.Write(JsonSerializer.Serialize(IDCard));
            }

            // Console.WriteLine(File.ReadAllText(fileName));
        }
        public void Load()
        {
            string fileString = File.ReadAllText(fileName);

            Data data = JsonSerializer.Deserialize<Data>(fileString);

            Console.WriteLine($"PosX: {data.PlayerX}");
            Console.WriteLine($"PosY: {data.PlayerY}");

        }

    }
}*/