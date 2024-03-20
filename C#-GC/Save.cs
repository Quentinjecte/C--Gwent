using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace C__GC
{
    public class Data
    {
        public string? Name { get; set; }
        public int Age { get; set; }
    }

    public class ProgramTest
    {
        public static async void Save()
        {
            var IDCard = new Data
            {
                Name = "Bob",
                Age = 1000
            };

            /*            string stringSaveFile = JsonSerializer.Serialize(IDCard);

                        Console.WriteLine(stringSaveFile);*/

            string fileName = "../../../BobSaveData.json";
            await using FileStream createStream = File.Create(fileName);
            await JsonSerializer.SerializeAsync(createStream, IDCard);


            Console.WriteLine(File.ReadAllText(fileName));
        }
    }
}
