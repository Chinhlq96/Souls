using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/Item Actions/Attack Action")]
    public class AttackItemActions : ItemActions
    {
        public string targetAnim;

        public ItemActions assignCombo;

        public override void Execute(StateManager states)
        {
            states.PlayAnimation(targetAnim);
            states.currentState = targetState;

            if(assignCombo != null)
            {
                states.comboAction = assignCombo;
            }
        }

        public override void OnHit(StateManager owner, StateManager defender)
        {
            if(itemLogic!=null)
            {
                itemLogic.Execute(defender);
            }
        }

    }
}