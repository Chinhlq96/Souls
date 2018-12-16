using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public abstract class ItemLogic : ScriptableObject
    {
        public abstract void Execute(StateManager stateManager);

    }
}