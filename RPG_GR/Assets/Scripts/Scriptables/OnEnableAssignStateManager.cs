using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SA
{
    public class OnEnableAssignStateManager : MonoBehaviour
    {
        public StatesManagerVariable targetStateManagerVariable;

        private void OnEnable()
        {
            targetStateManagerVariable.value = GetComponent<StateManager>();
        }

    }
}