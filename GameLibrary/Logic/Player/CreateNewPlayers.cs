using GameLibrary.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameLibrary.Logic.Player
{
    public class CreateNewPlayers
    {
        private readonly DataCalculator _dataCalculator;
        private const int TILE_SIZE = 16;

        public CreateNewPlayers()
        {
            _dataCalculator = new DataCalculator();
        }

        public async Task<List<PlayerCharacter>> Execute(string playerFirstName, string playerLastName)
        {
            //temp - pseudo players of list from map

            var playersList = new List<PlayerCharacter>() { };

            var mainPlayer = new PlayerCharacter()
            {
                BirthDate = new System.DateTime(2020, 12, 25),
                CharacterClass = Enums.ECharacterClass.Shaman,
                FirstName = playerFirstName,
                LastName = playerLastName,
                IsMainPlayer = true,
                ImageSrc = "/images/DemoRpgCharacter.png",
                MapID = "demo",
                PositionOnMapPixelsX = (int)6.5 * TILE_SIZE,
                PositionOnMapPixelsY = (int)3.5 * TILE_SIZE,
                Speed = 1
            };

            mainPlayer.Age = _dataCalculator.CalculateAge(mainPlayer.BirthDate);
            mainPlayer.AgeOfDeath = _dataCalculator.CalculateDeathAge(mainPlayer.CharacterClass, true);
            mainPlayer.PlayerStatus = _dataCalculator.SetPlayerStatus(mainPlayer.Age, mainPlayer.AgeOfDeath);

            playersList.Add(mainPlayer);

            var otherPlayer1 = new PlayerCharacter()
            {
                BirthDate = new System.DateTime(2021, 01, 10),
                CharacterClass = Enums.ECharacterClass.None,
                FirstName = "Test",
                LastName = "Bot",
                IsMainPlayer = false,
                ImageSrc = "/images/DemoRpgCharacter2.png",
                MapID = "demo",
                PositionOnMapPixelsX = (int)3.5 * TILE_SIZE,
                PositionOnMapPixelsY = (int)3.5 * TILE_SIZE,
                Speed = 1
            };

            otherPlayer1.Age = _dataCalculator.CalculateAge(mainPlayer.BirthDate);
            otherPlayer1.AgeOfDeath = _dataCalculator.CalculateDeathAge(mainPlayer.CharacterClass, true);
            otherPlayer1.PlayerStatus = _dataCalculator.SetPlayerStatus(mainPlayer.Age, mainPlayer.AgeOfDeath);

            playersList.Add(otherPlayer1);


            return playersList;
        }
    }
}
