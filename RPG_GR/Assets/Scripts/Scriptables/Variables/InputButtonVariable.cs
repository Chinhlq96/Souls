using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName =("Variables/ IB Variable (Enum)"))]
    public class InputButtonVariable : ScriptableObject
    {
        public StateManager.InputButton value;
        
        public void Set(StateManager states)
        {
            if(states.rb)
            {
                value = StateManager.InputButton.rb;
            }
            if (states.lb)
            {
                value = StateManager.InputButton.lb;
            }
            if (states.rt)
            {
                value = StateManager.InputButton.rt;
            }
            if (states.lt)
            {
                value = StateManager.InputButton.lt;
            }
        }

    }
}