using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SA
{

    public class UI_InventoryManager : MonoBehaviour
    {
        public GameObject itemSlot;

        public UI_SlotContainer[] slots;
        Dictionary<UI_SlotType, UI_SlotContainer> slotsDict = new Dictionary<UI_SlotType, UI_SlotContainer>();



        void Start()
        {
            SetupSlots();
        }

        public void LoadAllSlotItems()
        {
            foreach (var s in slots)
            {
                s.LoadItems();
            }
        }

        void SetupSlots()
        {
            //Create Dictionary
            for (int i = 0; i < slots.Length; i++)
            {
                slotsDict.Add(slots[i].type, slots[i]);

                slots[i].slots = new UI_ItemSlot[slots[i].slotCount];
                for (int c = 0; c < slots[i].slotCount; c++)
                {
                    GameObject go = Instantiate(itemSlot);
                    go.transform.SetParent(slots[i].gridParent);
                    go.transform.localScale = Vector3.one;
                    go.SetActive(true);

                    slots[i].slots[c] = go.GetComponent<UI_ItemSlot>();
                }
            }
        }

        public UI_SlotContainer GetSlot(UI_SlotType t)
        {
            UI_SlotContainer result = null;
            slotsDict.TryGetValue(t, out result);
            return result;
        }

        private void Update()
        {
            
        }


    }
}