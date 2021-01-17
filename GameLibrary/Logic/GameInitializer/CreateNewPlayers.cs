using GameLibrary.DomainModels;
using GameLibrary.Logic.Player;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameLibrary.Logic.GameInitializer
{
    public class CreateNewPlayers
    {
        private readonly DataCalculator _dataCalculator;
        private const int TILE_SIZE = 16;

        public CreateNewPlayers()
        {
            _dataCalculator = new DataCalculator();
        }

        public async Task<List<GameLibrary.GameModels.Player>> Execute(string playerFirstAndSecondName, int pixelSize)
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
                PositionOnMapPixelsX = (int)6.5 * TILE_SIZE,
                PositionOnMapPixelsY = (int)3.5 * TILE_SIZE,
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
                PositionOnMapPixelsX = (int)3.5 * TILE_SIZE,
                PositionOnMapPixelsY = (int)3.5 * TILE_SIZE,
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
                X = x.PositionOnMapPixelsX * pixelSize,
                Y = x.PositionOnMapPixelsY * pixelSize,
                MapID = x.MapID,
            })
            .ToList();

            return players;
        }
    }
}
