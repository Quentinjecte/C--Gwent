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

            DisplayElement oldMap = _mapDisplay;

            _mapDisplay.xOffset = 0;
            _mapDisplay.yOffset = 0;
            _mapDisplay.content = "###############%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%" +
                "*****%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%" +
                "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%" +
                "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%" +
                "%%%%%#########%%%%%%%%%%%%%%%%%%@@%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%#####%%%%%%%%%%%%%%%%%%%%%%%%%%%" +
                "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%" +
                "####################################################################################################" +
                "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%" +
                "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%" +
                "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%" +
                "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%" +
                "####################################################################################################";
            _mapDisplay.width = 100;

            // Subscribe the map to the DisplaySystem
            //DisplaySystem.Subscribe(_mapDisplay);
            //DisplaySystem.SetMapDisplay(_mapDisplay);
            DisplaySystem.ReplaceByValue(oldMap, _mapDisplay);
            DisplaySystem.Update();
        }
    }

}
