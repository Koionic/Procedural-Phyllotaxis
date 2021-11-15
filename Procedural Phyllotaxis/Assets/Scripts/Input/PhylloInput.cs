using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PhylloInput : MonoBehaviour
{
    public PhylloController controller;

    public void GamepadDown(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            controller.UpdateNumberOfTrails(-1);
        }
    }

    public void GamepadUp(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            controller.UpdateNumberOfTrails(1);
        }
    }
    
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

    public void MainTrigger(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            controller.invertNextFrame = true;
        }
    }
}
