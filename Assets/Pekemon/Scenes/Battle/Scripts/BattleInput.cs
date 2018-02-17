using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Pekemon.Battle
{
    /// <summary>
    /// アタッチしたペケモンの入力を待つ
    /// </summary>
    public class BattleInput : MonoBehaviour, IInput
    {
        InputData inputData = new InputData();

        public InputData GetInput()
        {
            GetInputedPekemon();
            return inputData;
        }

        public void GetInputedPekemon()
        {
            inputData.movePekemon = gameObject.name;
        }

        public void SetInput(int moveId, string targetName)
        {
            inputData.selectedMoveId = moveId;
            inputData.moveTarget = targetName;
        }

        public void Init()
        {
            this.inputData.selectedMoveId = -1;
            this.inputData.moveTarget = string.Empty;
        }
    }
}