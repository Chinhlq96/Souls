using UnityEngine;
using System.Collections;

namespace SA
{
    [CreateAssetMenu(menuName ="Actions/State Actions/Parrying Action")]
    public class MonitorParrying : StateActions
    {
        public float originOffset = 1.4f;

        public State waitForAnimationState;

        public override void Execute(StateManager s)
        {
            if(s.isParrying)
            {
                RaycastHit hit;
                Vector3 origin = s.mTransform.position;
                origin.y += originOffset;
                Debug.DrawRay(origin, s.mTransform.forward,Color.red);
                if (Physics.SphereCast(origin, .3f, s.mTransform.forward, out hit, 1, s.ignoreLayers))
                {
                    IParryable parryable = hit.transform.GetComponentInParent<IParryable>();
                    if (parryable != null)
                    {
                        parryable.OnGettingParried();
                        s.currentState = waitForAnimationState;
                    }
                }
            }
        }
    }
}