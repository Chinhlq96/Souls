using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName ="UI/Slot Type")]
    public class UI_SlotType : ScriptableObject
    {
        public ItemArrayVariable targetItems;

        public void LoadItem(UI_SlotContainer container)
        {
            for (int i = 0; i < targetItems.itemsArray.Length; i++)
            {
                container.slots[i].LoadItem(targetItems.itemsArray[i]);
            }
        }

    }
}