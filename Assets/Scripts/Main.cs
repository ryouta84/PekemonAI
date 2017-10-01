using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pekemon
{
    public class Main : MonoBehaviour
    {
        StateMachine _stateMachine;
        static Main _instance = null;
        public static Main Instance
        {
            get
            {
                return _instance ?? (_instance = FindObjectOfType<Main>());
            }
        }

        public StateMachine stateMachine
        {
            get
            {
                return _stateMachine;
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
            _stateMachine = new StateMachine();
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
            //stateMachine.Change("Title");
        }

        // Update is called once per frame
        void Update()
        {
            stateMachine.Update();
        }
    }
}