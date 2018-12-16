using UnityEngine;
using System.Collections;

namespace SA
{
    [CreateAssetMenu(menuName = "Conditions/Wait For Spell Action")]
    public class WaitForSpellAction : Condition
    {
        public override bool CheckCondition(StateManager state)
        {
            bool r = false;
            bool castIsDone = false;
            bool animIsDone = false;
            if(state.currentSpell != null)
            {
                castIsDone = state.currentSpell.spellAction.Cast(state,state.currentSpell);
            }

            animIsDone = !state.anim.GetBool("isInteracting");

            if(castIsDone && animIsDone)
            {
                r = true;
                state.generalT = 0;
            }

            if(r== true)
            {
                state.currentSpell = null;
            }
            return r;
        }
    }
}