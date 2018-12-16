using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName ="Conditions/MonitorAttackInput")]
    public class MonitorAttackInput : StateActions
    {

        public StateActions attackResponse;
        public InputButtonVariable inpButtonVariable;

     
        public override void Execute(StateManager state)
        {
            if(state.rb||state.lb||state.rt||state.lt)
            {
                inpButtonVariable.Set(state);
                attackResponse.Execute(state);
                
            }
           
        }

    }
}