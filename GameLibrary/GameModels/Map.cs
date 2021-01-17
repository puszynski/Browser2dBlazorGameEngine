using System.Drawing;

namespace GameLibrary.GameModels
{
    public class Map
    {
        public string ID { get; set; }
        public int TileSize { get { return 16; } } //todo move to settings - const for all maps
        public string BackgroundImage { get; set; } // dimensions of map image must be multiply of 16
        public int Width { get; set; }
        public int Height { get; set; }

        public Map(string id)
        {
            ID = id;
            BackgroundImage = ID + "Map.png"; ;

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
                  width: calc({Width / TileSize} * var(--grid-cell));
                  height: calc({Height / TileSize} * var(--grid-cell));";
    }
}
