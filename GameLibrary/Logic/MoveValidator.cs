using GameLibrary.Enums;
using GameLibrary.GameModels;
using System.Collections.Generic;

namespace GameLibrary.Logic
{
    public static class MoveValidator
    {
        public static bool IsColision(int newPositionX, int newPositionY, List<List<int>> mapTileMatrix, List<List<int>> mapItemsMatrix = null)
        {
            var mapTileX = newPositionX / GlobalGameData.TileSize; //spr czy zaokrągla w dół
            var mapTileY = newPositionY / GlobalGameData.TileSize;

            var mapTile = (EMapTile)mapTileMatrix[mapTileY][mapTileX];
            if (mapTile == EMapTile.BlockadeHard)
                return true;
            else
                return false;
        }
    }
}
