using C__GC.DataString;
using C__GC.Entity;
using C__GC.Player;
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
        private Player.Player _player;

        internal MapManager(ResourceAllocator allocator)
        {
            _allocator = allocator;
            _player = new();
        }
        public void StartMap() 
        {

            // Get the initial map named "map1" from the ResourceAllocator
            string initialMap = _allocator.GetBackMap("map1");
            //string initialMap = _allocator.GetFrontMap("mapMask.txt", 48);
            // Add FrontMap

            if (initialMap == null)
            {
                Console.WriteLine("Map 'map1' not found.");
                return;
            }

            // Set the content of the map display
            DisplayElement map = new DisplayElement(initialMap, 983, 0, 0);
            // Update the display
            DisplaySystem.Subscribe(map);
            DisplaySystem.Update();

            // Initialize player after loading maps successfully
            _player.InitPlayer(initialMap, 100, this);
            _player.Input(0, 0);
        }

        public string ChangeMap(string mapName)
        {

            string newMap = _allocator.GetBackMap(mapName);
            // Add FrontMap

            if (newMap == null)
            {
                throw new Exception("failed to load map");
            }

            DisplayElement mapDisplay = new DisplayElement(newMap, 100, 0, 0);

            // Subscribe the map to the DisplaySystem
            DisplaySystem.ReplaceByIndex(0, mapDisplay);
            DisplaySystem.Update();

            return newMap;
        }
    }

}
