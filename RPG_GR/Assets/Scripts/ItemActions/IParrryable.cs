using UnityEngine;
using System.Collections;

namespace SA
{
    interface IParryable
    {
        void OnGettingParried();

        void IsGettingParried(StateManager states);

    }
}