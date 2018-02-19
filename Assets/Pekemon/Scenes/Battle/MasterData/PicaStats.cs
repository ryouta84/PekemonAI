using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon.Battle
{
    public class PicaStats : ScriptableObject
    {
        [SerializeField]
        private PekemonType type1;
        [SerializeField]
        private PekemonType type2;
        [SerializeField]
		private int baseHP;
        [SerializeField]
		private int baseAttack;
        [SerializeField]
		private int baseDefense;
        [SerializeField]
		private int baseSpAtk;
        [SerializeField]
		private int baseSpDef;
        [SerializeField]
		private int baseSpeed;

        private BaseStats _baseStats;
        public BaseStats BaseStats
        {
            get
            {
                _baseStats = _baseStats ?? new BaseStats(baseHP, baseAttack, baseDefense, baseSpAtk, baseSpDef, baseSpeed);
                return _baseStats;
            }
        }


    }
}