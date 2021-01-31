using GameLibrary.Enums;

namespace GameLibrary.GameModels.Base
{
    public abstract class PlayerBase : LivingBeingBase
    {
        private const int HOW_MANY_TIMES_LIFE_DECREASE_FROM_STARVING = 10;
        private const int NIGHT_BOOSTER_FACTOR = 10;

        protected ECharacterClass CharacterClass { get; set; }
        protected int Experience { get; set; }

        protected int ManaMax { get; set; }
        protected int ManaCurrent { get; set; }
        protected int FoodMax { get; set; }
        public int FoodCurrent { get; set; }
        public int FoodDecrease { get; set; }
        protected int ManaRegenerationSpeed { get; set; }

        /// <summary>
        /// On initializing player from db
        /// </summary>
        public PlayerBase(ECharacterClass characterClass, 
                          int experience, 
                          int lifeCurrent,
                          int manaCurrent,
                          int foodCurrent)
        {
            CharacterClass = characterClass;
            Experience = experience;

            LifeCurrent = lifeCurrent;
            ManaCurrent = manaCurrent;
            FoodCurrent = foodCurrent;

            Level = CalculateLvl(experience);
            Speed = Level;
            //LifeMax = CalculateLifeMax(Level, CharacterClass);
            //ManaMax = CalculateManaMax(Level, CharacterClass);
            //FoodMax = CalculateFoodMax(Level, CharacterClass);
            //LifeRegenerationSpeed = CalculateLifeRegenerationSpeed(Level, CharacterClass);
            //ManaRegenerationSpeed = CalculateManaRegenerationSpeed(Level, CharacterClass);
        }

        public void GetExperience(int experience)
        {
            Experience = experience;

            //if (LvlUp?)
            //    LevelUp();
        }

        private int CalculateLvl(int experience)
        {
            //d2 90 lvl 50% dośw, 99 100%

            return 1;
        }

        private void LevelUp()
        {
            Level++;
            Speed++;
            //LifeMax = CalculateLifeMax(Level, CharacterClass);
            //ManaMax = CalculateManaMax(Level, CharacterClass);
            //FoodMax = CalculateFoodMax(Level, CharacterClass);
            //LifeRegenerationSpeed = CalculateLifeRegenerationSpeed(Level, CharacterClass);
            //ManaRegenerationSpeed = CalculateManaRegenerationSpeed(Level, CharacterClass);
        }

        public override void StatsUpdate(bool isNight) // nie wywołuj co fps (bo będą różne) - wywołuj raz na sec?
        {
            #region life/mana/regeneration
            if (IsAliveCheck())
                return;

            if (FoodCurrent > 0)
            {
                IsRegenerationOn = true;

                if (isNight)
                    FoodCurrent -= FoodDecrease * NIGHT_BOOSTER_FACTOR;
                else
                    FoodCurrent -= FoodDecrease;
            }
            else
            {
                IsRegenerationOn = false;

                if (isNight)
                    LifeCurrent -= (LifeRegenerationSpeed / HOW_MANY_TIMES_LIFE_DECREASE_FROM_STARVING) * NIGHT_BOOSTER_FACTOR;
                else
                    LifeCurrent -= (LifeRegenerationSpeed / HOW_MANY_TIMES_LIFE_DECREASE_FROM_STARVING);
            }

            TryRegenerateLife();
            #endregion
        }

        public void Eat(int kcal)
        {
            if (FoodCurrent < FoodMax)
                FoodCurrent += kcal;

            if (FoodCurrent > FoodMax)
                FoodCurrent = FoodMax;
        }
    }
}
