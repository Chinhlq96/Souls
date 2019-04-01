using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA.AI
{
    [CreateAssetMenu(menuName = "AI/Scores/Enemy Positioning")]
    public class EnemyPositioning : AI_ScoreCalculation
    {

        [SerializeField]
        int positiveValue = 10; 

        [SerializeField]
        float radius = 5;
        [SerializeField]
        float minAngle = 0;
        [SerializeField]
        float maxAngle = 30;
        [SerializeField]
        bool allAnglesPositive;
        [SerializeField]
        float angle;

        public override int Calculate(AIManager ai)
        {
            int r = 0;

            if (ai.currentPlayer == null || ai.currentPlayer.mTransform == null)
                return 0;

            float distance = Vector3.Distance(ai.states.mTransform.position, ai.currentPlayer.mTransform.position);
            //Debug.Log("distance is " + distance);
            if (distance < radius)
            {
                Vector3 direction = ai.currentPlayer.mTransform.position - ai.states.mTransform.position;

                angle = Vector3.Angle(ai.states.mTransform.forward, direction);

                if (!allAnglesPositive)
                {
                    float dot = Vector3.Dot(ai.states.mTransform.right, direction);
                    if (dot < 0)
                        angle *= -1;
                  

                }

                if(angle >= minAngle && angle <= maxAngle)
                {
                    r = positiveValue;
                }


            }
        


            return r;
        }
    }
}