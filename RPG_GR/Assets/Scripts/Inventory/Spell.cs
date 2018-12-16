using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SA
{
    [CreateAssetMenu(menuName = "Items/Spell")]
    public class Spell : Item
    {
        public SpellAction spellAction;
        public GameObject spellParticle;
        public GameObject spellProjectile;


        public void PrepareCast(StateManager states)
        {
            spellAction.PrepareCast(states,this);
            SetSpellToCast(states);
        }
        
        public void SetSpellToCast(StateManager states)
        {
            states.currentSpell = this;
        }
    }
}