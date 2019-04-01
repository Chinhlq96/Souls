using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [System.Serializable]
    public class UI_SlotContainer 
    {
        public UI_SlotType type;
        public Transform gridParent;
        public int slotCount;

        [HideInInspector]
        public UI_ItemSlot[] slots;

        public void LoadItems()
        {
            type.LoadItem(this);
        }
    }
}