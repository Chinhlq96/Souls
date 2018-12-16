using UnityEngine;
using System.Collections;

namespace SA
{
    [CreateAssetMenu(menuName ="Actions/Item Actions/Spell Action")]
    public class SpellItemAction : ItemActions
    {
        public State waitForAnimationState;
        public override void Execute(StateManager states)
        {
            if (states.inventory.spell != null)
            {
                states.inventory.spell.PrepareCast(states);
                states.currentState = targetState;
            }
            else
            {
                states.currentState = waitForAnimationState;
                states.PlayAnimation("cant spell", false);
            }
        }
    }
}