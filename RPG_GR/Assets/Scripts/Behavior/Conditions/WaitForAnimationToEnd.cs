using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SA
{
    [CreateAssetMenu(menuName = "Conditions/WaitForAnimationToEnd")]
    public class WaitForAnimationToEnd : Condition
    {
        public string targetBool = "isInteracting";
        public override bool CheckCondition(StateManager state)
        {
            bool retVal = !state.anim.GetBool(targetBool);
          
            return retVal;  
        }

    }
}