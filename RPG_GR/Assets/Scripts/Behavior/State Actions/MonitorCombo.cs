using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/MonitorCombo")]
    public class MonitorCombo : StateActions
    {
        public InputButtonVariable inpButtonVariable;

        public override void Execute(StateManager state)
        {
            if(state.isComboAvailable)
            {
                if (state.rb || state.lb || state.rt || state.lt)
                {
                    if (state.comboAction != null)
                    {
                        inpButtonVariable.Set(state);
                        state.comboAction.Execute(state);
                        state.isComboAvailable = false;
                    }
                }
            }
        }

    }
}