using UnityEngine;
using System.Collections;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/Condition/HumanoidCanBeParriedLogic")]
    public class HumanoidCanBeParriedLogic : Condition
    {
        public override bool CheckCondition(StateManager states)
        {
            bool result = false;
            if(states.damageCollidersAreOpen)
            {
                if(!states.isStunned)
                {
                    result = true;
                    states.isStunned = true;
                    states.PlayAnimation("attack_interrupt", false);
                }
            }
            return result;
        }

    }
}