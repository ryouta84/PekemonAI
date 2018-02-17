using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pekemon.Title
{
    public class TitleState : IState
    {
        private static TitleState singleton = new TitleState();
        private TitleState() { }

        public static TitleState GetInstance()
        {
            return singleton;
        }
        public void OnEnter()
        {
            Debug.Log("TITLE START!");
        }

        public void OnExit()
        {
            Debug.Log("EXIT TITLE");
        }

        public void Render()
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("Pekemon/Scenes/Battle/Battle");
            }
        }
    }
}
