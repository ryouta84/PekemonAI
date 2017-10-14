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

    abstract class Attack : IMove
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

        public virtual int Accuracy
        {
            get;
            protected set;
        }

        public MovePriority Priority
        {
            get;
            protected set;
        }

        virtual public void Execute(Pekemon myself, Pekemon target)
        {
            Debug.Log(MoveName);
            target.HP -= Power;
        }

        virtual public bool Hits()
        {
            return true;
        }
    }

    public enum MovePriority
    {
        low,
        middle,
        high,
    }

    // わざの効果を表すクラス
    class QuickAttack : Attack
    {
        static QuickAttack _instance;
        public static QuickAttack Instance
        {
            get
            {
                if(_instance == null) _instance = new QuickAttack();
                return _instance;
            }
        }
        private QuickAttack()
        {
            MoveName = "でんこうせっか";
            Power = 30;
            Priority = MovePriority.middle;
        }
    }

    class Thunderbolt : Attack
    {
        static Thunderbolt _instance;

        public static Thunderbolt Instance
        {
            get
            {
                if(_instance == null) _instance = new Thunderbolt();
                return _instance;
            }
        }
        private Thunderbolt()
        {
            MoveName = "10まんボルト";
            Power = 90;
            Priority = MovePriority.middle;
        }
    }
}