using UnityEngine;
using System.Collections;

namespace SA
{
    [CreateAssetMenu(menuName ="Actions/State Actions/RotateToLookAtTarget")]
    public class RotateToLockAtTarget : StateActions
    {
        public float speed = 8;

        public override void Execute(StateManager states)
        {
            if (states.currentTarget == null)
                return;


            Vector3 targetDir = states.currentTarget.position - states.mTransform.position;
            targetDir.Normalize();

            targetDir.y = 0;
            if (targetDir == Vector3.zero)
                targetDir = states.transform.forward;

            Quaternion tr = Quaternion.LookRotation(targetDir);
            Quaternion targetRotation = Quaternion.Slerp(
                states.transform.rotation, tr,
                states.delta * speed);

            states.transform.rotation = targetRotation;
        }
    }
}