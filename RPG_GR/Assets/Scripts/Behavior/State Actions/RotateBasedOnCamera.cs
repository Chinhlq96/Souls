using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu]
    public class RotateBasedOnCamera : StateActions
    {
        public TransformVariable cameraTransform;
        public float speed = 8;

        public override void Execute(StateManager states)
        {
            if (cameraTransform.value == null)
                return;

            float h = states.horizontal;
            float v = states.vertical;
  
            Vector3 targetDir = cameraTransform.value.forward * v;
            targetDir += cameraTransform.value.right * h;
            targetDir.Normalize();

            targetDir.y = 0;
            if (targetDir == Vector3.zero)
                targetDir = states.transform.forward;

            Quaternion tr = Quaternion.LookRotation(targetDir);
            Quaternion targetRotation = Quaternion.Slerp(
                states.transform.rotation, tr,
                states.delta * states.moveAmount * speed);

            states.transform.rotation = targetRotation;
        }
    }
}
