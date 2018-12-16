using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    //lock on with camera
    public interface ILockable
    {
        Transform LockOn();

    }

    public interface IHittable
    {
        void OnHit(StateManager hitter);
    }

}
