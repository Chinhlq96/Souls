using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Agent RootMotion")]
    public class AgentRootMotion : StateActions
    {
        public override void Execute(StateManager states)
        {

            states.aiManager.agent.transform.localPosition = Vector3.zero;
            states.aiManager.agent.transform.localRotation = Quaternion.identity;
        }
    }
}