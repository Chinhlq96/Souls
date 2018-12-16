using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class WeaponHook : MonoBehaviour
    {
        DamageCollider[] damageColliders;

        public void Init()
        {
            damageColliders = transform.GetComponentsInChildren<DamageCollider>();

            for (int i = 0; i < damageColliders.Length; i++)
            {
                damageColliders[i].collider.isTrigger = true;
                damageColliders[i].collider.enabled = false;
            }
        }

        public void SetColliderStatus(bool status)
        {
            for (int i = 0; i < damageColliders.Length; i++)
            {
                damageColliders[i].collider.enabled = status;
            }
        }

    }
}