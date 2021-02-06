namespace GameLibrary.Enums
{
    public enum EMapTile
    {
        BlockadeHard = 1,
        BlockadeSoft = 2, //todo in future - small radius in collision (allow partialy to step on filed)

        VerySlowSpeed = 3,
        SlowSpeed = 4,
        NormalSpeed = 5,
        FastSpeed = 6,
        VeryFastSpeed = 7,

        //others surface?
        Ice = 10,
        Water = 11
    }
}
