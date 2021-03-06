﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName ="Single Instances/Controller Stats")]
    public class ControllerStats : ScriptableObject
    {
        public float walkSpeed;
        public float moveSpeed;
        public float rollSpeed;
        public float backstepSpeed;
        public float sprintSpeed;
        public float rotateSpeed;
   
    }
}