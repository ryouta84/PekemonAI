using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon.Battle
{
    public class Pekemon : MonoBehaviour
    {
        public string pekemonName;
        public PekemonType type1;
        public PekemonType type2;

        // 覚えているわざのリスト
        private IList<IMove> _moveList;
        public IList<IMove> MoveList
        {
            get
            {
                return _moveList;
            }
            set
            {
                _moveList = value;
            }
        }
        // ステータス
        public BaseStats baseStats;
        public Stats stats;
        int level;
        int _HP = 150;
        public int HP
        {
            get
            {
                return (_HP >= 1) ? _HP : (int)0;
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

        void Awake()
        {
            Debug.Log("ペケモンを繰り出した！");
        }

        public void Init(IMove[] moves)
        {
            MoveList = new List<IMove>();
            foreach (var move in moves)
            {
                MoveList.Add(move);
            }
        }
        public void DoMove(int moveNum, Pekemon target)
        {
            IMove move = MoveList[moveNum];
            if (move.Hits())
            {
                MoveList[moveNum].Execute(this, target);
            }
        }
    }

    // 種族値クラス
    public class BaseStats
    {
        public BaseStats(int hp, int atk, int def, int spAtk, int spDef, int spd)
        {
            baseHP = hp;
            baseAttack = atk;
            baseDefense = def;
            baseSpAtk = spAtk;
            baseSpDef = spDef;
            baseSpeed = spd;
        }
        public readonly int baseHP;
        public readonly int baseAttack;
        public readonly int baseDefense;
        public readonly int baseSpAtk;
        public readonly int baseSpDef;
        public readonly int baseSpeed;
    }

    public class Stats
    {
        BaseStats baseStats;
        int level;
        public int HP
        {
            get
            {
                return baseStats.baseHP + level;
            }
        }

        public int ATK
        {
            get
            {
                return baseStats.baseAttack + level;
            }
        }

        public int DEF
        {
            get
            {
                return baseStats.baseDefense + level;
            }
        }

        public int SPATK
        {
            get
            {
                return baseStats.baseSpAtk + level;
            }
        }

        public int SPDEF
        {
            get
            {
                return baseStats.baseSpDef + level;
            }
        }

        public int SPD
        {
            get
            {
                return baseStats.baseSpeed + level;
            }
        }
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

