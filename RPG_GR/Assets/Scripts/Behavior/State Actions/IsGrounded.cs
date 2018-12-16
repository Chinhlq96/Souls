using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu]
    public class IsGrounded : StateActions
    {
        public float groundedDis = 1.4f;
        public float onAirDis = 1f;

        public override void Execute(StateManager states)
        {
            Vector3 origin = states.mTransform.position;
            origin.y += .7f;
            Vector3 dir = -Vector3.up;
            float dis = groundedDis;
            if (!states.isGrounded)
                dis = onAirDis;
           


            //float dis = 1.4f;
            RaycastHit hit;
            Debug.DrawRay(origin, dir * dis);
           /* if (Physics.Raycast(origin, dir, out hit, dis))
            {
                Vector3 targetPosition = hit.point;
                states.transform.position = targetPosition;
            }*/
            if(Physics.SphereCast(origin,.3f,dir,out hit,dis,states.ignoreForGroundCheck))
            {
                states.isGrounded = true;
            }
            else
            {
                states.isGrounded = false;
            }
            if(states.isGrounded)
            {
                Vector3 targetPosition = states.mTransform.position;
                targetPosition.y = hit.point.y;
                states.mTransform.position = targetPosition;
            }

        }

    }
}
