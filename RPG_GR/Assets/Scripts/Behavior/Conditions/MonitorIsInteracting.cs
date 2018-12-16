using UnityEngine;
using System.Collections;

namespace SA
{
    [CreateAssetMenu(menuName = "Conditions/MonitorIsInteracting")]
    public class MonitorIsInteracting : Condition
    {
        public override bool CheckCondition(StateManager state)
        {
            bool retVal = state.anim.GetBool("isInteracting");
            return retVal;
        }
    }
}