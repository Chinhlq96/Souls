using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/MoveWithAgent")]
    public class MoveWithAgent : StateActions
    {
        public override void Execute(StateManager states)
        {
                states.mTransform.position = states.aiManager.agent.transform.position;
                states.mTransform.rotation = states.aiManager.agent.transform.rotation;
                states.aiManager.agent.transform.localPosition = Vector3.zero;
                states.aiManager.agent.transform.localRotation = Quaternion.identity;

            Vector3 relative = states.mTransform.InverseTransformDirection(states.aiManager.agent.desiredVelocity);
            states.anim.SetFloat("vertical",relative.z,0.4f,states.delta);
            states.anim.SetFloat("horizontal",relative.x,0.4f,states.delta);
        }
    }
}