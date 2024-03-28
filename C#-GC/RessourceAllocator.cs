using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public static class ResourceAllocator
{
    static public Dictionary<string, string> _mapName;

    static ResourceAllocator()
    {
        _mapName = new Dictionary<string, string>();
    }

    // Load maps from JSON files
    private void LoadMapsFromJson(string jsonFilePath)
    {
        try
        {
            string jsonData = File.ReadAllText(jsonFilePath);
            _mapName = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonData);
            //Console.WriteLine("Maps loaded successfully.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("JSON file not found.");
        }
        catch (Exception)
        {
            Console.WriteLine("An error occurred while loading maps");
        }
    }

/*    public void LoadMapsFromAnsiTxt(string pathFile)
    {
        try
        {
            string jsonData = File.ReadAllText(pathFile);
            _mapName = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonData);
            //Console.WriteLine("Maps loaded successfully.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found.");
        }
        catch (Exception)
        {
            Console.WriteLine("An error occurred while loading maps");
        }
    }*/

    // Get map data by name
    public static string GetBackMap(string mapName)
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

    public static string GetFrontMap(string mapName)
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
                str = str.Replace("\\e", "\x1b");
                map.Close();
                _mapName.Add(mapName, str);
            }
            return _mapName[mapName];
        }
    }
}