using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Pekemon.Battle
{
    public class BattleState : IState
    {
        BattleInput playerInput;
        BattleInput aIInput;
        Pekemon myPekemon;
        Pekemon oppnentPekemon;

        private static BattleState singleton = new BattleState();
        private BattleState() { }
        public static BattleState GetInstance()
        {
            return singleton;
        }

        public void OnEnter()
        {
            Debug.Log("BATTLE START!");

            // ペケモンの生成、設定
            CreatePekemon();

            // UI成生
            CreateUI();

            // 入力設定
            playerInput = GameObject.Find(BattleConstants.BATTLING_PLAYERS_PEKEMON_NAME).GetComponent<BattleInput>();
            aIInput = GameObject.Find(BattleConstants.BATTLING_ENEMYS_PEKEMON_NAME).GetComponent<BattleInput>();
        }

        public void OnExit()
        {
            Debug.Log("EXIT BATTLE");
        }

        public void Render()
        {
            throw new System.NotImplementedException();
        }

        public void Update()
        {
            // 入力待ち
            InputData inputData = this.playerInput.GetInput();
            if (!inputData.IsInputed)
            {
                return;
            }

            // AIの入力待ち
            InputData aIInputData = this.aIInput.GetInput();
            if (!aIInputData.IsInputed)
            {
                return;
            }

            // コマンド実行
            myPekemon.DoMove(inputData.selectedMoveId, oppnentPekemon);

            // 敵は選択した技を実行（テスト）
            oppnentPekemon.DoMove(aIInputData.selectedMoveId, myPekemon);

            // 入力状態を初期化
            this.playerInput.Init();
            this.aIInput.Init();
        }

        private void CreatePekemon()
        {
            GameObject poke1 = Resources.Load("Prefab/Pekemon") as GameObject;
            GameObject tempMyPekemon = Object.Instantiate(poke1);
            tempMyPekemon.name = BattleConstants.BATTLING_PLAYERS_PEKEMON_NAME;
            myPekemon = tempMyPekemon.GetComponent<Pekemon>();
            GameObject poke2 = Resources.Load("Prefab/Pekemon2") as GameObject;
            GameObject tempOppnentPekemon = Object.Instantiate(poke2);
            tempOppnentPekemon.name = BattleConstants.BATTLING_ENEMYS_PEKEMON_NAME;
            oppnentPekemon = tempOppnentPekemon.GetComponent<Pekemon>();
            IList<IMove> moves = new List<IMove>
            {
                QuickAttack.Instance,
                Thunderbolt.Instance,
                TestMove.Instance,
            };
            GameObject.Find(BattleConstants.BATTLING_PLAYERS_PEKEMON_NAME).GetComponent<Pekemon>().Init(moves);
            GameObject.Find(BattleConstants.BATTLING_ENEMYS_PEKEMON_NAME).GetComponent<Pekemon>().Init(moves);
        }

        private void CreateUI()
        {
            // プレイヤーUI
            GameObject hpGauge = GameObject.Find("PlayerPekemonHpGauge");
            hpGauge.GetComponent<HpGauge>().pekemon = this.myPekemon;

            // 敵UI
            GameObject oppnentHpGauge = GameObject.Find("EnemyPekemonHpGauge");
            oppnentHpGauge.GetComponent<HpGauge>().pekemon = this.oppnentPekemon;
        }
    }
}


