using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pekemon
{
    public interface IState
    {
        void Update();
        void Render();
        void OnEnter();
        void OnExit();
    }

    public class StateMachine
    {
        IDictionary<string, IState> states = new Dictionary<string, IState>();
        IState currentState = new EmptyState();

        public void Update()
        {
            currentState.Update();
        }

        public void Render()
        {
            currentState.Render();
        }

        // シーン遷移後に呼ばれる
        public void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
        {
            currentState.OnExit();
            currentState = states[scene.name];
            currentState.OnEnter();
        }

        public void Add(string stateName, IState state)
        {
            states.Add(stateName, state);
        }
    }

    class TitleState : IState
    {
        private static TitleState singleton = new TitleState();
        private TitleState(){}

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
            if(Input.anyKeyDown)
            {
                SceneManager.LoadScene("Scenes/Battle");
            }
        }
    }
    class EmptyState : IState
    {
        public void OnEnter()
        {
            throw new System.NotImplementedException();
        }

        public void OnExit()
        {
            
        }

        public void Render()
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }
    }

}
