using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Pekemon.Battle
{
    public class PlayerMoveButton : MonoBehaviour
    {
        Pekemon pekemon;
        BattleInput waitInput;
		GameObject buttonText;
        public int moveNum = 0;

        // Use this for initialization
        void Start()
        {
            pekemon = GameObject.Find(BattleConstants.BATTLING_PLAYERS_PEKEMON_NAME).GetComponent<Pekemon>();
            waitInput = GameObject.Find(BattleConstants.BATTLING_PLAYERS_PEKEMON_NAME).GetComponent<BattleInput>();
			buttonText = gameObject.transform.Find("Text").gameObject;
			buttonText.GetComponent<Text>().text = pekemon.MoveList[moveNum].MoveName;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnClick()
        {
            waitInput.SetInput(moveNum, BattleConstants.BATTLING_ENEMYS_PEKEMON_NAME);
        }
    }
}