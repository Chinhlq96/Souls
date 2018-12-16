using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName ="Mono Actions/RotateViaInput")]
    public class RotateViaInput : Action
    {
        public InputAxis targetInput;
        public TransformVariable targetTransform;

        public FloatVariable angle;
        public float speed;
        public bool negative;
        public bool clamp;
        public float minClamp = -35;
        public float maxClamp = 35;
        public RotateAxis targetAxis;

        public FloatVariable delta;
        public enum RotateAxis
        {
            x,y,z
        }

        public override void Execute()
        {
            float t = delta.value * speed;

            if(!negative)
                angle.value = Mathf.Lerp(angle.value, angle.value + targetInput.value,t);
            else
                angle.value = Mathf.Lerp(angle.value, angle.value - targetInput.value,t);

            if (clamp)
            {
                angle.value = Mathf.Clamp(angle.value, minClamp, maxClamp);
            }

            switch (targetAxis)
            {
                case RotateAxis.x:
                    targetTransform.value.localRotation = Quaternion.Euler(angle.value, 0, 0);
                    break;
                case RotateAxis.y:
                    targetTransform.value.localRotation = Quaternion.Euler(0, angle.value, 0);
                    break;
                case RotateAxis.z:
                    targetTransform.value.localRotation = Quaternion.Euler(0, 0, angle.value);
                    break;
                default:
                    break;
            }

        }

    }
}