using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class OnEnableAssignTransVariable : MonoBehaviour
    {
        public TransformVariable targetVariable;

        private void OnEnable()
        {
            targetVariable.value = this.transform;
        }

    }
}