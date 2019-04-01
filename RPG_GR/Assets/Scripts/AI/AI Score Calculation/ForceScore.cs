using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA.AI
{
    [CreateAssetMenu(menuName = "AI/Scores/ForceScore")]
    public class ForceScore : AI_ScoreCalculation
    {
        public int score = 5;

        public override int Calculate(AIManager ai)
        {
            return score;
        }
    }
}