using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace D2TTravDstarvRev.GameClientModels
{
    public class Map
    {
        public string BackgroundImage { get; set; } = "../images/CameraDemoMap.png";
        public int Width { get; set; }
        public int Height { get; set; }

        public Map()
        {
            System.Drawing.Image img = System.Drawing.Image.FromFile(@"c:\ggs\ggs Access\images\members\1.jpg");
            MessageBox.Show("Width: " + img.Width + ", Height: " + img.Height);

            Bitmap img = new Bitmap();
            Width = img.Height;
            Height = img.Width;
        }

        //todo wlepiasz to na widok Map.CssStyle
        public string CssStyle() => $@"
            top: 0px ;
            left: 0px;
            width: 100%;
            height: 100%; 
            ";

        public string CssStyle(Player c) 
            => $@"background-image: url({BackgroundImage});
                  width: calc(13 * var(--grid-cell));
                  height: calc(10 * var(--grid-cell));";

        //<div class="map pixelArt" id="map" width="500" height="500" >

//        .map {
//    image-rendering: pixelated;
//    background-image: url(../images/CameraDemoMap.png);
//        background-size: 100%;
//    width: calc(13 * var(--grid-cell)); /*depends on map size*/
//    height: calc(10 * var(--grid-cell)); /*depends on map size*/
//    position: relative;
//}
}
}
