using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Variables/Item Variable")]
    public class ItemVariable : ScriptableObject
    {
        public GameEvent gameEvent;
        private Item _value;
        public Item value
        {
            get
            {
                return _value;
            }

            set
            {
                _value = value;
                if(gameEvent != null)
                {
                    gameEvent.Raise();
                }
            }
        }
    }
}