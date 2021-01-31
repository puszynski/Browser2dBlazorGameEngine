namespace GameLibrary.GameModels.Base
{
    public abstract class LivingBeingBase
    {
        protected int NameToDisplay { get; set; }

        public string ImgSrc { get; set; }
        public int ImgTileSize { get; set; } = 32;

        public int X { get; set; } //todo => validate + send to client + (in background async save to db)
        public int Y { get; set; }
        public string X_toDisplayPx { get { return (X - (ImgTileSize / 2)) * GlobalGameData.PixelSize + "px"; } }
        public string Y_toDisplayPx { get { return (Y - (ImgTileSize / 2)) * GlobalGameData.PixelSize + "px"; } }

        protected bool IsAlive { get; set; } = true;
        protected int LifeMax { get; set; }
        protected int LifeCurrent { get; set; }
        protected int LifeRegenerationSpeed { get; set; }
        protected bool IsRegenerationOn { get; set; } = true;
        protected int Speed { get; set; }        // TODO PORÓB PROGI JAK W D2 - PRZY JAKIŚ PKT SĄ PRZESKOKI SZYBKOSCI (ZEBY OPTYMALIZOWAC OBLICZENIA)
        protected int Level { get; set; }

        protected int Armor { get; set; }

        public abstract void StatsUpdate(bool isNight);


        protected bool IsAliveCheck()
        {
            if (LifeCurrent <= 0)
            {
                IsAlive = false;
                return false;
            }

            return true;
        }

        protected void TryRegenerateLife()
        {
            if (IsRegenerationOn && LifeCurrent < LifeMax)
                LifeCurrent += LifeRegenerationSpeed;
        }        


    }
}
