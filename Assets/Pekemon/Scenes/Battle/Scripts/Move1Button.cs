using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Pekemon.Battle
{
    public class Move1Button : MonoBehaviour
    {
		Pekemon pekemon;
		GameObject buttonText;
        // Use this for initialization
        void Start()
        {
            pekemon = GameObject.Find("FightingPekemon").GetComponent<Pekemon>();
			buttonText = gameObject.transform.Find("Text").gameObject;
			buttonText.GetComponent<Text>().text = pekemon.MoveList[0].MoveName;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnClick()
        {
			pekemon.DoMove(0, pekemon);
        }
    }
}