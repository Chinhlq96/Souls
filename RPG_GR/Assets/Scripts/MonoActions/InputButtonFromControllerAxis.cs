using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SA 
{
    [CreateAssetMenu(menuName = "Actions/Mono Actions/Inputs/InputButtonFromControllerAxis")]
    public class InputButtonFromControllerAxis : ScriptableObject
    {
        public string targetAxis;
        public bool isPressed;
        public float axisThreshold = 0.5f;
        public bool isNegative;

        bool isHolding;
        public ButtonState buttonState;

        public void Execute()
        {
            float targetValue = Input.GetAxis(targetAxis);
            Debug.Log(targetValue);
            switch (buttonState)
            {
                case ButtonState.onDown:
                    if (isHolding)
                    {
                        isPressed = false;
                        isHolding =(targetValue > axisThreshold);
                    }
                    if(targetValue < axisThreshold)
                    {
                        if(!isHolding)
                        {
                            isPressed = true;
                            isHolding = true;
                        }
                    }
                    break;
                case ButtonState.onCurrent:
                    if (isNegative)

                        isPressed = (targetValue < axisThreshold) ;
                    else isPressed = targetValue > axisThreshold;
                        break;

                case ButtonState.onUp:
                    if(isHolding)
                    {
                        if(targetValue > axisThreshold)
                        {
                            isPressed = true;
                            isHolding = false;
                        }
                       
                    }
                    else
                    {
                        isPressed = false;
                    }

                    if (targetValue < axisThreshold)
                    {
                        isHolding = true;
                        isPressed = false;
                    }

                    break;
                default:
                    break;
            }
        }


    }
}
