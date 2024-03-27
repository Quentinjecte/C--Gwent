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

            _mapDisplay.xOffset = 0;
            _mapDisplay.yOffset = 0;
            _mapDisplay.content = newMap;
            _mapDisplay.width = 101;

            //_player.InitPlayer(mapName, 101, this);
            //_player.Input(0, 0);

            // Subscribe the map to the DisplaySystem
            DisplaySystem.Subscribe(_mapDisplay);
            DisplaySystem.SetMapDisplay(_mapDisplay);
            DisplaySystem.Update();
        }
    }

}
