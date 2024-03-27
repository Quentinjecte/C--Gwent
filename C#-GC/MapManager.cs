using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace C__GC
{
    public class MapManager
    {
        private ResourceAllocator _allocator;
        private DisplayElement _mapDisplay;
        private Player _player;

        internal MapManager(ResourceAllocator allocator, DisplayElement mapDisplay)
        {
            _allocator = allocator;
            _mapDisplay = mapDisplay;
            _player = new Player();
        }
        public void StartMap() 
        {
            // Get the directory where the executable is located
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            // Path to the "maps.json" file in the same directory as the executable
            string mapsJsonPath = Path.Combine(baseDirectory, "../../../maps/maps.json");

            // Load maps from the JSON file
            _allocator.LoadMapsFromJson(mapsJsonPath);

            // Get the initial map named "map1" from the ResourceAllocator
            string initialMap = _allocator.GetMap("map1");

            if (initialMap == null)
            {
                Console.WriteLine("Map 'map1' not found.");
                return;
            }

            // Set the content of the map display
            _mapDisplay.xOffset = 0;
            _mapDisplay.yOffset = 0;
            _mapDisplay.content = initialMap;
            _mapDisplay.width = 100;
            // Update the display
            DisplaySystem.Subscribe(_mapDisplay);
            DisplaySystem.SetMapDisplay(_mapDisplay);
            DisplaySystem.Update();

            // Initialize player after loading maps successfully
            _player.InitPlayer(initialMap, 100, this);
            _player.Input(0, 0);
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
                throw new Exception("map not found");
            }

            _mapDisplay.xOffset = 0;
            _mapDisplay.yOffset = 0;
            _mapDisplay.content = newMap;
            _mapDisplay.width = 100;

            // Subscribe the map to the DisplaySystem
            DisplaySystem.ReplaceByIndex(0, _mapDisplay);
            DisplaySystem.Update();

            _player.SetPlayerPosition(_player.playerX, _player.playerY);
            _player.Input(0, 0);
        }
    }

}
