using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName ="Managers/ResourcesManager")]
    public class ResourcesManager : ScriptableObject
    {
        //Store all item
        public List<Item> allItems = new List<Item>();

        //Use this to find item, without having to go through the entire list
        Dictionary<string, Item> itemDict = new Dictionary<string, Item>();

        public void Init()
        {
            for (int i = 0; i < allItems.Count; i++)
            {
                if(!itemDict.ContainsKey(allItems[i].name))
                {
                    itemDict.Add(allItems[i].name, allItems[i]);
                }
                else
                {
                    //debug log for duplicate
                }
            }

        }

        //We dont need the item that created in inspector, we want the instance of the item.
        // so we can do change on that instance
        // for example if we have a abillity, its going to be on a seperate instance
        // so we dont have to check for referernce from other place
        public Item GetItemInstance(string targetId)
        {
            
            if (string.IsNullOrEmpty(targetId))
                return null;
            Debug.Log(targetId + "targetId");
            Item defaultItem = GetItem(targetId);
            
            Item newItem = Instantiate(defaultItem);
            newItem.name = defaultItem.name;
            return newItem;
        }

        public Item GetItem(string targetId)
        {
            Item retVal = null;
            itemDict.TryGetValue(targetId, out retVal);
            return retVal;

        }

    }
}