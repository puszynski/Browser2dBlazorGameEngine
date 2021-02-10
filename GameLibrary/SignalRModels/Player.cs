using System;
using System.Collections.Generic;
using System.Text;
using GameLibrary.Enums;

namespace GameLibrary.SignalRModels
{
    public class Player
    {
        public string ID { get; set; } 
        public string ImgSrc { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string MapID { get; set; }     
        public bool Walking { get; set; }
        public EDirection Facing { get; set; }
    }
}
