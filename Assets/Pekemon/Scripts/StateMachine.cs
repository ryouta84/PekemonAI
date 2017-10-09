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
        // LoadSceneするとロードしたシーンの状態に自動で遷移する。
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
