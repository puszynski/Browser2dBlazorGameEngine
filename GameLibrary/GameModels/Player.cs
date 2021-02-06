using GameLibrary.Enums;
using GameLibrary.GameModels.Base;
using GameLibrary.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace GameLibrary.GameModels
{
    public class Player : PlayerBase
    {
        public string ID { get; set; }        
        public int Age { get; set; }

        public string MapID { get; set; }        


        public List<int> HeldKeysDirestions { get; set; }
        public bool Walking { get; set; }
        public EDirection Facing { get; set; }

        public Player() : base(ECharacterClass.None,
                               1,
                               50,
                               50,
                               50)
        {
            HeldKeysDirestions = new List<int>();
            Facing = EDirection.Down;
            Walking = false;
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

        public bool IsNoColision(int newPositionX, int newPositionY)
        {
            return true;
            //czy to ma sens??
            //kolizje tu??
        }
    }
}
