using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Items/Spell Action/Fireball Spell")]
    public class FireBallSpell : SpellAction
    {

        public string targetAnimation;

        public override void PrepareCast(StateManager state,Spell spell)
        {
            state.PlayAnimation(targetAnimation, false);
            //change state without wiring in graph 
            state.currentState = castingSpellState;

            state.rigidbody.velocity = Vector3.zero;
            state.rigidbody.isKinematic = true;
            state.forceEndActions = true;
            state.currentProjectile = spell.spellProjectile;

            Transform rh = state.anim.GetBoneTransform(HumanBodyBones.RightHand);
            CreateSpellParticle(spell, rh);

        }

        public override bool Cast(StateManager state, Spell spell)
        {
            return true;
        }
    }
}