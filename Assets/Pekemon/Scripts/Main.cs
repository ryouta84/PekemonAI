using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Pekemon.Title;
using Pekemon.Battle;

namespace Pekemon
{
    public class Main : MonoBehaviour
    {
        StateMachine stateMachine;
        static Main _instance = null;
        public static Main Instance
        {
            get
            {
                return _instance ?? (_instance = FindObjectOfType<Main>());
            }
        }
        void Awake()
        {
            if (this != Instance)
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);

            // ステートマシーンの初期化
            stateMachine = new StateMachine();
            stateMachine.Add("Title", TitleState.GetInstance());
            stateMachine.Add("Battle", BattleState.GetInstance());
            SceneManager.sceneLoaded += stateMachine.OnSceneLoaded;
        }

        void OnDestroy()
        {
            if (this == Instance)
            {
                _instance = null;
            }
        }
        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            // Main Loop
            stateMachine.Update();
        }
    }
}