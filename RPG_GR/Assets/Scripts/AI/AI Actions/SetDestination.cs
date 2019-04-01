using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA.AI
{
    [CreateAssetMenu(menuName = "AI/AI Actions/SetDestination")]
    public class SetDestination : AIAction
    {
        public override void Tick(AIManager ai)
        {
            ai.targetDestination = ai.currentPlayer.mTransform.position;
            ai.agent.SetDestination(ai.targetDestination);
        }
    }
}