using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon.Battle
{
    public class Pekemon : MonoBehaviour
    {
        public string pekemonName;

        // テスト
        [SerializeField]
        PicaStats baseStats = null;

        // 覚えているわざのリスト
        public IList<IMove> MoveList
        {
            get; private set;
        }

        // テスト
        public Stats stats;
        public int level;

        int _currentHp = 0;
        public int CurrentHp
        {
            get
            {
                return _currentHp;
            }
            private set
            {
                // 現在HPが負数にならないように
                _currentHp = value >= 0 ? value : 0;
            }
        }

        /// <summary>
        /// ダメージを受ける。
        /// </summary>
        /// <returns>瀕死状態</returns>
        /// <param name="damageValue">与えるダメージ量</param>
        public bool Damaged(int damageValue)
        {
            CurrentHp -= damageValue;
            return IsFainting;
        }

        // true：瀕死状態
        public bool IsFainting
        {
            get
            {
                return CurrentHp <= 0 ? true : false;
            }
        }

        void Awake()
        {
            this.stats = new Stats();
            stats.level = this.level;

            // マスタデータ種族値を設定
            if (this.baseStats != null)
            {
                this.stats.baseStats = this.baseStats.BaseStats;
                this.CurrentHp = this.stats.MAXHP;
            }
            else
            {
                Debug.Log("種族値マスタデータが設定されていない");
            }
        }

        void Start()
        {
            Debug.Log(this.gameObject.name + gameObject.GetComponent<Pekemon>().pekemonName + "を繰り出した！");
        }

        /// <summary>
        /// 変化するステータス(レベル、技など)を設定する。
        /// </summary>
        /// <param name="moves">技のリスト</param>
        public void Init(IList<IMove> moves)
        {
            MoveList = moves;
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

    /// <summary>
    /// 最終的にプレイヤーが見れるステータス
    /// </summary>
    public class Stats
    {
        public BaseStats baseStats;
        public int level;
        public int MAXHP
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

