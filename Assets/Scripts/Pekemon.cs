using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon
{
    public class Pekemon : MonoBehaviour
    {
        public string pekemonName;
        public PekemonType type1;
        public PekemonType type2;

        // 覚えているわざのリスト
        public IMove[] movesList = new IMove[4];

        // ステータス
        public BaseStats baseStats;
        short level;
        short _HP = 150;
        public short HP
        {
            get
            {
                return (_HP >= 1) ? _HP : (short)0;
            }
            set
            {
                if (value >= 0)
                {
                    _HP = value;
                }
                else
                {
                    _HP = 0;
                }
            }
        }

        // 状態異常
        bool isBurn;
        bool isFreeze;
        bool isParalysis;
        bool isPoison;
        bool isBadPoison;
        bool isSleep;
        bool IsFainting
        {
            get
            {
                return (HP == 0) ? true : false;
            }
        }

        public void DoMove(IMove move, Pekemon target)
        {
            if (Hits(move.Accuracy))
            {
                // わざの命中判定は必ず実行するのでわざの効果だけを委譲する。
                move.DoMove(this, target);
            }
        }
        private bool Hits(short accuracy)
        {
            bool isHit = true;

            return isHit;
        }
    }

    // 種族値クラス
    public class BaseStats
    {
        public BaseStats(short hp, short atk, short def, short spAtk, short spDef, short spd)
        {
            baseHP = hp;
            baseAttack = atk;
            baseDefense = def;
            baseSpAtk = spAtk;
            baseSpDef = spDef;
            baseSpeed = spd;
        }
        public readonly short baseHP;
        public readonly short baseAttack;
        public readonly short baseDefense;
        public readonly short baseSpAtk;
        public readonly short baseSpDef;
        public readonly short baseSpeed;
    }

    public enum PekemonType
    {
        Normal,
        Fiting,
        Flying,
        Poison,
        Ground,
        Rock,
        Bug,
        Ghost,
        Steel,
    }
}

