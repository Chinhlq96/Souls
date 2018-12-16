using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName ="Actions/State Actions/Batch State Actions")]
    public class BatchStateAction : StateActions
    {
        public StateActions[] stateActions;

        public override void Execute(StateManager states)
        {
            for (int i = 0; i < stateActions.Length; i++)
            {
                stateActions[i].Execute(states);
            }
        }

    }
}