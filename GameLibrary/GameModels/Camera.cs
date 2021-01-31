using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary.GameModels
{
    public class Camera
    {
        readonly Player _mainPlayer;
        readonly int _widthPx;
        readonly int _heightPx;


        public Camera(int widthPx, int heightPx, Player mainPlayer)
        {
            _widthPx = widthPx;
            _heightPx = heightPx;
            _mainPlayer = mainPlayer;
        }

        public string TranslateHTMLElementX { get; set; }
        public string TranslateHTMLElementY { get; set; }


        public void UpdateCameraPosition()
        {
            //CAMERA SECTON(camera size: 160 * 144)
            var cameraOffsetX = _widthPx / 2;
            var cameraOffsetY = _heightPx / 2;

            TranslateHTMLElementX = $"{-_mainPlayer.X * GlobalGameData.PixelSize + cameraOffsetX * GlobalGameData.PixelSize}px";
            TranslateHTMLElementY = $"{-_mainPlayer.Y * GlobalGameData.PixelSize + cameraOffsetY * GlobalGameData.PixelSize}px";
        }
    }
}
