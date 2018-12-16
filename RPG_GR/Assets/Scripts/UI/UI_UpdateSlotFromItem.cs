using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SA {
    public class UI_UpdateSlotFromItem : GameEventListener {
        public Image icon;
        public ItemVariable targetItem;

        public override void Raise()
        {
            if(targetItem.value == null || targetItem.value.icon == null)
            {
                icon.enabled = false;
                icon.sprite = null;
            }
            else
            {
                icon.sprite = targetItem.value.icon;
                icon.enabled = true;
            }
            base.Raise();
        }
    }
}