using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Attacks/Attack Respond Based on Items")]
    public class PlayItemAction : StateActions
    {
        public InputButtonVariable inpButtonVariable;
        public bool powerPosing;
        public Condition isParryEnemy;

        public override void Execute(StateManager states)
        {
            if(states.isTwoHanded)
            {
                TwoHandedAction(states);
                return;
            }
            ItemActions targetAction = null;
            bool isMirror = false;

            switch (inpButtonVariable.value)
            {
                case StateManager.InputButton.rb:
                case StateManager.InputButton.rt:
                    if (isParryEnemy)
                    {
                        bool success = isParryEnemy.CheckCondition(states);
                        if (success)
                        {
                            states.PlayAnimation("parry_attack",false);
                            return;
                        }
                    }
                    if (states.inventory.rightHandWeapon != states.inventory.unarmedWeapon)
                    {
                        isMirror = false;
                        targetAction = states.inventory.rightHandWeapon.GetItemActions(inpButtonVariable.value);
                    }
                    else
                    {
                        if (states.inventory.leftHandWeapon != states.inventory.unarmedWeapon)
                        {
                            //rb +2 = lb
                            isMirror = true;
                            StateManager.InputButton newButton = (StateManager.InputButton)((int)inpButtonVariable.value + 2);
                            targetAction = states.inventory.rightHandWeapon.GetItemActions(newButton);
                           
                        }
                        else
                        {
                            isMirror = false;
                            targetAction = states.inventory.rightHandWeapon.GetItemActions(inpButtonVariable.value);
                         
                        }
                    }

                    break;

                case StateManager.InputButton.lb:
                case StateManager.InputButton.lt:
                    
                    if(states.inventory.leftHandWeapon == states.inventory.unarmedWeapon)
                    {
                        targetAction = states.inventory.rightHandWeapon.GetItemActions(inpButtonVariable.value);
                        isMirror = false;
                    }
                    else
                    {
                        if (!powerPosing)
                        {
                            //turn lb,lt input to rb,rt input
                            StateManager.InputButton newButton = (StateManager.InputButton)((int)inpButtonVariable.value - 2);
                            isMirror = true;
                            targetAction = states.inventory.leftHandWeapon.GetItemActions(newButton);
                            
                        }
                        else
                        {
                            isMirror = true;
                            targetAction = states.inventory.rightHandWeapon.GetItemActions(inpButtonVariable.value);
                        }
                    }
                    break;
                default:
                    break;
            }

            states.inventory.currentItemAction = targetAction;

            states.anim.SetBool("mirror", isMirror);
            if(targetAction != null)
            targetAction.Execute(states);

        
        }

       void TwoHandedAction(StateManager states)
        {
            Weapon w = states.inventory.twoHandedWeapon;
            ItemActions targetAction = null;
            targetAction = w.GetTHItemActions(inpButtonVariable.value);

            states.anim.SetBool("mirror", false);
            if (targetAction != null)
                targetAction.Execute(states);


        }
       
    }
}