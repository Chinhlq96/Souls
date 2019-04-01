using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA.AI
{
    [CreateAssetMenu(menuName ="AI/AI Actions/Attack on Interval")]
    public class AIAttackOnInterval : AIAction
    {
        public string animationName = "th_attack_2";
        public float interval=2;

        public override void Tick(AIManager ai)
        {
            ai.timer += ai.delta;
            if(ai.timer > interval)
            {
                ai.timer = 0;
                ai.states.PlayAnimation(animationName);
                ai.SetDamageOutput(this);
            }
        }
    }
}