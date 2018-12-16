using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName ="Conditions/Monitor Spell Input")]
    public class MonitorSpellInput : Condition
    {
        public InputButtonVariable inpButtonVariable;

        private void OnEnable()
        {
            description = "Monitors spell input";
        }

        public override bool CheckCondition(StateManager state)
        {

            return false;
        }
    }
}