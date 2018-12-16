using UnityEngine;
using System.Collections;

namespace SA
{
    [CreateAssetMenu(menuName ="Actions/State Actions/SetInteruptability")]
    public class SetInteruptability : StateActions
    {
        [SerializeField]
        public bool status;
        public override void Execute(StateManager states)
        {
            Debug.Log("set");
            states.dontInterrupt = status;
        }
    }
} 