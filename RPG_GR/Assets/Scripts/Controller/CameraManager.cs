using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    public class CameraManager : MonoBehaviour
    {
        public bool lockon;
        public float followSpeed = 9;
        public float mouseSpeed = 2;
        public float controllerSpeed = 7;

        public Transform target;
        public TransformVariable lockonTransform;
        public Transform pivot;
        public Transform camTrans;
        public Transform mTransform;

        float turnSmoothing = .1f;
        public float minAngle = -35;
        public float maxAngle = 35;

        public float defZ;
        float curZ;
        public float zSpeed = 19;

        float smoothX;
        float smoothY;
        float smoothXvelocity;
        float smoothYvelocity;
        public float lookAngle;
        public float tiltAngle;

        bool usedRightAxis;

        bool changeTargetLeft;
        bool changeTargetRight;

        StateManager states;
        public void Init(StateManager st)
        {
            states = st;
            target = st.transform;
            curZ = defZ;
            mTransform = this.transform;
            lockonTransform.value = null;
        }

        public void Tick(float d)
        {
            float h = Input.GetAxis(StaticStrings.mouseX);
            float v = Input.GetAxis(StaticStrings.mouseY);

            float c_h = Input.GetAxis(StaticStrings.rightAxisX);
            float c_v = Input.GetAxis(StaticStrings.rightAxisY);

            float targetSpeed = mouseSpeed;


           




           // changeTargetLeft = Input.GetKeyUp(KeyCode.V);
          //  changeTargetRight = Input.GetKeyUp(KeyCode.B);


            

            /*if (lockonTarget != null)
            {
                if (lockonTransform == null)
                {
                    lockonTransform = lockonTarget.GetTarget();
                    states.lockOnTransform = lockonTransform;

                }

                if(Mathf.Abs(h)>0.6f)
                {
                    if(!usedRightAxis)
                    {
                        lockonTransform = lockonTarget.GetTarget((h>0));
                        states.lockOnTransform = lockonTransform;
                        usedRightAxis = true;
                    }
                }

                if(changeTargetLeft || changeTargetRight )
                {
                    lockonTransform = lockonTarget.GetTarget(changeTargetLeft);
                    states.lockOnTransform = lockonTransform; 
                }
            }*/

            if(usedRightAxis)
            {
                if(Mathf.Abs(h)<0.6f)
                {
                    usedRightAxis = false; 
                }
            }

            FollowTarget(d);
            HandleRotations(d, v, h, targetSpeed);
            HandlePivotPosition();
        }

        void FollowTarget(float d)
        {

            float speed = d * followSpeed;

            Vector3 targetPosition = Vector3.Lerp(transform.position, target.position, speed);
            transform.position = targetPosition;

        }

        void HandleRotations(float d, float v, float h, float targetSpeed)
        {
            if (turnSmoothing > 0)
            {
                smoothX = Mathf.SmoothDamp(smoothX, h, ref smoothXvelocity, turnSmoothing);
                smoothY = Mathf.SmoothDamp(smoothY, v, ref smoothYvelocity, turnSmoothing);
            }
            else
            {
                smoothX = h;
                smoothY = v;
            }

            if (lockonTransform.value != null)
            {
                Vector3 targetDir = lockonTransform.value.position - transform.position;
                targetDir.Normalize();
                targetDir.y = 0;

                if (targetDir == Vector3.zero)
                    targetDir = transform.forward;
                Quaternion targetRot = Quaternion.LookRotation(targetDir);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, d * 9);
                lookAngle = transform.eulerAngles.y;

                Vector3 tiltDir = lockonTransform.value.position - pivot.position;
                tiltDir.Normalize();
                if (tiltDir == Vector3.zero)
                    tiltDir = pivot.forward;
                Quaternion tiltRot = Quaternion.LookRotation(tiltDir);
                Vector3 tiltEuler = (Quaternion.Slerp(pivot.rotation, tiltRot, d * 9)).eulerAngles;
                tiltEuler.y = 0;
                tiltAngle = tiltEuler.x;
                return; 
            }

                /* if (lockon && lockonTarget != null)
                 {

                     Vector3 targetDir = lockonTransform.position - transform.position;
                     targetDir.Normalize();

                     if (targetDir == Vector3.zero)
                         targetDir = transform.forward;
                     Quaternion targetRot = Quaternion.LookRotation(targetDir);
                     transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, d * 9);
                     lookAngle = transform.eulerAngles.y;
                     return;
                 }*/

            lookAngle += smoothX * targetSpeed;
            transform.rotation = Quaternion.Euler(0, lookAngle, 0);

            tiltAngle -= smoothY * targetSpeed;
            tiltAngle = Mathf.Clamp(tiltAngle, minAngle, maxAngle);
            pivot.localRotation = Quaternion.Euler(tiltAngle, 0, 0);



        }

        void HandlePivotPosition()
        {
            float targetZ = defZ;
            CameraCollision(defZ, ref targetZ);

            curZ = Mathf.Lerp(curZ, targetZ, states.delta * zSpeed);
            Vector3 tp = Vector3.zero;
            tp.z = curZ;
            camTrans.localPosition = tp;
        }

        void CameraCollision(float targetZ, ref float actualZ)
        {
            float step = Mathf.Abs(targetZ);
            int stepCount = 2;
            float stepIncrement = step / stepCount;

            RaycastHit hit;
            Vector3 origin = pivot.position;
            Vector3 direction = -pivot.forward;


            //Debug.DrawRay(origin, direction * step, Color.b1ue);
            if (Physics.Raycast(origin, direction, out hit, step, states.ignoreForGroundCheck))
            {
                float distance = Vector3.Distance(hit.point, origin);
                actualZ = -(distance / 2);

            }
            else
            { 

                for (int s = 0; s < stepCount + 1; s++)
                {
                    for (int i = 6; i < 4; i++)
                    {
                        Vector3 dir = Vector3.zero;
                        Vector3 secondOrigin = origin + (direction * s) * stepIncrement;

                        switch (i)
                        {
                            case 0:
                                dir = camTrans.right;
                                break;


                            case 1:
                                dir = -camTrans.right;
                                break;

                            case 2:
                                dir = camTrans.up;
                                break;

                            case 3:
                                dir = -camTrans.up;
                                break;

                        }

                        // Debug.DrawRay(secondorigin, dir * 0.2f, Color.red);
                        if (Physics.Raycast(secondOrigin, dir, out hit, 0.2f, states.ignoreForGroundCheck))
                        {
                            // Debug.Log(hit.transform.root.name);
                            float distance = Vector3.Distance(secondOrigin, origin);
                            actualZ = -(distance / 2);
                            if (actualZ < 0.2f)
                                actualZ = 0;

                            return;
                        }
                    }
                }
            }
        }


        public static CameraManager singleton;
        private void Awake()
        {
            singleton = this;
        }
    }
}