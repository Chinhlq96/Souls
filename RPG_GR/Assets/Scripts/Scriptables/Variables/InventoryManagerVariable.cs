 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Variables/Inventory Manager")]
    public class InventoryManagerVariable : ScriptableObject
    {
        [System.NonSerialized]
        public UI_InventoryManager value;
    }
}