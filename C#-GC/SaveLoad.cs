using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace C__GC
{
    public class Data
    {
        public int PlayerX { get; set; }
        public int PlayerY { get; set; }
    }
    internal class SaveLoad
    {
        public string fileName = "../../../data.json";
        Data data;

        public void Save(Player.Player p)
        {
            data = new Data
            {
                PlayerX = p.playerX,
                PlayerY = p.playerY
            };

            using (var stram = new StreamWriter(fileName))
            {
                stram.Write(JsonSerializer.Serialize(data));
            }
        }
        public (int, int) Load()
        {
            string fileRead = File.ReadAllText(fileName);

            Data data = JsonSerializer.Deserialize<Data>(fileRead);

            int newX = data.PlayerX;
            int newY = data.PlayerY;

            return (newX, newY);
        }
    }
}
