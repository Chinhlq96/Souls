using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class TriggerEnemy : MonoBehaviour
    {
        public List<AI.AIManager> enemies = new List<AI.AIManager>();

        private void OnTriggerEnter(Collider other)
        {
            StateManager states = other.GetComponentInParent<StateManager>();
            if(states!=null)
            {
                if(states.isPlayer)
                {
                    foreach (AI.AIManager a in enemies)
                    {
                        a.currentPlayer = states;
                        a.isAggro = true;
                    }
                }
            }
        }

    }
}