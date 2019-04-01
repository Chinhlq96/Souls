using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace SA
{
    public class UI_ItemSlot : MonoBehaviour
    {
        public Image icon;
        public Item item;

        public void LoadItem(Item targetItem)
        {
            if (targetItem == null)
            {
                item = null;
                icon.sprite = null;
                icon.enabled = false;
            }
            else
            {
                item = targetItem;
                icon.sprite = item.icon;
                icon.enabled = true;
            }

        }
    }
}