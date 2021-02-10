using GameLibrary.Enums;
using GameLibrary.GameModels.Base;
using GameLibrary.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace GameLibrary.GameModels
{
    public class Player : LivingBeingBase
    {
        private const int HOW_MANY_TIMES_LIFE_DECREASE_FROM_STARVING = 10;
        private const int NIGHT_BOOSTER_FACTOR = 10;

        public string ID { get; set; }        
        public int Age { get; set; }

        public string MapID { get; set; }        


        public List<int> HeldKeysDirestions { get; set; }
        public bool Walking { get; set; }
        public EDirection Facing { get; set; }

        /// <summary>
        /// Additional
        /// </summary>
        private ECharacterClass CharacterClass { get; set; }
        private int Experience { get; set; }

        private int ManaMax { get; set; }
        private int ManaCurrent { get; set; }
        private int FoodMax { get; set; }
        private int FoodCurrent { get; set; }
        private int FoodDecrease { get; set; }
        private int ManaRegenerationSpeed { get; set; }

        public Player()
        {
            HeldKeysDirestions = new List<int>();
            Facing = EDirection.Down;
            Walking = false;

            ///
            CharacterClass = ECharacterClass.None;
            Experience = 1;

            LifeCurrent = 50;
            ManaCurrent = 50;
            FoodCurrent = 50;

            Level = CalculateLvl(Experience);
            Speed = Level;
            //LifeMax = CalculateLifeMax(Level, CharacterClass);
            //ManaMax = CalculateManaMax(Level, CharacterClass);
            //FoodMax = CalculateFoodMax(Level, CharacterClass);
            //LifeRegenerationSpeed = CalculateLifeRegenerationSpeed(Level, CharacterClass);
            //ManaRegenerationSpeed = CalculateManaRegenerationSpeed(Level, CharacterClass);
        }

        public void MoveAndSetDirectionInGameLoop(List<List<int>> mapTileMatrix)
        {
            if (HeldKeysDirestions.Any())
            {        
                switch ((EKeysDirections)HeldKeysDirestions.Last())
                {
                    case EKeysDirections.Up:
                        if (MoveValidator.IsColision(X, Y - Speed, mapTileMatrix))
                            break;
                        Y -= Speed;
                        Facing = EDirection.Up;
                        Walking = true;
                        break;

                    case EKeysDirections.Down:
                        if (MoveValidator.IsColision(X, Y + Speed, mapTileMatrix))
                            break;
                        Y += Speed;
                        Facing = EDirection.Down;
                        Walking = true;
                        break;

                    case EKeysDirections.Left:
                        if (MoveValidator.IsColision(X - Speed, Y, mapTileMatrix))
                            break;
                        X -= Speed;
                        Facing = EDirection.Left;
                        Walking = true;
                        break;

                    case EKeysDirections.Right:
                        if (MoveValidator.IsColision(X + Speed, Y, mapTileMatrix))
                            break;
                        X += Speed;
                        Facing = EDirection.Right;
                        Walking = true;
                        break;

                    default:
                        break;
                }
            }
            else
            {
                Walking = false;
            }

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
