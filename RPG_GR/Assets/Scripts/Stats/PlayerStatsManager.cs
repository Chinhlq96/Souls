using UnityEngine;
using System.Collections;

namespace SA
{
    [CreateAssetMenu(menuName ="Managers/Player Stats")]
    public class PlayerStatsManager : ScriptableObject
    {
        public Stat health;
        public Stat stamina;

    }
}