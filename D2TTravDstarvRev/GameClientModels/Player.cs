using GameLibrary.Enums;

namespace D2TTravDstarvRev.GameClientModels
{
    public class Player
    {
        public string ID { get; set; }
        public string ImgSrc { get; set; }
        public int Age { get; set; }

        public int X { get; set; } //todo => validate + send to client + (in background async save to db)
        public int Y { get; set; }

        public string X_withPixelUnit { get { return X + "px"; } }
        public string Y_withPixelUnit { get { return Y + "px"; } }


        //Properties not from DB
        public bool Walking { get; set; } = false;
        public EDirection Facing { get; set; } = EDirection.Down;
    }
}
