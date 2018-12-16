using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public abstract class Item : ScriptableObject
    {
        public string ui_name;
        public Sprite icon;

        
        //we do the instance of the item so we can change stats thats already exist 
        // inside the item, instead of saving it somewhere else
        //stats
        //public int durabilityCurrent;
        //public int durabilityMax;

    }
}