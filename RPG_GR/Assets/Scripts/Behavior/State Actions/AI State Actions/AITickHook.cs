using UnityEngine;
using System.Collections;

namespace SA
{
    [CreateAssetMenu(menuName ="Actions/AI Actions/AI Tick Hook")]
    public class AITickHook : StateActions
    {
        public override void Execute(StateManager states)
        {
            states.aiManager.Tick(states.delta);
        }
    }
}