using UnityEngine;
using System.Collections;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/Mono Actions/FixedOr")]
    public class ConditionalActionBatch : Action
    {
        public bool ifTrue;
        public BoolVariable boolVariable;
        public Action[] actions;


        public override void Execute()
        {
            if (boolVariable.value && ifTrue)
            {
                for (int i = 0; i < actions.Length; i++)
                {
                    actions[i].Execute();
                }
            }
            else if(!ifTrue && !boolVariable.value)
            {
                for (int i = 0; i < actions.Length; i++)
                {
                    actions[i].Execute();
                }
            }



        }


    }
}