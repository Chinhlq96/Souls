using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu]
    public class MovementAnimations : StateActions
    {
        public string floatName;
     

        public override void Execute(StateManager states)
        {
            states.anim.SetFloat(floatName, states.moveAmount, .2f, states.delta);
        }
    }
}
