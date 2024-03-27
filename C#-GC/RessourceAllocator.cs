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
    private void LoadMapsFromJson(string jsonFilePath)
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

    public void LoadMapsFromAnsiTxt(string pathFile)
    {
        try
        {
            string jsonData = File.ReadAllText(pathFile);
            _mapStorage = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonData);
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
    }

    // Get map data by name
    public string GetBackMap(string mapName)
    {
        if (_mapStorage.ContainsKey(mapName))
        {
            return _mapStorage[mapName];
        }
        else
        {
            LoadMapsFromJson(mapName);
            return _mapStorage[mapName];
        }
    }

    public string GetFrontMap(string mapName)
    {
        if (_mapStorage.ContainsKey(mapName))
        {
            return _mapStorage[mapName];
        }
        else
        {
            LoadMapsFromJson(mapName);
            return _mapStorage[mapName];
        }
    }
}