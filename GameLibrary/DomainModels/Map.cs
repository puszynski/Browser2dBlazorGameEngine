using GameLibrary.Enums;
using System.Collections.Generic;

namespace GameLibrary.DomainModels
{
    public class Map
    {
        public string ID { get; set; }
        public List<List<int>> TilesMatrix { get; set; } //EMapTile
        public List<List<EMapItems>> ItemsOnTilesMatrix { get; set; }
    }
}
