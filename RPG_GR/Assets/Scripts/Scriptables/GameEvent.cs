using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Event")]
    public class GameEvent : ScriptableObject
    {
        List<GameEventListener> listeners = new List<GameEventListener>();

        public void Register(GameEventListener l)
        {
            if (!listeners.Contains(l))
                listeners.Add(l);
        }

        public void UnRegister(GameEventListener l)
        {
            if (listeners.Contains(l))
                listeners.Remove(l);
        }

        public void Raise()
        {
            Debug.Log(listeners.Count);
            for (int i = 0; i < listeners.Count; i++)
            {
                listeners[i].Raise();
            }
            //backward for-loop  to prevent remove messing order
            /*for (int i = listeners.Count-1 ; i >=0; i--)
            {
                if(listeners[i]==null)
                {
                    listeners.RemoveAt(i);
                }
                else
                {
                    listeners[i].Raise();
                }
            }*/
        }
    }
}