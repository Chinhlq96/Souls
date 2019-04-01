using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/ClearNavPath")]
    public class ClearNavPath : StateActions
    {
        public override void Execute(StateManager states)
        {
            states.aiManager.agent.path.ClearCorners();
        }
    }
}