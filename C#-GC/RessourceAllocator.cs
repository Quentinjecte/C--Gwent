using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class ResourceAllocator
{
    public Dictionary<string, string> _mapName;

    public ResourceAllocator()
    {
        _mapName = new Dictionary<string, string>();
    }

    // Get map data by name
    public string GetBackMap(string mapName)
    {
        // Get the directory where the executable is located
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        // Path to the "maps.json" file in the same directory as the executable
        string mapsJsonPath = Path.Combine(baseDirectory, "../../../maps/maps.json");

        if (_mapName.ContainsKey(mapName))
        {
            return _mapName[mapName];
        }
        else
        {
            try {
                string content = File.ReadAllText(mapsJsonPath);
                _mapName = JsonSerializer.Deserialize<Dictionary<string, string>>(content);
            }
            catch (FileNotFoundException)
            {
                    Console.WriteLine("File not found.");
             }
            catch (Exception)
            {
                    Console.WriteLine("An error occurred while loading maps");
             }
            return _mapName[mapName];
        }
    }

    public string GetFrontMap(string mapName, int width)
    {
        if (_mapName.ContainsKey(mapName))
        {
            return _mapName[mapName];
        }
        else
        {
            using (StreamReader map = new StreamReader("../../../maps/"+mapName))
            {
                int count = 0;
                int startIndex = -1;
                string str = map.ReadToEnd();
                //while ((startIndex = str.IndexOf("\\e", startIndex + 1)) != -1)
                //{
                //    str = str.Insert(startIndex, "<BR>");
                //}
                str = str.Replace("\\e", "\x1b");
                map.Close();
                _mapName.Add(mapName, str);
            }
            return _mapName[mapName];
        }
    }
}