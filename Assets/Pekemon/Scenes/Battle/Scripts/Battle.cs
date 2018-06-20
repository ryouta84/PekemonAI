using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon.Battle
{
    public sealed class Battle
    {
        private static Battle instance;

        public static Battle Instance
        {
            get
            {
                if(instance == null)
                {
                    return new Battle();
                }

                return instance;
            }
        }

        private Battle()
        {

        }

        public void TurnStart()
        {

        }

        /// <summary>
        /// バトル中のステータスを計算して返却
        /// 技や特性などを考慮して計算する。
        /// </summary>
        /// <returns>計算後のStatsオブジェクト</returns>
        /// <param name="stats">Stats.</param>
        private Stats CalcBattlingStats(Pekemon pekemon)
        {
            var battilingStats = new Stats();

            return battilingStats;
        }
    }
}
