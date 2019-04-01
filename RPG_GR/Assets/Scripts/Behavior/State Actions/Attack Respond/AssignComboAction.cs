using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/Item Actions/AssignComboAction")]
    public class AssignComboAction : ItemActions
    {
        public ItemActions comboAction;

        public override void Execute(StateManager states)
        {
            states.comboAction = comboAction;
        }

     

    }
}