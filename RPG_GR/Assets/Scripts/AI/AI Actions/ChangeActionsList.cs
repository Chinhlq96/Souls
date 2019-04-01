using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA.AI
{
    [CreateAssetMenu(menuName = "AI/AI Actions/ChangeActionsList")]
    public class ChangeActionsList : AIAction
    {
        public AI_ActionsHolder holder;

        public override void Tick(AIManager ai)
        {
            ai.currentActionsHolder = holder;
        }
    }
}