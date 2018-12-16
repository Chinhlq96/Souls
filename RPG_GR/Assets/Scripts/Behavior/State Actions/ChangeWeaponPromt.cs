using UnityEngine;
using System.Collections;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Change Weapons Promt")]
    public class ChangeWeaponPromt : StateActions
    {
        public ChangeWeapon changeWeapon;

        public InputButton leftSlot;
        public InputButton rightSlot;
        public InputButton upSlot;
        public InputButton downSlot;
         float l_timer;
         float r_timer;
         float u_timer;
         float d_timer;


        bool l_press;
        bool r_press;
        bool u_press;
        bool d_press;
        public override void Execute(StateManager states)
        {
            leftSlot.Execute();
            rightSlot.Execute();

            bool goToFirst = false;

            if (CheckTImer(ref l_timer, ref l_press, leftSlot, states, ref goToFirst))
            {
                leftSlot.isPressed = false;
                //leftSlot.controllerAxis.isPressed = false;
                changeWeapon.Execute(states, true);
                return;
            }

            if (goToFirst)
            {
                leftSlot.isPressed = false;
                //leftSlot.controllerAxis.isPressed = false;
                states.inventory.SetFirstWeapon(true);
                changeWeapon.Execute(states, true);
                //go to first left
                return;
            }

            if (CheckTImer(ref r_timer, ref r_press, rightSlot, states, ref goToFirst))
            {
                rightSlot.isPressed = false;
                //rightSlot.controllerAxis.isPressed = false;
                changeWeapon.Execute(states, false);
                return;
            }

            if (goToFirst)
            {
                rightSlot.isPressed = false;
                //rightSlot.controllerAxis.isPressed = false;
                changeWeapon.Execute(states, false);
                states.inventory.SetFirstWeapon(false);
                //go to first right
                return;
            }
            /*
            if (CheckTImer(ref u_timer, ref u_press, upSlot, states, ref goToFirst))
            {
                upSlot.isPressed = false;
                return;
            }

            if (goToFirst)
            
                {//go to first spell
                    return;
                }

                if (CheckTImer(ref d_timer, ref d_press, downSlot, states, ref goToFirst))
                {
                    downSlot.isPressed = false;
                    return;
                }

                if (goToFirst)
                {
                    //go to first item
                }*/
            
        }
        bool CheckTImer(ref float timer, ref bool isPrevPress, InputButton b,StateManager states, ref bool goToFirst)
        {
            bool result = false;
            if (b.isPressed)
            {
                isPrevPress = true;
                timer += states.delta;
                if (timer > 1)
                {
                    timer = 0;
                    result = true;
                    isPrevPress = false;
                    goToFirst = true;
                }

                
            }
            else
            {
                if(isPrevPress)
                {
                    result = true;
                    isPrevPress = false;
                }
                timer = 0;
            }
            return result;

        }
    }
}