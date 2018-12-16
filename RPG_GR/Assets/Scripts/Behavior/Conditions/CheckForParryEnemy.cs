using UnityEngine;
using System.Collections;

namespace SA
{
    [CreateAssetMenu(menuName ="Conditions/Check For Parry Enemy")]
    //similar to minitor parrying
    public class CheckForParryEnemy : Condition
    {

        public float originOffset = 1.4f;
        public override bool CheckCondition(StateManager s)
        {
            bool result = false;
            RaycastHit hit;
            Vector3 origin = s.mTransform.position;
            origin.y += originOffset;
            Debug.DrawRay(origin, s.mTransform.forward, Color.red);
            if (Physics.SphereCast(origin, .3f, s.mTransform.forward, out hit, 1, s.ignoreLayers))
            {
                IParryable parryable = hit.transform.GetComponentInParent<IParryable>();
                Debug.Log(parryable);
                if (parryable != null)
                {
                    
                    parryable.IsGettingParried(s);
                }
            }

            return result;
        }

    }
}