using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary.Logic.Calculations
{
    public class ExperienceEarned
    {
        /// experience depends from player-monster lvl
        public int Execute(int playerLvl, int monsterLvl, int monsterExperience)
        {
            var levelDifference = Math.Abs(playerLvl - monsterLvl);

            //d2 => https://diablo2.diablowiki.net/Guide:Diablo_2_Level_Up_Guide_v1.10


            // slow down high lvl players
            if (playerLvl > 100) 
            {
                //monsterExperience = monsterExperience - 
            }

            if(playerLvl < 30)
            {
                if(levelDifference < 2)
                    return monsterExperience;
                else if(levelDifference < 3)
                    return (int)(monsterExperience * 0.9);
                else if(levelDifference < 4)
                    return (int)(monsterExperience * 0.8);
                else if(levelDifference < 5)
                    return (int)(monsterExperience * 0.7);
                else if(levelDifference < 7)
                    return (int)(monsterExperience * 0.4);
                return (int)(monsterExperience * 0.1);
            }
            else
            {
                if(levelDifference < 6)
                    return monsterExperience;
                else if(levelDifference < 8)
                    return (int)(monsterExperience * 0.8);
                else if(levelDifference < 10)
                    return (int)(monsterExperience * 0.7);
                else if(levelDifference < 12)
                    return (int)(monsterExperience * 0.6);
                else if(levelDifference < 20)
                    return (int)(monsterExperience * 0.5);
                return (int)(monsterExperience * 0.1);
            }
            //1 - more experience if player and monster lvl are close (prevent high lvl exp on low monstaers, prevent low lvl to exp with gih players)
            //https://diablo2.diablowiki.net/Experience
            //2 - monster exp (and stats) depends on players count nearby - calculate them inside CrateureBase classes
        }
    }
}
