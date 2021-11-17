using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPhyllo : MonoBehaviour
{
    public float autoPilotTime;
    private float autoPilotTimer;
    public bool autoPilotOn;

    public float autoPilotJoystick;
    public float autoPilotJoystickInt;
    
    public bool autoScaleOn;
    private float autoScaleTimer;
    public float autoScalePeriod;
    public float autoScaleCooldown;

    float autoInvertTimer;
    public float autoInvertMin;
    public float autoInvertMax;
    
    float autoAmountTimer;
    public float autoAmountMin;
    public float autoAmountMax;

    private PhylloInput input;

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<PhylloInput>();

        input.playerInputExecuted.AddListener(StopAutoPilot);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (autoPilotOn)
        {
            AutoPilotUpdate();
        }
        else
        {
            autoPilotTimer += Time.deltaTime;

            if (autoPilotTimer >= autoPilotTime)
            {
                StartAutoPilot();
            }
        }
    }

    public void AutoPilotUpdate()
    {
        AutoScaleUpdate();
        
        AutoAmountUpdate();
        
        AutoInvertUpdate();
    }

    #region Scale

    public void AutoScaleUpdate()
    {
        autoScaleTimer += Time.deltaTime;

        if (autoScaleOn)
        {
            if (autoScaleTimer >= autoScalePeriod)
            {
                StopAutoScale();
            }

            float noise = Mathf.PerlinNoise(Time.time, 0);
            
            autoPilotJoystickInt = Mathf.RoundToInt((noise * 4) - 2);

            autoPilotJoystickInt = Mathf.Clamp(autoPilotJoystickInt, -1, 1);
            
            autoPilotJoystick = Mathf.Lerp(autoPilotJoystick, autoPilotJoystickInt, 0.3f);
            
            input.TrailScale(autoPilotJoystick);
        }
        else
        {
            if (autoScaleTimer >= autoScaleCooldown)
            {
                StartAutoScale();
            }
        }
    }

    public void StartAutoScale()
    {
        autoScaleOn = true;
        
        autoScaleTimer = 0f;
    }

    public void StopAutoScale()
    {
        autoScaleOn = false;

        autoScaleTimer = 0f;
    }

    #endregion

    #region Invert

    public void AutoInvertUpdate()
    {
        autoInvertTimer -= Time.deltaTime;

        if (autoInvertTimer <= 0f)
        {
            autoInvertTimer = Random.Range(autoInvertMin, autoInvertMax);
            
            print("auto invert");
            input.TrailInvert();
        }
    }
    
    #endregion

    #region Trail Amount
    
    public void AutoAmountUpdate()
    {
        autoAmountTimer -= Time.deltaTime;

        if (autoAmountTimer <= 0f)
        {
            autoAmountTimer = Random.Range(autoAmountMin, autoAmountMax);

            if (Random.Range(0, 2) == 0)
            {
                print("Trail up");
                input.TrailUp();
            }
            else
            {
                print("Trail down");
                input.TrailDown();
            }
        }
    }
    
    #endregion
    
    public void StartAutoPilot()
    {
        autoPilotOn = true;
        
        autoInvertTimer = Random.Range(autoInvertMin, autoInvertMax);

        autoAmountTimer = Random.Range(autoAmountMin, autoAmountMax);
    }
    
    public void StopAutoPilot()
    {
        autoPilotOn = false;

        autoPilotTimer = 0f;
    }
    

}
