using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA.AI
{
    [CreateAssetMenu(menuName = "AI/Scores/PlayerDistance")]
    public class PlayerDistance : AI_ScoreCalculation
    {
        public int score;

        public override int Calculate(AIManager ai)
        {
            int r = 0;

            if (ai.currentPlayer != null)
            {

                float distance = Vector3.Distance(ai.states.mTransform.position, ai.currentPlayer.mTransform.position);

                if (distance < ai.aggroRadius)
                {
                    r = score;
                }
            }

            return r;
        }
    }
}