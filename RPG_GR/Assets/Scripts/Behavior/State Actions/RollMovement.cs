using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName ="Actions/State Actions/Roll Movement")]
    public class RollMovement : StateActions
    {

        public AnimationCurve speedCurve;
        public float speed =3;
        public float backstep = 2;


        public override void Execute(StateManager states)
        {
            states.rigidbody.drag = 0;
            states.generalT += states.delta;
            Vector3 v = states.rigidbody.velocity;
            Vector3 tv = (states.isBackstep) ? states.rollDirection * backstep : states.rollDirection * speed;

            tv.y = 0;

            tv *= speedCurve.Evaluate(states.generalT);
            tv.y = v.y;
            states.rigidbody.velocity = tv;

            if (!states.isBackstep && states.isLockingOn)
            {
                Vector3 targetDir = states.rollDirection;
                targetDir.y = 0;
                Quaternion targetRot = Quaternion.LookRotation(targetDir);
                Quaternion r = Quaternion.Slerp(states.mTransform.rotation, targetRot, states.delta * 15);
                states.mTransform.rotation = r;
            }
        }
      

    }
}