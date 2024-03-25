using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__GC
{
    public class MapManager
    {
        private ResourceAllocator _allocator;
        private DisplayElement _mapDisplay;

        public MapManager(ResourceAllocator allocator, DisplayElement mapDisplay)
        {
            _allocator = allocator;
            _mapDisplay = mapDisplay;
        }

        public void ChangeMap(string mapName)
        {
            // Get the directory where the executable is located
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Path to the "maps.json" file in the same directory as the executable
            string mapsJsonPath = Path.Combine(baseDirectory, "../../../maps/maps.json");

            // Load maps from the JSON file
            _allocator.LoadMapsFromJson(mapsJsonPath);
            string newMap = _allocator.GetMap(mapName);

            if (newMap == null)
            {
                Console.WriteLine($"Map '{mapName}' not found.");
                return;
            }

            // Unload the old map by removing its display element
            DisplaySystem.Unsubscribe(_mapDisplay);

            // Update the map display properties with the new map
            _mapDisplay.content = newMap;

            // Subscribe the new map to the DisplaySystem
            DisplaySystem.Subscribe(_mapDisplay);
        }
    }

}
