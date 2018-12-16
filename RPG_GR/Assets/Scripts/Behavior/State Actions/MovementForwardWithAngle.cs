﻿using UnityEngine;
using System.Collections;

namespace SA
{
    [CreateAssetMenu(menuName ="Actions/State Actions/Movement Forward With Angle")]
    public class MovementForwardWithAngle : StateActions
    {
        public float frontRayOffset = .5f;
        public float movementSpeed = 2;
        public float adaptSpeed = 10;
        public override void Execute(StateManager states)
        {
            float frontY = 0;
            RaycastHit hit;
            Vector3 origin = states.mTransform.position + (states.mTransform.forward * frontRayOffset);
            origin.y += .5f;
            Debug.DrawRay(origin, -Vector3.up, Color.red, .01f, false);
            if(Physics.Raycast(origin,-Vector3.up,out hit, 1 ,states.ignoreForGroundCheck))
            {
                float y = hit.point.y;
                frontY = y - states.mTransform.position.y;
            }

            Vector3 currentVelocity = states.rigidbody.velocity;
            Vector3 targetVelocity = states.mTransform.forward * states.moveAmount * movementSpeed;
            if(states.isLockingOn)
            {
                targetVelocity = states.rotateDirection * states.moveAmount * movementSpeed;
            }
            if(states.isGrounded)
            {
                float moveAmount = states.moveAmount;
                if(moveAmount >0.1f)
                {
                    states.rigidbody.isKinematic = false;
                    states.rigidbody.drag = 0;
                    if(Mathf.Abs(frontY)>0.02f)
                    {
                        targetVelocity.y = ((frontY > 0) ? frontY + 0.2f : frontY-0.2f) * movementSpeed;
                    }
                }
                else
                {
                    float abs = Mathf.Abs(frontY);
                    if(abs>0.02f)
                    {
                        states.rigidbody.isKinematic = true;
                        targetVelocity.y = 0;
                        states.rigidbody.drag = 4;
                    }
                }
            }
            else
            {
                states.rigidbody.isKinematic = false;
                states.rigidbody.drag = 0;
                targetVelocity.y = currentVelocity.y;
            }

            Debug.DrawRay((states.mTransform.position + Vector3.up * .2f), targetVelocity, Color.green, 0.01f, false);
            states.rigidbody.velocity = Vector3.Lerp(currentVelocity, targetVelocity, states.delta*adaptSpeed);
        }

    }
}