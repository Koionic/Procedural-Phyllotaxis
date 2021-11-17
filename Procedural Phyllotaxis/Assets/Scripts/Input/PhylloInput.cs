using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PhylloInput : MonoBehaviour
{
    public PhylloController controller;

    public UnityEvent playerInputExecuted;
    
    public void TrailDown()
    {
        controller.UpdateNumberOfTrails(-1);
    }

    public void TrailUp()
    {
        controller.UpdateNumberOfTrails(1);
    }

    public void CameraPosition(Vector2 input)
    {
        controller.UpdateCameraPosition(input);
    }

    public void TrailAngle(float input)
    {
        controller.UpdateAngle(input);
    }
    
    public void TrailScale(float input)
    {
        controller.UpdateScale(input);
    }

    public void TrailInvert()
    {
        controller.invertNextFrame = true;
    }
    
    public void GamepadDown(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            TrailDown();
        }
        
        playerInputExecuted.Invoke();
    }

    public void GamepadUp(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            TrailUp();
        }
        
        playerInputExecuted.Invoke();
    }
    
    public void GamepadLeftStick(InputAction.CallbackContext context)
    {
        CameraPosition(context.ReadValue<Vector2>());
        
        playerInputExecuted.Invoke();
    }

    public void GamepadShoulders(InputAction.CallbackContext context)
    {
        TrailAngle(context.ReadValue<float>());
        
        playerInputExecuted.Invoke();
    }
    
    public void GamepadTriggers(InputAction.CallbackContext context)
    {
        TrailScale(context.ReadValue<float>());

        playerInputExecuted.Invoke();
    }

    public void MainTrigger(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            TrailInvert();
        }
        
        playerInputExecuted.Invoke();
    }
}
