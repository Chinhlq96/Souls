using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SA
{

    //static class so we can access this from anywhere
    public static class GameManager
    {
        
        static ResourcesManager resourcesManager;

        public static ResourcesManager GetResourcesManager()
        {

            //if null then this is the first time we call this 
            if(resourcesManager == null)
            {
                //load item from the asset "ResourcesManager" in folder "Resource" folder
                resourcesManager = Resources.Load("ResourcesManager") as ResourcesManager;
                resourcesManager.Init();
            }

            return resourcesManager;
        }

    }
}