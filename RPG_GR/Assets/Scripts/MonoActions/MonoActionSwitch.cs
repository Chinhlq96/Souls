using UnityEngine;
using System.Collections;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/Mono Actions/MonoActionSwitch")]
    public class MonoActionSwitch : Action
    {
        public BoolVariable boolVariable;
        public Action actionTrue;
        public Action[] actionFalse;


        public override void Execute()
        {
            if(boolVariable.value)
            {
                actionTrue.Execute();
            }
            else
            {
                for (int i = 0; i < actionFalse.Length; i++)
                {
                    actionFalse[i].Execute();
                }            }
        }

    }
}