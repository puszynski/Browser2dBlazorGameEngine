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
        public string ImgSrc { get; set; }
        public int Age { get; set; }

        public string MapID { get; set; }        


        public List<int> HeldKeysDirestions { get; set; }
        public bool Walking { get; set; } = false;
        public EDirection Facing { get; set; }

        public Player() : base(ECharacterClass.None,
                               1,
                               50,
                               50,
                               50)
        {
            HeldKeysDirestions = new List<int>();
            Facing = EDirection.Down;
        }

        //todo move Move() into UpdateInGameLoop()
        public void Move()
        {
            if (HeldKeysDirestions.Any())
            {
                if (!ValidateMode())
                    return;                

                switch ((EKeysDirections)HeldKeysDirestions.First())
                {
                    case EKeysDirections.Up:
                        Y -= Speed;
                        break;
                    case EKeysDirections.Down:
                        Y += Speed;
                        break;
                    case EKeysDirections.Left:
                        X -= Speed;
                        break;
                    case EKeysDirections.Right:
                        X += Speed;
                        break;
                    default:
                        break;
                }
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
