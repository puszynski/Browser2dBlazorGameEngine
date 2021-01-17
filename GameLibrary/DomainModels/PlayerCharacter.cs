using GameLibrary.Enums;
using System;

namespace GameLibrary.DomainModels
{
    public class PlayerCharacter
    {
        public string ID { get; set; }
        public bool IsMainPlayer { get; set; }
        public string ImageSrc { get; set; }

        public ECharacterClass CharacterClass { get; set; }
        public double Speed { get; set; }

        public DateTime BirthDate { get; set; }
        public int? AgeOfDeath { get; set; }
        public int Age { get; set; }
        public EPlayerCharacterStatus PlayerStatus { get; set; }

        public string MapID { get; set; }
        public int PositionOnMapPixelsX { get; set; }
        public int PositionOnMapPixelsY { get; set; }
    }
}