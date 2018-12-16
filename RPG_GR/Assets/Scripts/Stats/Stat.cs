using UnityEngine;
using System.Collections;

namespace SA
{
    [CreateAssetMenu(menuName ="Stats/Stat")]
    public class Stat : ScriptableObject
    {
        public IntVariable variable;

        public void Set(int v)
        {
            variable.Set(v);
        }

        public void Add(int v)
        {
            variable.Add(v);
        }

    }
}