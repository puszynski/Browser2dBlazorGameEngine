using GameLibrary.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameLibrary.Logic.GameInitializer
{
    public class CreateMap
    {
        public async Task<GameLibrary.GameModels.Map> Execute(string mapID, GameModels.Camera camera)
        {
            //pseudo DB
            var demoMapTiles = new List<List<int>>
            {
                new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                new List<int> { 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1 },
                new List<int> { 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1 },
                new List<int> { 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1 },
                new List<int> { 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1 },
                new List<int> { 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1 },
                new List<int> { 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1 },
                new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
            };

            var map = new Map()
            {
                ID = mapID,
                TilesMatrix = demoMapTiles
            };

            //mapping
            var gameMap = new GameLibrary.GameModels.Map(map.ID, 
                                                         camera, 
                                                         map.TilesMatrix);
            return gameMap;
        }
    }
}
