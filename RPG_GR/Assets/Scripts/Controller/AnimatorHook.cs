using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class AnimatorHook : MonoBehaviour
    {
        StateManager states;
        Animator anim;

        public void Init(StateManager st)
        {
            states = st;
            anim = states.anim;
        }


        public void CloseParticle()
        {

        }

        public void InitiateThrowForProjectile()
        {
            states.ThrowProjectile(); 
        }

        public void CreateSpellParticle()
        {
            states.CreateSpellParticle();
        }

        public void DamageColliderStatus(int value)
        {
            bool v = value == 1;
            if(v)
            {
                Debug.Log(states);
                states.canRotate = false;
            }
            states.SetDamageColliderStatus(v);
            states.damageCollidersAreOpen = v;
        }
        public void UnarmedDamageColliderStatus(int value)
        {
            bool v = value == 1;
            if (v)
            {
                states.canRotate = false;
            }
          //  StatsHolder.unarmedCollider.collider.enabled = v;
        }

        public void SetRotateStatus(int value)
        {
            states.canRotate = value == 1;
        }
        public void InitiateParry(int value)
        {
            states.isParrying = (value==1);
        }

        
    }
}