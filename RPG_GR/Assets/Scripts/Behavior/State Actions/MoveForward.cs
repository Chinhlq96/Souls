using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName ="Actions/State Actions/Move Forward")]
    public class MoveForward : StateActions
    {
        
        public float movementSpeed = 2;

        public override void Execute(StateManager states)
        {
            Vector3 originalVelocity = states.rigidbody.velocity;
            Vector3 velocity = states.mTransform.forward * states.moveAmount * movementSpeed;

            if(states.isLockingOn)
            {
                velocity = states.rotateDirection * states.moveAmount * movementSpeed; ;
            }

            if (states.isGrounded)
            {
                if (states.moveAmount > 0.1f)
                    states.rigidbody.drag = 0;
                else
                    states.rigidbody.drag = 4;
            }
            else
            {
                states.rigidbody.drag = 0;
            }

            if (states.isGrounded)
                velocity.y = 0;
            else
                velocity.y = originalVelocity.y;
            states.rigidbody.velocity = velocity;
        }
    }
}
