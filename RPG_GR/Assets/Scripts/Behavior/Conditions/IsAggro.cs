using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Conditions/IsAggro")]
    public class IsAggro : Condition
    {
        public override bool CheckCondition(StateManager state)
        {
            return state.aiManager.isAggro;
        }
    }
}