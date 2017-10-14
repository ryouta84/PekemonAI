using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ExtensionMethods;

namespace Pekemon.Battle
{
    public class BattleState : IState
    {
        private static BattleState singleton = new BattleState();

        private BattleState() { }

        public static BattleState GetInstance()
        {
            return singleton;
        }
        public void OnEnter()
        {
            Debug.Log("BATTLE START!");
            GameObject poke = Resources.Load("Prefab/Pekemon") as GameObject;
            var pekemon = Object.Instantiate(poke);
            pekemon.name = "FightingPekemon";
            IMove[] moves = 
            {
                QuickAttack.Instance,
                Thunderbolt.Instance,
            };
            GameObject.Find("FightingPekemon").GetComponent<Pekemon>().Init(moves);

			var hpGauge = (GameObject)Object.Instantiate(Resources.Load("Prefab/HpGauge"));
			hpGauge.transform.SetParent(GameObject.Find("BattleUI").transform, false);
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
			if(Input.GetKeyDown("a"))
			{
				//GameObject.Find("FightingPekemon").GetComponent<Pekemon>().DoMove(1, GameObject.Find("FightingPekemon").GetComponent<Pekemon>());
			}
        }
    }
}

namespace ExtensionMethods
{
    using Pekemon.Battle;
    public static class ExtensionInstantiate
    {
        public static Pekemon Instantiate(this Object pekemonPref, string name, short maxHP)
        {
            var pekemon = (Object.Instantiate(pekemonPref) as GameObject).GetComponent<Pekemon>();
            pekemon.pekemonName = name;
            pekemon.name = "MyPekemon";
            pekemon.HP = maxHP;

            return pekemon;
        }
    }
}

