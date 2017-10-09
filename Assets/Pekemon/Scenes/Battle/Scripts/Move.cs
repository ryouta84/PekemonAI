using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon.Battle
{
    public interface IMove
    {
        short Accuracy
        {
            get;
        }
        void DoMove(Pekemon myself, Pekemon target);
    }

    // わざの効果を表すクラス
    class Attack : IMove
    {
        short power;
        short accuracy;
        short priority;

        public short Accuracy
        {
            get { return accuracy; }
        }

        public Attack(short p, short a, short pri)
        {
            power = p;
            accuracy = a;
            priority = pri;
        }

        public void DoMove(Pekemon myself, Pekemon target)
        {
            Debug.Log("ATTACK!");
        }
    }

}