using GameLibrary.Enums;
using GameLibrary.GameModels.Base;
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

        //todo move Move() into UpdateInGameLoop()
        public void MoveAndSetDircetion()
        {
            if (HeldKeysDirestions.Any())
            {
                if (!ValidateMode())
                    return;

                Walking = true;

                switch ((EKeysDirections)HeldKeysDirestions.Last())
                {
                    case EKeysDirections.Up:
                        Y -= Speed;
                        Facing = EDirection.Up;
                        break;

                    case EKeysDirections.Down:
                        Facing = EDirection.Down;
                        Y += Speed;
                        break;

                    case EKeysDirections.Left:
                        Facing = EDirection.Left;
                        X -= Speed;
                        break;

                    case EKeysDirections.Right:
                        Facing = EDirection.Right;
                        X += Speed;
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

        public bool ValidateMode()
        {
            return true;
            //czy to ma sens??
            //kolizje tu??
        }

        //proba odwiezenia widoku => https://stackoverflow.com/questions/55775060/blazor-component-refresh-parent-when-model-is-updated-from-child-component
    }
}
