using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA.AI
{
    [CreateAssetMenu(menuName = "AI/AI Actions/Do Nothing")]
    public class DoNothing : AIAction
    {
        public override void Tick(AIManager ai)
        {
           
        }
    }
}