using UnityEngine;
using System.Collections;

namespace SA
{
    public class CharacterViz : MonoBehaviour
    {
        public SMeshHolder[] meshHolders;

        public void WearListOfClothes(ClothItem[] cloths)
        {
            for (int i = 0; i < cloths.Length; i++)
            {
                WearCloth(cloths[i]);
            }
        }

        public void WearCloth(ClothItem c)
        {
            Debug.Log(c);
            SMeshHolder m = GetMeshHolder(c.bodyPart);
            m.meshRenderer.sharedMesh = c.mesh;
            m.meshRenderer.material = c.material;
            m.meshRenderer.enabled = true;
        }

        public SMeshHolder GetMeshHolder(BodyPart b)
        {
            SMeshHolder result = null;
            for (int i = 0; i < meshHolders.Length; i++)
            {
                if(meshHolders[i].bodyPart==b)
                {
                    result = meshHolders[i];
                    break;
                }
            }

            return result;
        }

        public void SetToDefault()
        {
            for (int i = 0; i < meshHolders.Length; i++)
            {
                SMeshHolder m = meshHolders[i];
                if(m.bodyPart.disableIfNoItem)
                {
                    m.meshRenderer.enabled = false;
                }
                else
                {

                }
            }
        }
    }
}