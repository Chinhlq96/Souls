using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName ="Items/Weapon")]
    public class Weapon : Item
    {
        public string idle_anim;
        public string th_idle_anim;

        public int baseDamage = 30;

        //We know that weapons have a model
        public GameObject modelPrefab;

        public ItemActions rb_Action;
        public ItemActions rt_Action;
        public ItemActions lb_Action;
        public ItemActions lt_Action;

        public ItemActions th_rb_Action;
        public ItemActions th_rt_Action;
        public ItemActions th_lb_Action;
        public ItemActions th_lt_Action;

        public float parryTimer = .2f;

        public ItemActions GetItemActions(StateManager.InputButton b)
        {
            switch (b)
            {
                case StateManager.InputButton.rb:
                    return rb_Action;
                case StateManager.InputButton.rt:
                    return rt_Action;
                case StateManager.InputButton.lb:
                    return lb_Action;
                case StateManager.InputButton.lt:
                    return lt_Action;
                default:
                    return null;
            }
        }

        public ItemActions GetTHItemActions(StateManager.InputButton b)
        {
            switch (b)
            {
                case StateManager.InputButton.rb:
                    return th_rb_Action;
                case StateManager.InputButton.rt:
                    return th_rt_Action;
                case StateManager.InputButton.lb:
                    return th_lb_Action;
                case StateManager.InputButton.lt:
                    return th_lt_Action;
                default:
                    return null;
            }
        }

        public void Init()
        {
            runtime = new RunTimeWeapon();
            runtime.modelInstance = Instantiate(modelPrefab) as GameObject;
            runtime.modelInstance.SetActive(false);

            runtime.weaponHook = runtime.modelInstance.GetComponent<WeaponHook>();
            runtime.weaponHook.Init();
        }

        //everything created in runtime will be here;
        public RunTimeWeapon runtime;

    }
}