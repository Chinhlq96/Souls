using UnityEngine;
using UnityEngine.Events;

namespace SA
{
    public class GameEventListener : MonoBehaviour
    {
        public GameEvent targetEvent;
        public UnityEvent Response;

        void OnEnable()
        {
            targetEvent.Register(this);
        }

        private void OnDisable()
        {
            Debug.Log("deleting");
            targetEvent.UnRegister(this);
        }

        public virtual void Raise()
        {
            Response.Invoke();
        }

    }
}