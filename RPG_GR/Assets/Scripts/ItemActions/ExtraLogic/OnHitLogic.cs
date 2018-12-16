using UnityEngine;
using System.Collections;

namespace SA
{
    [CreateAssetMenu(menuName ="Items/Item Logics/On Hit Logic")]
    public class OnHitLogic : ItemLogic
    {
        public override void Execute(StateManager s)
        {
            if (s.dontInterrupt)
                return;
            s.dontInterrupt = true;
            s.PlayAnimation("hit");
        }
    }
}