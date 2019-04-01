using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SA.AI
{
    public abstract class AI_ScoreCalculation : ScriptableObject
    {
        public abstract int Calculate(AIManager ai);

    }
}