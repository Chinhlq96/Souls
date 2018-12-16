using UnityEngine;
using System.Collections;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/StateActionSwitch")]
    public class StateActionSwitch : StateActions
    {
        public BoolVariable boolVariable;
        public StateActions stateActionTrue;
        public StateActions stateActionFalse;

        public override void Execute(StateManager states)
        {
          

            if(boolVariable.value)
            {
                stateActionTrue.Execute(states);
            }
            else
            {
                stateActionFalse.Execute(states);
            }
        }
    }
}