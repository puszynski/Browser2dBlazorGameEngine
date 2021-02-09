using GameLibrary.DomainModels;
using GameLibrary.GameModels;
using GameLibrary.Logic.Player;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Logic.GameInitializer
{
    public class CreateNewPlayer
    {
        readonly DataCalculator _dataCalculator;

        public CreateNewPlayer()
        {
            _dataCalculator = new DataCalculator();
        }

        public async Task<GameLibrary.GameModels.Player> Execute(string characterName)
        {
            var playerCharacter = new PlayerCharacter()
            {
                BirthDate = new System.DateTime(2020, 12, 25),
                CharacterClass = Enums.ECharacterClass.Shaman,
                ID = characterName,
                ImageSrc = "/images/DemoRpgCharacter.png",
                Speed = 1,

                MapID = "DemoLand",
                PositionOnMapPixelsX = (int)6.5 * GlobalGameData.TileSize,
                PositionOnMapPixelsY = (int)3.5 * GlobalGameData.TileSize,
            };

            playerCharacter.Age = _dataCalculator.CalculateAge(playerCharacter.BirthDate);
            playerCharacter.AgeOfDeath = _dataCalculator.CalculateDeathAge(playerCharacter.CharacterClass, true);
            playerCharacter.PlayerStatus = _dataCalculator.SetPlayerStatus(playerCharacter.Age, playerCharacter.AgeOfDeath);


            return new GameLibrary.GameModels.Player()
            {
                ID = playerCharacter.ID,
                Age = playerCharacter.Age,
                ImgSrc = playerCharacter.ImageSrc,
                X = playerCharacter.PositionOnMapPixelsX * GlobalGameData.PixelSize,
                Y = playerCharacter.PositionOnMapPixelsY * GlobalGameData.PixelSize,
                MapID = playerCharacter.MapID,
            };
        }
    }
}
