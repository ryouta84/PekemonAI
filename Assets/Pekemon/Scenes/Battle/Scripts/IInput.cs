using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pekemon.Battle
{
    public interface IInput
    {
        InputData GetInput();
        void GetInputedPekemon();
    }

    public class InputData
    {
        public string moveTarget;
        public string movePekemon;
        public int selectedMoveId = -1;

        public bool IsInputed
        {
            get
            {
                if(selectedMoveId == -1)
                {
                    return false;
                }

                return true;
            }
        }
    }
}