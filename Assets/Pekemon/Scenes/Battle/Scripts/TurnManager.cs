using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

namespace Pekemon.Battle
{
    /// <summary>
    /// バトルのターンを管理するクラス
    /// </summary>
    public class TurnManager
    {
        // 場にいるペケモンのリスト
        IList<GameObject> pekemonList = new List<GameObject>();

        // 行動順リスト
        // intは選択された技の番号
        IDictionary<Pekemon, int> actionList = new Dictionary<Pekemon, int>();

        public TurnManager(GameObject playerPekemon, GameObject opponentPekemon)
        {
            this.pekemonList.Add(playerPekemon);
            this.pekemonList.Add(opponentPekemon);

            // ペケモンを行動順リストに追加
            foreach (var pekemon in pekemonList)
            {
                actionList.Add(pekemon.GetComponent<Pekemon>(), -1);
            }
        }

        /// <summary>
        /// ペケモンの次の行動を設定する。
        /// </summary>
        /// <returns><c>true</c>, if next move was set, <c>false</c> otherwise.</returns>
        /// <param name="pekemon">Pekemon.</param>
        /// <param name="moveNum">Move number.</param>
        public bool SetNextMove(Pekemon pekemon, int moveNum)
        {
            if(actionList.ContainsKey(pekemon))
            {
                actionList[pekemon] = moveNum;
                return true;
            }

            return false;
        }

        /// <summary>
        /// 行動順を決定する。すばやさが高い順に行動する。
        /// バトル中のペケモンの行動が選択された後に実行する。
        /// </summary>
        private void SetQueue()
        {
            actionList.OrderByDescending(x => x.Key.stats.SPD);
        }

        /// <summary>
        /// 次の技が入力されている場合、ペケモンの技を実行する
        /// </summary>
        public void Update()
        {
            //入力待ち
            foreach (var pekemon in actionList)
            {
                
            }
        }
    }
}