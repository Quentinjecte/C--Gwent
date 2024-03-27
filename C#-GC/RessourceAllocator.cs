using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class ResourceAllocator
{
    public Dictionary<string, string> _mapStorage;

    public ResourceAllocator()
    {
        _mapStorage = new Dictionary<string, string>();
    }

    // Load maps from JSON files
    public void LoadMapsFromJson(string jsonFilePath)
    {
        try
        {
            string jsonData = File.ReadAllText(jsonFilePath);
            _mapStorage = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonData);
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

    // Get map data by name
    public string GetMap(string mapName)
    {
        if (_mapStorage.ContainsKey(mapName))
        {
            return _mapStorage[mapName];
        }
        else
        {
            Console.WriteLine($"Map '{mapName}' not found.");
            return null;
        }
    }

    // Store map data by name
    public void StoreMap(string mapName, string mapData)
    {
        _mapStorage[mapName] = mapData;
    }
}