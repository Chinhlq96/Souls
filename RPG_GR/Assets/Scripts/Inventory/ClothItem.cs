using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName ="Items/Cloth")]
    public class ClothItem : Item
    {
        public Mesh mesh;
        public Material material;

        public BodyPart bodyPart;

    }
}