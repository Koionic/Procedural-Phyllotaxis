using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PhylloInput : MonoBehaviour
{
    public PhylloController controller;
    
    public void GamepadLeftStick(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        
        controller.UpdatePosition(input);
    }

    public void GamepadShoulders(InputAction.CallbackContext context)
    {
        float input = context.ReadValue<float>();
        
        controller.UpdateAngle(input);
    }
    
    public void GamepadTriggers(InputAction.CallbackContext context)
    {
        float input = context.ReadValue<float>();
        
        controller.UpdateScale(input);
    }
}
