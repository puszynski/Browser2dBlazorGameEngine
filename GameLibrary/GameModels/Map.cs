using System.Collections.Generic;
using System.Drawing;

namespace GameLibrary.GameModels
{
    public class Map
    {
        readonly Camera _camera;

        public string ID { get; set; }
        public string BackgroundImage { get; set; } // dimensions of map image must be multiply of tileSize => 16 px 
        public List<List<int>> TilesMatrix { get; set; } //int can be represented as EMapTile
        public int Width { get; set; }
        public int Height { get; set; }

        public Map(string id, Camera camera, List<List<int>> tilesMatrix)
        {
            _camera = camera;
            
            ID = id;
            TilesMatrix = tilesMatrix;

            BackgroundImage = ID + "Map.png";
            SetMapWidthAndHeight();
        }

        void SetMapWidthAndHeight()
        {
            try
            {
                var img = Image.FromFile($@"wwwroot/images/{BackgroundImage}");
                Width = img.Width;
                Height = img.Height;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        //todo wlepiasz to na widok Map.CssStyl
        public string CssStyle()
            => $@"background-image: url(../images/{BackgroundImage});
                  background-size: 100%;
                  width: calc({Width / GlobalGameData.TileSize} * var(--grid-cell));
                  height: calc({Height / GlobalGameData.TileSize} * var(--grid-cell));
                  transform:translate3d({_camera.TranslateHTMLElementX},{_camera.TranslateHTMLElementY}, 0px);";
    }
}
