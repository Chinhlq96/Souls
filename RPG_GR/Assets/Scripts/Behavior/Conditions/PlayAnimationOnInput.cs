using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Conditions/PlayAnimationOnInput" )]
    public class PlayAnimationOnInput : Condition
    {
        public StateManager.InputButton button;
        public string targetBool = "isInteracting";

        //if true moving to difference state
        public override bool CheckCondition(StateManager state)
        {
            bool retVal = false ;

            switch (button)
            {
                case StateManager.InputButton.rb:
                    retVal = state.rb;
                    break;
                case StateManager.InputButton.rt:
                    retVal = state.rt;
                    break;
                case StateManager.InputButton.lb:
                    retVal = state.lb;
                    break;
                case StateManager.InputButton.lt:
                    retVal = state.lt;
                    break;
                default:
                    break;
            }
            if(retVal)
            {
                state.anim.CrossFade("oh_attack_1", 0.2f);
                state.anim.SetBool(targetBool, true);
            }

            return retVal;
        }

        
    }
}