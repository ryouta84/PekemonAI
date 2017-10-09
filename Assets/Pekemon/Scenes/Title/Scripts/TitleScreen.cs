using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Pokemon.Title
{
    public class TitleScreen : MonoBehaviour
    {
        // インスペクターで点滅させるTextを設定しておく。
        public Text blinkText;
        private Color textMessageColor;
        // Use this for initialization
        void Start()
        {
            textMessageColor = GameObject.Find("TextMessage").GetComponent<Text>().color;
        }

        // Update is called once per frame
        void Update()
        {
            textMessageColor.a = Mathf.PingPong(Time.time, 1);
            blinkText.color = textMessageColor;
        }
    }
}