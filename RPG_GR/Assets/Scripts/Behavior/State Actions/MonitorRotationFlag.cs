using UnityEngine;
using System.Collections;

namespace SA
{
    [CreateAssetMenu(menuName ="Actions/State Actions/Monitor Rotation Flag")]
    public class MonitorRotationFlag : StateActions
    {
        public StateActions lockonRotation;
        public StateActions normalRotation;
        public override void Execute(StateManager states)
        {
            if (states.canRotate)
            {
                if (states.isLockingOn)
                {
                    lockonRotation.Execute(states);
                }
                else
                {
                    normalRotation.Execute(states);
                }
            }
        }
    }
}