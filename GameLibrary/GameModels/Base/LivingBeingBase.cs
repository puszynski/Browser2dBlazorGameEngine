namespace GameLibrary.GameModels.Base
{
    public abstract class LivingBeingBase
    {
        protected int NameToDisplay { get; set; }

        public int X { get; set; } //todo => validate + send to client + (in background async save to db)
        public int Y { get; set; }
        public string X_withPixelUnit { get { return X + "px"; } }
        public string Y_withPixelUnit { get { return Y + "px"; } }

        protected bool IsAlive { get; set; } = true;
        protected int LifeMax { get; set; }
        protected int LifeCurrent { get; set; }
        protected int LifeRegenerationSpeed { get; set; }
        protected bool IsRegenerationOn { get; set; } = true;
        protected int Speed { get; set; }        
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
