using UnityEngine;
using System.Collections;

namespace SA
{
    [CreateAssetMenu(menuName ="Actions/Mono Actions/RotateToLookAtTransform")]
    public class RotateToLookAtTransform : Action
    {
        public StatesManagerVariable playerStates;
        public FloatVariable delta;
        public float speed = 8;

        public TransformVariable cameraYTransform;
        public TransformVariable pivotTransform;

        public FloatVariable yAngle;
        public FloatVariable xAngle;

        public override void Execute()
        {
            if (playerStates.value.currentTarget == null)
                return;
            Vector3 direction = playerStates.value.currentTarget.position - cameraYTransform.value.position;
            Vector3 pivotDirection = direction;

            direction.y = 0;

            float t = delta.value * speed;

            Quaternion targetRot = Quaternion.LookRotation(direction);
            cameraYTransform.value.rotation = Quaternion.Slerp(cameraYTransform.value.rotation, targetRot, t);

            float dist = Vector3.Distance(playerStates.value.mTransform.position, playerStates.value.currentTarget.position);
            dist /= 2;
            Vector3 lookPosition = pivotDirection * dist;
            lookPosition += cameraYTransform.value.position;
            pivotTransform.value.LookAt(lookPosition);
            // Quaternion pivotRot = Quaternion.LookRotation(lookPosition);
            //  pivotTransform.value.rotation = Quaternion.Slerp(pivotTransform.value.rotation, pivotRot, t);

            Vector3 localEulers = pivotTransform.value.localEulerAngles;
            localEulers.y = 0;
            localEulers.z = 0;
            pivotTransform.value.localEulerAngles = localEulers;

            yAngle.value = cameraYTransform.value.localEulerAngles.y;
            xAngle.value = localEulers.x;


        }
    }
}