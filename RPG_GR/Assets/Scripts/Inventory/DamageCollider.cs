using UnityEngine;
using System.Collections;

namespace SA
{
    public class DamageCollider : MonoBehaviour
    {

        public StateManager ourStates;
        public new Collider collider;
        
       

        private void Start()
        {
            this.gameObject.layer = 10;
            collider = GetComponent<Collider>();
            ourStates = GetComponentInParent<StateManager>();
        }

        private void OnTriggerEnter(Collider other)
        {
            StateManager states = other.transform.GetComponentInParent<StateManager>();
            if (states != null)
            {
               if(states!= ourStates)
                {
                    states.OnHit(ourStates);
                }
            }
        }

    }
}