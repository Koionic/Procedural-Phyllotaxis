using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailPhyllotaxis : MonoBehaviour
{
    [Range(-180, 180f)]
    public float degreeDelta;
    public float scale;

    public bool mirrored;
    
    public int maxIteration;
    public int stepSize;
    private int currentIteration;
    private int numberIncrement;
    private int iterationIncrement = 1;

    [Header("Time Based Values")] 
    public float timeInterval;
    private float timer;
    
    
    [Header("Lerping")]
    public bool useLerp;
    private float lerpTimer;
    public float intervalLerp;
    private bool isLerping;
    private Vector3 startPosition, endPosition;
    
    public int numberStart;
    private int number;

    public TrailRenderer _trailRenderer;
    
    public int colourIndex;
    public Color currentColour;
    public List<Color> gradientColours = new List<Color>();

    [Range(0f, 1f)]
    public float gradientLerpRate;
    
    private Vector2 phyllotaxisPosition;
    
    private List<Vector3> positions = new List<Vector3>();

    private void Awake()
    {
        _trailRenderer = GetComponent<TrailRenderer>();

        GradientColorKey[] colorKey = new GradientColorKey[2];
        colorKey[0].color = currentColour;
        colorKey[0].time = 0.0f;
        colorKey[1].color = Color.black;
        colorKey[1].time = 1.0f;
        
        GradientAlphaKey[] alphaKey = new GradientAlphaKey[2];
        alphaKey[0].alpha = 1.0f;
        alphaKey[0].time = 0.0f;
        alphaKey[1].alpha = 0.0f;
        alphaKey[1].time = 0.5f;

        _trailRenderer.colorGradient.SetKeys(colorKey, alphaKey);
    }

    // Start is called before the first frame update
    void Start()
    {
        number = numberStart + stepSize;
        numberIncrement = stepSize;
        transform.localPosition = (Vector3)CalculatePhyllotaxis(degreeDelta, scale, number);

        if (useLerp)
        {
            StartLerping();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CreateNewPhyllotaxisPoint();
        
        // if (Input.GetKeyDown(KeyCode.C))
        // {
        //     ClearPhyllyotaxis();
        //     
        //     Awake();
        // }
    }

    public void StartLerping()
    {
        isLerping = true;
        lerpTimer = 0;
        number += numberIncrement;
        phyllotaxisPosition = CalculatePhyllotaxis(degreeDelta, scale, number);
        startPosition = transform.localPosition;
        
        endPosition = new Vector3(phyllotaxisPosition.x, phyllotaxisPosition.y, 0f);
    }

    /// <summary>
    /// Calculates the position of the dot using the phyllotaxis formula
    /// </summary>
    /// <param name="inDegreeDelta"></param>
    /// The change in angle per step in degrees
    /// <param name="inScale"></param>
    /// <param name="inCount"></param>
    /// The iteration into the pattern
    /// <returns></returns>
    private Vector2 CalculatePhyllotaxis(float inDegreeDelta, float inScale, int inCount)
    {
        double angle = inCount * (inDegreeDelta * Mathf.Deg2Rad);

        if (mirrored)
        {
            angle *= -1.0;
        }
        
        float r = inScale * Mathf.Sqrt(inCount);

        //Calculating the coordinate of the new position
        float x = r * (float) System.Math.Cos(angle);
        float y = r * (float) System.Math.Sin(angle);

        Vector2 vec2 = new Vector2(x, y);
        
        return vec2;
    }

    void CreateNewPhyllotaxisPoint()
    {
        if (useLerp)
        {
            if (isLerping)
            {
                lerpTimer += Time.deltaTime;
                float percentageComplete = lerpTimer / intervalLerp;

                transform.localPosition = Vector3.Lerp(startPosition, endPosition, percentageComplete);

                if (percentageComplete >= 1f)
                {
                    transform.localPosition = endPosition;
                    //number += iterationIncrement;
                    currentIteration += iterationIncrement;

                    if ((currentIteration == maxIteration && numberIncrement > 0) || (currentIteration == stepSize && numberIncrement < 0))
                    {
                        InvertPhyllotaxis();
                    }
                    else
                    {
                        StartLerping();
                    }
                }
            }
        }
        else
        {
            if (timer >= timeInterval)
            {
                timer = 0;

                //Calculates 2D position for new dot
                phyllotaxisPosition = CalculatePhyllotaxis(degreeDelta, scale, number);

                // //Creates and stores 3D position for new dot
                // positions.Add(new Vector3(phyllotaxisPosition.x, phyllotaxisPosition.y, 0));
                //
                // transform.localPosition = positions[number];

                transform.localPosition = new Vector3(phyllotaxisPosition.x, phyllotaxisPosition.y, 0);

                number += numberIncrement;
                currentIteration += iterationIncrement;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
    }

    public void InvertPhyllotaxis()
    {
        print("flipping iteration");
        numberIncrement *= -1;
        iterationIncrement *= -1;
        
        StartLerping();
    }
    
    public void ColourPhyllotaxis(GameObject dot)
    {
        currentColour = Color.Lerp(currentColour, gradientColours[colourIndex], gradientLerpRate);

        dot.GetComponentInChildren<MeshRenderer>().material.color = currentColour;

        if (currentColour == gradientColours[colourIndex])
        {
            colourIndex = (colourIndex + 1) % gradientColours.Count;
        }
    }

    public void ClearPhyllyotaxis(bool hardReset)
    {
        positions.Clear();

        currentIteration = stepSize;

        iterationIncrement = 1;
        numberIncrement = Mathf.Abs(numberIncrement);
        
        number = numberStart + stepSize;

        if (hardReset)
        {
            _trailRenderer.Clear();
        }

        //transform.localPosition = Vector3.zero;
        //startPosition = Vector3.zero;
        //endPosition = Vector3.zero;

        if (useLerp)
        {
            StartLerping();
        }
    }
}
