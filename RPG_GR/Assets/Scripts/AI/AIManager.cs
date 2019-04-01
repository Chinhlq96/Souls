using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SA;
using UnityEngine.AI;

namespace SA.AI
{
    [RequireComponent(typeof(StateManager))]
    public class AIManager : MonoBehaviour
    {
        public StateManager states;

        #region variables
        public float timer;
        public float delta;
        public bool isAggro;
        public float aggroRadius = 10;
        public float minAggro = 4;
        public float aggroAngle = 30;
        public NavMeshAgent agent;
        public Vector3 targetDestination;
        public bool isMoving;
        public int currentDamageOutput;
        #endregion

        #region decisions variables
        public float decisionTimer;

        #endregion

        public DamageOutputs[] damageOutputs;

        public void SetDamageOutput(AIAttackOnInterval att)
        {
            for (int i = 0; i < damageOutputs.Length; i++)
            {
                if(damageOutputs[i].attack == att)
                {
                    currentDamageOutput = damageOutputs[i].damageOutput;
                }
            }
        }

        public WeaponHook weaponHook;
        public StateActions aggroAction;

        public AIAction currentAction;
        public AI_ActionsHolder currentActionsHolder;
        public StateManager currentPlayer;

        private void Start()
        {
            states = GetComponent<StateManager>();
            states.aiManager = this;

            agent = GetComponentInChildren<NavMeshAgent>();

            if (currentActionsHolder != null)
            {
                AIAction hightest = currentActionsHolder.FindHighestScoreAction(this);

                currentAction = hightest;

            }

            weaponHook = GetComponentInChildren<WeaponHook>();
            if(weaponHook!=null)
            {
                weaponHook.Init();
            }
        }

        public void Tick(float delta)
        {
            this.delta = delta;

            if(currentActionsHolder!=null)
                currentActionsHolder.HandleDecisionsTimer(this);

            if (currentAction !=null)
            {
                currentAction.Tick(this);
            }
        }

    }
    [System.Serializable]
    public class DamageOutputs
    {
        public AIAttackOnInterval attack;
        public int damageOutput = 20;
    }
}