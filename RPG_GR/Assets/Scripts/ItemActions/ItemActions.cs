using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public abstract class ItemActions : ScriptableObject
    {
        public State targetState ;
        public ItemLogic itemLogic;
        public abstract void Execute(StateManager states);

       public virtual void OnHit(StateManager owner,StateManager defender)
        {
         
        }

    }
}