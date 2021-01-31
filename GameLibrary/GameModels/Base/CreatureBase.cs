using GameLibrary.Enums;

namespace GameLibrary.GameModels.Base
{
    public abstract class CreatureBase : LivingBeingBase
    {
        protected ECreatureSpecies CharacterClass { get; set; }

        /// <summary>
        /// On creating generating
        /// </summary>
        /// <param name="level">should depends on nearby playes count</param>
        public CreatureBase(ECreatureSpecies characterClass, int level)
        {
            CharacterClass = characterClass;
            Level = level;

            //LifeMax = CalculateLifeMax(CharacterClass, Level);
            LifeCurrent = LifeMax;
            //LifeRegenerationSpeed = CalculateLifeRegenerationSpeed(CharacterClass, Level);
        }

        public int ExperienceAfterKill()
        {
            //d2 rules:

            var X = 123;//base monster exp
            var n = 6; //players count
            return X * (n + 1) / 2;
        }

        public override void StatsUpdate(bool isNight)
        {
            //bool isNight => boost monsters;


            #region life/mana/regeneration
            if (IsAliveCheck())
                return;

            TryRegenerateLife();
            #endregion
        }
    }
}
