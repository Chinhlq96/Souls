using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Variables/Integer")]
    public class IntVariable : NumberVariable
    {
        private int _value;
        public int value
        {
            get { return _value; }
        }

        public GameEvent gameEvent;

        public void Set(int v)
        {
            _value = v;

            if(gameEvent !=null)
            {
                gameEvent.Raise();
            }
        }

        public void Set(NumberVariable v)
        {
            if (v is FloatVariable)
            {
                FloatVariable f = (FloatVariable)v;
                _value = Mathf.RoundToInt(f.value);
            }

            if (v is IntVariable)
            {
                IntVariable i = (IntVariable)v;
                _value = i.value;
            }

            if (gameEvent != null)
            {
                gameEvent.Raise();
            }
        }

        public void Add(int v)
        {
            _value += v;

            if (gameEvent != null)
            {
                gameEvent.Raise();
            }
        }

        public void Add(NumberVariable v)
        {
            if (v is FloatVariable)
            {
                FloatVariable f = (FloatVariable)v;
                _value += Mathf.RoundToInt(f.value);
            }

            if (v is IntVariable)
            {
                IntVariable i = (IntVariable)v;
                _value += i.value;
            }

            if (gameEvent != null)
            {
                gameEvent.Raise();
            }
        }
    }
}