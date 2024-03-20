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
        public string? Name { get; set; }
        public int Age { get; set; }

        public string fileName = "../../../BloupSaveData.json";
    }

    public class ProgramTest
    {
        Data IDCard = new Data
        {
            Name = "Bob",
            Age = 1000
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
