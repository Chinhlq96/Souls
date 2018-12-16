using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName ="Conditions/Monitor Rolls")]
    public class MonitorRolls : Condition
    {

        public InputManager inpManager;
        float bTimer;

        public override bool CheckCondition(StateManager state)
        {
            bool retval = false;

            if (inpManager.b_Input.isPressed)
            {
                bTimer += Time.deltaTime;
                if (bTimer > .5f)
                {
                    //sprint

                } 
            }
            else
            {
                if (bTimer > 0)
                {

                    state.isBackstep = false;
                    retval = true;
                    state.generalT = 0;

                    if (state.moveAmount > 0)
                    {
                        state.anim.SetFloat("vertical", 1);
                        state.PlayAnimation("Rolls");
                        if(state.isLockingOn)
                        {
                            state.rollDirection = state.rotateDirection;
                        }
                        else
                        {
                            state.rollDirection = state.mTransform.forward;
                        }
                       
                    }
                    else
                    {
                        //phan biet backstep va roll
                        state.isBackstep = true;
                        //xu li trong tree cua animation Roll, chu ko co anim stepback rieng
                        state.anim.SetFloat("vertical", 0);
                        state.PlayAnimation("Rolls");
                        state.rollDirection = -state.mTransform.forward;
                    }
                }
                bTimer = 0;
            }

            

            return retval;
        }

    }
}