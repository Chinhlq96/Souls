using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName ="Variables/Item Array")]
    public class ItemArrayVariable : ScriptableObject
    {
        [System.NonSerialized]
        public Item[] itemsArray;

    }
}