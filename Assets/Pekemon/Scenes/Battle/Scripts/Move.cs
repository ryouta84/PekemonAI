using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon.Battle
{
    public interface IMove
    {
        // わざの実行
        void Execute(Pekemon myself, Pekemon target);

        // わざの命中判定（true：命中）
        bool Hits();

        string MoveName
        {
            get;
        }
    }

    /// <summary>
    /// 攻撃技の基底クラス
    /// </summary>
    abstract class AttackBase : IMove
    {
        public int Power
        {
            get;
            protected set;
        }
        public string MoveName
        {
            get;
            protected set;
        }

        public int Accuracy
        {
            get;
            protected set;
        }

        public MovePriority Priority
        {
            get;
            protected set;
        }

        /// <summary>
        /// ダメージを与える以外の効果がある場合はオーバーライドする。
        /// </summary>
        /// <param name="myself">技をだすペケモン</param>
        /// <param name="target">技を受けるペケモン</param>
        public void Execute(Pekemon myself, Pekemon target)
        {
            Attack(target);
            AddEffect(myself, target);
        }

        private void Attack(Pekemon target)
        {
            Debug.Log(MoveName);
            target.Damaged(Power);
        }

        /// <summary>
        /// 技の追加効果があればオーバーライドする。
        /// </summary>
        /// <param name="myself">攻撃側</param>
        /// <param name="target">対象</param>
        protected virtual void AddEffect(Pekemon myself, Pekemon target)
        {
            
        }

        /// <summary>
        /// 技の命中判定を行う。
        /// </summary>
        /// <returns>true : 命中</returns>
        virtual public bool Hits()
        {
            return true;
        }
    }

    class QuickAttack : AttackBase
    {
        static IMove _instance;
        public static IMove Instance
        {
            get
            {
                return _instance ?? new QuickAttack();
            }
        }
        private QuickAttack()
        {
            base.MoveName = "でんこうせっか";
            base.Power = 30;
            base.Priority = MovePriority.high;
        }
    }

    class Thunderbolt : AttackBase
    {
        static IMove _instance;

        public static IMove Instance
        {
            get
            {
                return _instance ?? new Thunderbolt();
            }
        }
        private Thunderbolt()
        {
            base.MoveName = "10まんボルト";
            base.Power = 90;
            base.Priority = MovePriority.middle;
        }
    }

    /// <summary>
    /// 追加効果のテスト用の技
    /// </summary>
    class TestMove : AttackBase
    {
        static IMove _instance;

        public static IMove Instance
        {
            get
            {
                return _instance ?? new TestMove();
            }
        }

        private TestMove()
        {
            base.MoveName = "テスト用技";
            base.Power = 50;
            base.Priority = MovePriority.middle;
        }

        protected override void AddEffect(Pekemon myself, Pekemon target)
        {
            // 追加効果
            var randomDamage = (int)Random.Range(1, 10);
            target.Damaged(randomDamage);
            Debug.Log("追加効果で" + randomDamage + "ダメージを与えた！");
        }
    }

    // 技の優先度
    public enum MovePriority
    {
        low,
        middle,
        high,
    }
}