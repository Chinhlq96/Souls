using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SA
{
    [CreateAssetMenu(menuName = "Actions/Mono Actions/Inputs/Button")]
    public class InputButton : Action
    {
        public string targetButton;
        public ButtonState buttonState;
        public bool isPressed;
        public InputButtonFromControllerAxis controllerAxis;


        public override void Execute()
        {
            if(controllerAxis != null)
            {
                controllerAxis.Execute();
                isPressed = controllerAxis.isPressed;
                if(isPressed)
                {
                    return;
                }
            }

            switch (buttonState)
            {
                case ButtonState.onDown:
                    isPressed = Input.GetButtonDown(targetButton);
                    break;
                case ButtonState.onCurrent:
                    isPressed = Input.GetButton(targetButton); 
                    break;
                case ButtonState.onUp:
                    isPressed = Input.GetButtonUp(targetButton);
                    break;
                default:
                    break;
            }
        }
    }

    public enum ButtonState
    {
        onDown, onCurrent, onUp
    }
}