using UnityEngine;
using System.Collections;

namespace SA
{
    [CreateAssetMenu(menuName = "Items/Spell Action/Healing Spell")]
    public class HealingSpell : SpellAction
    {

        public int healAmount = 25;
        public float timer = 2;
        public string targetAnimation;
        
        //right before casting spell 
        // eg : walk => precast => spell
        public override void PrepareCast(StateManager state,Spell spell)
        {
            state.PlayAnimation(targetAnimation,false);
            //change state without wiring in graph 
            state.currentState = castingSpellState;

            state.rigidbody.velocity = Vector3.zero;
            state.rigidbody.isKinematic = true;
            state.forceEndActions = true;

            CreateSpellParticle(spell, state.mTransform);
        } 

        public override bool Cast(StateManager state,Spell spell)
        {
            bool r = false;
            state.generalT += state.delta;
            if(state.generalT>timer)
            {
                r = true;
             //   state.playerStatsManager.health.variable.Add(healAmount);
                
            }
            return r;
        }

      
    }
}