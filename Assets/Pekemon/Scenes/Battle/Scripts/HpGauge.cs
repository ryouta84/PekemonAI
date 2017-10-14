using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Pekemon.Battle
{
    public class HpGauge : MonoBehaviour
    {

        Image gaugeImage;
        Text hpText;
        GameObject myPekemon = null;
        int maxHP = 0;
        // Use this for initialization
        void Awake()
        {
            gaugeImage = GetComponent<Image>();
            hpText = gaugeImage.transform.Find("Text").GetComponent<Text>();
        }
        void Start()
        {
            myPekemon = GameObject.Find("FightingPekemon");
            maxHP = myPekemon.GetComponent<Pekemon>().HP;
        }

        // Update is called once per frame
        void Update()
        {
            gaugeImage.fillAmount = (float)myPekemon.GetComponent<Pekemon>().HP / (float)maxHP;
            hpText.text = myPekemon.GetComponent<Pekemon>().HP.ToString();
        }
    }
}