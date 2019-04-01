using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "UI/Player Inventory Manager")]
    public class PlayerInventory : StateActions
    {
        public StatesManagerVariable playerStates;
        public ItemArrayVariable weaponItems;
        public ItemArrayVariable clothItems;

        public PlayerProfile playerProfile; 

        public override void Execute(StateManager states)
        {
            if(states.itemsDirty)
            {
                states.itemsDirty = false;

                playerProfile.rightHandWeaponItems = states.inventory.rightHandSlots;
                playerProfile.leftHandWeaponItems = states.inventory.leftHandSlots;
                playerProfile.clothItems.Clear();
                playerProfile.clothItems.AddRange(states.inventory.cloths);
            }
        }

        public void LoadPlayerItems()
        {
       

            weaponItems.itemsArray = new Item[6];

            for (int i = 0; i < playerProfile.rightHandWeaponItems.Length; i++)
            {
                
                weaponItems.itemsArray[i] = playerProfile.rightHandWeaponItems[i];
            }

            for (int i = 0; i < playerProfile.leftHandWeaponItems.Length; i++)
            {
                Debug.Log("index " + i);
                weaponItems.itemsArray[3+i] = playerProfile.leftHandWeaponItems[i];
            }

            clothItems.itemsArray = new Item[playerProfile.clothItems.Count];
            for (int i = 0; i<playerProfile.clothItems.Count;i++)
            {
                clothItems.itemsArray[i] = playerProfile.clothItems[i];
            }
        }
    }
}