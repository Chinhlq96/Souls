using UnityEngine;
using System.Collections;


namespace SA
{
    [CreateAssetMenu(menuName ="Actions/Mono Actions/Fixed Delta Time Manager")]
    public class FixedDeltaTimeManager : Action
    {
        public FloatVariable targetVariable;

        public override void Execute()
        {
            targetVariable.value = Time.fixedDeltaTime;
        }
    }
}