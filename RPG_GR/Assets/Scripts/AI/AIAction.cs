using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA.AI
{
    public abstract class AIAction : ScriptableObject
    {
        public AI_ScoreCalculation scoreCalculation;


        public abstract void Tick(AIManager ai);


    }
}