using UnityEngine;
using System.Collections;

namespace SA
{
    [CreateAssetMenu(menuName = "Items/Body Part")]
    public class BodyPart : ScriptableObject
    {
        public bool disableIfNoItem = true;

    }
}