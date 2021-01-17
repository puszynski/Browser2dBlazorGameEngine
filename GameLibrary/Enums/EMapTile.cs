namespace GameLibrary.Enums
{
    public enum EMapTile
    {
        //100-199 fast
        Pavement = 100,
        Footpath = 101,

        //200-299 normal
        Grass = 200,
        Sand = 201,

        //300-399 slow
        HighGrass = 300,
        SandDune = 301,

        //400-449 very slow
        SwampTrunk = 400,
        VerHighSnow = 401,
        SoftBushes = 402,
        WaterSwimming = 403,

        //450-499 with dmg + very slow
        Lava = 900,
        BushesSoftThorny = 901,

        //500 - 899 blockade
        Tree = 500,
        Mountain = 501,
        BusjesDense = 502,

        //EnterToOtherMap (string == Map.Name)
        MainLand = 1000,
        NoobLand = 1001,
    }
}
