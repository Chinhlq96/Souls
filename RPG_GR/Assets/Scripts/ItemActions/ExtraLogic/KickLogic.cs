using UnityEngine;
using System.Collections;

namespace SA
{
    [CreateAssetMenu(menuName ="Items/Item Logics/KickLogic")]
    public class KickLogic : ItemLogic
    {
        public override void Execute(StateManager stateManager)
        {
            if (stateManager.dontInterrupt)
                return;
            stateManager.dontInterrupt = true;
            stateManager.PlayAnimation("attack_interrupt");
        }
    }
}