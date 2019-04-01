using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName ="Actions/State Actions/Find Nearby Enemies")]
    public class FindNearbyEnemies : StateActions
    {
        public override void Execute(StateManager states)
        {
            Collider[] cols = Physics.OverlapSphere(states.mTransform.position, states.aiManager.aggroRadius);
            for (int i = 0; i < cols.Length; i++)
            {
                StateManager st = cols[i].GetComponent<StateManager>();
                if(st!=null)
                {
                    if(st.isPlayer)
                    {
                        states.aiManager.currentPlayer = st;
                    }
                }
            }
        }

    
    }
}