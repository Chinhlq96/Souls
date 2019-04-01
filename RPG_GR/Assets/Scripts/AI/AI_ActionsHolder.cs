using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA.AI
{
    [CreateAssetMenu(menuName ="AI/Actions Holder")]
    public class AI_ActionsHolder : ScriptableObject
    {
        public AIAction[] actionsList;
        public float decisionRate;

        public void HandleDecisionsTimer(AIManager ai)
        {
            ai.decisionTimer += ai.delta;
            if (ai.decisionTimer > decisionRate)
            {
                ai.decisionTimer = 0;
                AIAction hightest = FindHighestScoreAction(ai);

                ai.currentAction = hightest;

            }
        }



        public AIAction FindHighestScoreAction(AIManager ai)
        {
            AIAction retVal = null;

            int highest = 0;
            for (int i = 0; i < actionsList.Length; i++)
            {
                if (actionsList[i].scoreCalculation == null)
                    continue;
                int score = actionsList[i].scoreCalculation.Calculate(ai);
                if (score == 0)//if an action has 0 score, its  considered disabled
                    continue;
                if (score > highest)
                {
                    highest = score;
                    retVal = actionsList[i];
                }
            }
            return retVal;
        }


    }
}