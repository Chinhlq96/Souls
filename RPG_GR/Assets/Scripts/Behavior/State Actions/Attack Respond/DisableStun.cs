using UnityEngine;
using System.Collections;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/State Actions/Disable Stun")]
    public class DisableStun : StateActions
    {
        public override void Execute(StateManager states)
        {
            states.isStunned = false;
        }
    }
}