using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName ="Actions/State Actions/MoveWithRootMotion")]
    public class MoveWithRootMotion : StateActions
    {
        public override void Execute(StateManager states)
        {
            states.rigidbody.isKinematic = false;
            Vector3 v = states.rigidbody.velocity;
            Vector3 tv = states.anim.deltaPosition;
            tv *= 60;
            tv.y = v.y;
            states.rigidbody.velocity = tv;

        }
    }
}