using GameLibrary.DomainModels;
using GameLibrary.GameModels;
using GameLibrary.Logic.Player;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLibrary.Logic.GameInitializer
{
    public class CreateNewPlayers
    {
        readonly DataCalculator _dataCalculator;

        public CreateNewPlayers()
        {
            _dataCalculator = new DataCalculator();
        }

        public async Task<List<GameLibrary.GameModels.Player>> Execute(string playerFirstAndSecondName)
        {
            //temp - pseudo players of list from map - pseudo from DB

            var playersList = new List<PlayerCharacter>() { };

            var mainPlayer = new PlayerCharacter()
            {
                BirthDate = new System.DateTime(2020, 12, 25),
                CharacterClass = Enums.ECharacterClass.Shaman,
                ID = playerFirstAndSecondName,
                IsMainPlayer = true,
                ImageSrc = "/images/DemoRpgCharacter.png",
                Speed = 1,

                MapID = "DemoLand",
                PositionOnMapPixelsX = (int)6.5 * GlobalGameData.TileSize,
                PositionOnMapPixelsY = (int)3.5 * GlobalGameData.TileSize,
            };

            mainPlayer.Age = _dataCalculator.CalculateAge(mainPlayer.BirthDate);
            mainPlayer.AgeOfDeath = _dataCalculator.CalculateDeathAge(mainPlayer.CharacterClass, true);
            mainPlayer.PlayerStatus = _dataCalculator.SetPlayerStatus(mainPlayer.Age, mainPlayer.AgeOfDeath);

            playersList.Add(mainPlayer);

            var otherPlayer1 = new PlayerCharacter()
            {
                BirthDate = new System.DateTime(2021, 01, 10),
                CharacterClass = Enums.ECharacterClass.None,
                ID = "Test Static",
                IsMainPlayer = false,
                ImageSrc = "/images/DemoRpgCharacter2.png",
                Speed = 1,

                MapID = "DemoLand",
                PositionOnMapPixelsX = (int)3.5 * GlobalGameData.TileSize,
                PositionOnMapPixelsY = (int)3.5 * GlobalGameData.TileSize,
            };

            otherPlayer1.Age = _dataCalculator.CalculateAge(mainPlayer.BirthDate);
            otherPlayer1.AgeOfDeath = _dataCalculator.CalculateDeathAge(mainPlayer.CharacterClass, true);
            otherPlayer1.PlayerStatus = _dataCalculator.SetPlayerStatus(mainPlayer.Age, mainPlayer.AgeOfDeath);

            playersList.Add(otherPlayer1);



            var players = playersList
            .Select(x => new GameLibrary.GameModels.Player()
            {
                ID = x.ID,
                Age = x.Age,
                ImgSrc = x.ImageSrc,
                X = x.PositionOnMapPixelsX * GlobalGameData.PixelSize,
                Y = x.PositionOnMapPixelsY * GlobalGameData.PixelSize,
                MapID = x.MapID,
            })
            .ToList();

            return players;
        }
    }
}
