using GameLibrary.Enums;
using System;

namespace GameLibrary.Logic.Player
{
    public class DataCalculator
    {   
        public int CalculateAge(DateTime birthDate)
        {
            var now = DateTime.UtcNow;
            var days = (now - birthDate).Days;
            return days / 4;  // 400 days == 100 years in game
        }

        public int? CalculateDeathAge(ECharacterClass characterClass, bool isGameCreator = false)
        {
            //todo in future - check after class promotion 

            if (characterClass == ECharacterClass.Elf || isGameCreator)
                return null;

            var rnd = new Random();
            return rnd.Next(90, 101); //90-100
        }

        public EPlayerCharacterStatus SetPlayerStatus(int age, int? ageOfDeath)
        {
            if (ageOfDeath.HasValue && age >= ageOfDeath)
                return EPlayerCharacterStatus.NaturalDeath;

            return EPlayerCharacterStatus.Active;
        }
    }
}
