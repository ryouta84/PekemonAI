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
        public Pekemon pekemon = null;
        int maxHP = 0;
        // Use this for initialization
        void Awake()
        {
            gaugeImage = GetComponent<Image>();
            hpText = gaugeImage.transform.Find("Text").GetComponent<Text>();
        }
        void Start()
        {
            maxHP = pekemon.CurrentHp;
        }

        // Update is called once per frame
        void Update()
        {
            gaugeImage.fillAmount = (float)pekemon.CurrentHp / (float)maxHP;
            hpText.text = pekemon.CurrentHp.ToString();
        }
    }
}