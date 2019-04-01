using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/MonitorAggroDistance")]
    public class MonitorAggroDistance : StateActions
    {
        public override void Execute(StateManager states)
        {
            if (states.aiManager.currentPlayer == null)
                return;
            float distance = Vector3.Distance(states.mTransform.position, states.aiManager.currentPlayer.mTransform.position);

            if (distance < states.aiManager.aggroRadius)
            {
                float angle = Vector3.Angle(states.mTransform.forward, states.aiManager.currentPlayer.mTransform.position - states.mTransform.position);
                if (angle < states.aiManager.aggroAngle || distance < states.aiManager.minAggro)
                {
                    states.aiManager.isAggro = true;
                }
            }
         
        }
    }
}