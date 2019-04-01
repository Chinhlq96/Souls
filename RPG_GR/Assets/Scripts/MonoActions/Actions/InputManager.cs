﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu]
    public class InputManager : Action
    {
        public InputAxis horizontal;
        public InputAxis vertical;
        public InputAxis mouseX;
        public InputAxis mouseY;
        public InputButton RB;
        public InputButton RT;
        public InputButton LB;
        public InputButton LT;
        public InputButton Lockon;
        public InputButton y_Input;
        public InputButton inventoryPrompt;

        public GameEvent onInventory;
        public GameEvent onGame;

        public bool isInMenu;

        public InputButton b_Input;

        public float moveAmount;
        public Vector3 rotateDirection;

        public TransformVariable cameraTransform;

        public StatesManagerVariable playerStates;

        public PlayerInventory inventoryMonitor;

        public UI_InventoryManager inventoryManager;

        public override void Execute()
        {
            mouseX.Execute();
            mouseY.Execute();
            horizontal.Execute();
            vertical.Execute();
            RB.Execute();
            RT.Execute();
            LB.Execute();
            LT.Execute();
            b_Input.Execute();
            Lockon.Execute();
            y_Input.Execute();
            inventoryPrompt.Execute();

            bool leftArrow;
            bool rightArrow;
            bool upArrow;
            bool downArrow;

            if(inventoryPrompt.isPressed)
            {
                if(isInMenu)
                {
                    isInMenu = false;
                    onGame.Raise();
                }
                else
                {
                    isInMenu = true;
                    onInventory.Raise();
                }
            }
            

            moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal.value) + Math.Abs(vertical.value));
            if(cameraTransform.value != null)
            {
                rotateDirection = cameraTransform.value.forward * vertical.value;
                rotateDirection += cameraTransform.value.right * horizontal.value;
            }
            if (playerStates.value == null)
                return;

            playerStates.value.horizontal = horizontal.value;
            playerStates.value.vertical = vertical.value;
            playerStates.value.moveAmount = moveAmount;
            playerStates.value.rotateDirection = rotateDirection;

            if (!isInMenu)
            {
                playerStates.value.rb = RB.isPressed;
                playerStates.value.rt = RT.isPressed;
                playerStates.value.lb = LB.isPressed;
                playerStates.value.lt = LT.isPressed;

                if (y_Input.isPressed)
                {
                    playerStates.value.isTwoHanded = !playerStates.value.isTwoHanded;
                    playerStates.value.inventory.TwoHanded(playerStates.value.anim, playerStates.value.isTwoHanded);

                }
            }
            else
            {

            }

            inventoryMonitor.Execute(playerStates.value);
        }



    }
}
