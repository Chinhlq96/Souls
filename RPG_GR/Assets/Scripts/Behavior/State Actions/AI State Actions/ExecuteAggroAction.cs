using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/ExecuteAggroAction")]
    public class ExecuteAggroAction : StateActions
    {
        public override void Execute(StateManager states)
        {
            if(states.aiManager.aggroAction!=null)
            {
                states.aiManager.aggroAction.Execute(states);
            }
        }
    }
}