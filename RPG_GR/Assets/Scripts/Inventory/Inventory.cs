using UnityEngine;
using System.Collections;

namespace SA
{
    //This is player's current inventory
    // not confuse with resourcesManager which is store all Items
    [System.Serializable]
    public class Inventory
    {
        [HideInInspector]
        public ItemActions currentItemAction;
        public Weapon unarmedWeapon;


        public Vector3Variable leftHandPosition;
        public Vector3Variable leftHandRotation;

         int r_index = -1;
         int l_index = -1;
        public Weapon[] rightHandSlots = new Weapon[2];
        public Weapon[] leftHandSlots = new Weapon[2];

        private Weapon _rightHandWeapon;
        public Weapon rightHandWeapon
        {
            get {
                if(_rightHandWeapon == null)
                {
                    return unarmedWeapon;
                }
                return _rightHandWeapon; }
        }

        private Weapon _twoHandedWeapon;
        public Weapon twoHandedWeapon
        {
            get {
                if (_rightHandWeapon == null)
                {
                    return unarmedWeapon;
                }
                return _twoHandedWeapon; }
        }

        private Weapon _leftHandWeapon;
        public Weapon leftHandWeapon
        {
            get {
                if (_leftHandWeapon == null)
                {
                    return unarmedWeapon;
                }
                return _leftHandWeapon; }
        }

        public ItemVariable rhWeaponVariable;
        public ItemVariable lhWeaponVariable;

        private Spell _spell;
        public Spell spell {
            get { return _spell; }
        }

        public ItemVariable spellItem;
        public void SetSpell(Spell s, bool updateReferences)
        {
            _spell = s;
            if(updateReferences)
            {
            //    spellItem.value = s;
            }
        }

        public void SetFirstWeapon(bool isLeft)
        {
            if(isLeft)
            {
                l_index = -1;
            }
            else
            {
                r_index = -1;
            }
        }

        public Weapon GetNextWeaponOnSlot(bool isLeft)
        {
            Weapon[] wArray = rightHandSlots;
            int tIndex = 0;
            if(isLeft)
            {
                wArray = leftHandSlots;
                l_index++;
                if (l_index > leftHandSlots.Length - 1)
                {
                    l_index = -1;
                    return unarmedWeapon;
                }
                tIndex = l_index;
            }
            else
            {
                r_index++;
                if (r_index > rightHandSlots.Length - 1)
                {
                    r_index = -1;
                    return unarmedWeapon;
                } 
                tIndex = r_index;
            }

            if(tIndex>wArray.Length -1)
            {
                return unarmedWeapon;
            }
            if (wArray[tIndex] == null)
            {
                if(isLeft)
                {
                    r_index = -1;   
                }
                else
                {
                    l_index = -1;
                }
                return unarmedWeapon;
            }


            return wArray[tIndex];
        }

        public void SetWeapon(Weapon w,bool isLeft,bool updateReferences)
        {
            if(isLeft)
            {
                _leftHandWeapon = w; 
                //true if this is a player
                if(updateReferences)
                {
                    lhWeaponVariable.value = w;
                }
            }
            else
            {
                _rightHandWeapon = w;
                if (updateReferences)
                {
                    rhWeaponVariable.value = w;
                }
            }
        }



        public void TwoHanded(Animator anim, bool isTwoHanded)
        {
            bool isLeftHand = false;
            Weapon targetWeapon = null;

            if(_rightHandWeapon != null)
            {
                if(_rightHandWeapon != unarmedWeapon)
                {
                    targetWeapon = _rightHandWeapon;
                }
            }

            if(targetWeapon==null)
            {
                if(_leftHandWeapon!=null)
                {
                    if(_leftHandWeapon!= unarmedWeapon)
                    {
                        targetWeapon = leftHandWeapon;
                        isLeftHand = true;
                    }
                }
            }

            if(targetWeapon == null)
            {
                targetWeapon = unarmedWeapon;
            }


            if (isTwoHanded)
            {
                Debug.Log("2hand");
                _twoHandedWeapon = targetWeapon;
                anim.CrossFade(targetWeapon.th_idle_anim, 0.2f);
                if(targetWeapon!= _leftHandWeapon)
                {
                    if (_leftHandWeapon != null)
                        _leftHandWeapon.runtime.weaponHook.gameObject.SetActive(false);
                }
            }
            else
            {
                Debug.Log("1hand");
                _twoHandedWeapon = null;
                string targetAnim = targetWeapon.idle_anim + ((isLeftHand) ? "_l" : "_r");
                anim.Play("Empty Both");
                anim.CrossFade(targetAnim, 0.2f);

                if (targetWeapon != _leftHandWeapon)
                {
                    if(_leftHandWeapon!=null)
                     _leftHandWeapon.runtime.modelInstance.SetActive(true);
                }
            }

            anim.CrossFade("changeWeapon", 0.2f);
        }
    }
}