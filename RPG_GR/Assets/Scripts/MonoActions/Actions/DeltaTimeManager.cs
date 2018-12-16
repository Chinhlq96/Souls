using UnityEngine;
using System.Collections;

namespace SA
{
    [CreateAssetMenu(menuName ="Actions/Mono Actions/Delta Time Manager")]
    public class DeltaTimeManager : Action
    {
        public FloatVariable targetVariable;

        public override void Execute()
        {
            targetVariable.value = Time.deltaTime;
        }

    }
}