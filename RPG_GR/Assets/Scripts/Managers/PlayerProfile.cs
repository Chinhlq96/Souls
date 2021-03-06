﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Managers/Profile")]
    public class PlayerProfile : ScriptableObject
    {
        public string profileName;

        public string[] rightHandWeapons;
        public string[] leftHandSlots;
        public string[] spellId;

        public List<string> allItemsWeHave = new List<string>();

        public string[] wearedClothItems;

        public StatsHolder[] allStats;

        [System.NonSerialized]
        public Item[] rightHandWeaponItems;
        [System.NonSerialized]
        public Item[] leftHandWeaponItems;
        [System.NonSerialized]
        public List<ClothItem> clothItems = new List<ClothItem>();

        public void SetStatsToStaringValue()
        {
            for (int i = 0; i < allStats.Length; i++)
            {
                allStats[i].targetStat.Set(allStats[i].startingValue);
            }
        }

    }
}