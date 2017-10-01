using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Pekemon
{
    public class BattleUI : MonoBehaviour
    {

        Image gaugeImage;
        Text hpText;
        GameObject myPekemon = null;
        short maxHP = 0;
        // Use this for initialization
        void Awake()
        {
            
        }
        void Start()
        {
            myPekemon = GameObject.Find("FightingPekemon");
            gaugeImage = GetComponent<Image>();
            hpText = gaugeImage.transform.Find("Text").GetComponent<Text>();
            maxHP = 150;
        }

        // Update is called once per frame
        void Update()
        {
            gaugeImage.fillAmount = (float)myPekemon.GetComponent<Pekemon>().HP / (float)maxHP;
            hpText.text = myPekemon.GetComponent<Pekemon>().HP.ToString();
        }
    }
}