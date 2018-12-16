using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SA;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/Mono Actions/LockOnLogic")]
    public class LockOnLogic : Action
    {
        [System.NonSerialized]
        public List<Transform> targets = new List<Transform>(); 
        public InputButton button;
        public StatesManagerVariable states;
        public BoolVariable lockon;

        //count frame
        [System.NonSerialized]
        public float timer;
        public FloatVariable delta;

        public TransformVariable cameraTransform; 

        public override void Execute()
        {
          
            if(button.isPressed)
            {
                if(states.value.isLockingOn)
                {
                    states.value.isLockingOn = false;
                }
                else
                {
                    states.value.isLockingOn = true;
                    FindLockableTargets();
                }
            }

            if(states.value.currentTarget != null)
            {
                timer += delta.value;
                if(timer >2)
                {
                    ValidateTargets();
                    timer = 0;
                }
            }
            else
            {
                states.value.isLockingOn = false;
            }
            lockon.value = states.value.isLockingOn;
            states.value.anim.SetBool("lockon", lockon.value);
        }

        void FindLockableTargets()
        {
            Collider[] cols = Physics.OverlapSphere(states.value.mTransform.position, 10);


            Vector3 camDir = cameraTransform.value.forward;
            camDir.y = 0;
            for (int i = 0; i < cols.Length; i++)
            {
                ILockable l = cols[i].GetComponentInChildren<ILockable>();
                if (l == null)
                    continue;



                float dot = Vector3.Dot(camDir, cols[i].transform.position);
                if (dot > 0)
                {
                    Transform t = l.LockOn();
                    if (t != null)
                    {
                        if(!targets.Contains(t))
                        targets.Add(l.LockOn());
                    }
                }

            }

            float minDist = 100;
            for (int i = 0; i < targets.Count; i++)
            {
                float tempDist = Vector3.Distance(states.value.mTransform.position, targets[i].position);
                if(tempDist<minDist && targets[i] != states.value.currentTarget)
                {
                    minDist = tempDist;
                    states.value.currentTarget = targets[i];
                }
            }


        }

        void ValidateTargets()
        {
            float dist = Vector3.Distance(states.value.currentTarget.position, states.value.mTransform.position);
            if(dist >10)
            {
                states.value.isLockingOn = false; 
            }
        }
    }

   
}