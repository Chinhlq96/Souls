using UnityEngine;
using System.Collections;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/isComboAvailableStatus")]
    public class isComboAvailableStatus : StateActions
    {
        public bool status;
        public override void Execute(StateManager states)
        {
            states.isComboAvailable = status;
        }

    }
}