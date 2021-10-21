using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailPhyllotaxis : MonoBehaviour
{
    [Range(0f, 360f)]
    public float degreeDelta;
    public float scale;

    public int maxIteration;
    public int stepSize;
    private int currentIteration;
    
    
    public bool useLerp;
    public float intervalLerp;
    private bool isLerping;
    private Vector3 startPosition, endPosition;
    private float timeStartedLerp;
    
    public int numberStart;
    private int number;

    private TrailRenderer _trailRenderer;
    
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
    }

    // Start is called before the first frame update
    void Start()
    {
        ClearPhyllyotaxis();
        
        number = numberStart;
        transform.localPosition = CalculatePhyllotaxis(degreeDelta, scale, number);

        if (useLerp)
        {
            StartLerping();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CreateNewPhyllotaxisPoint();
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            ClearPhyllyotaxis();
            
            Awake();
        }
    }

    void StartLerping()
    {
        isLerping = true;
        timeStartedLerp = Time.time;
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
                float timeSinceStarted = Time.time - timeStartedLerp;
                float percentageComplete = timeSinceStarted / intervalLerp;
                transform.localPosition = Vector3.Lerp(startPosition, endPosition, percentageComplete);

                if (percentageComplete >= 0.99f)
                {
                    transform.localPosition = endPosition;
                    number += stepSize;
                    currentIteration++;

                    if (currentIteration <= maxIteration)
                    {
                        StartLerping();
                    }
                    else
                    {
                        isLerping = false;
                    }
                }
            }
        }
        else
        {
            //Calculates 2D position for new dot
            phyllotaxisPosition = CalculatePhyllotaxis(degreeDelta, scale, number);

            // //Creates and stores 3D position for new dot
            // positions.Add(new Vector3(phyllotaxisPosition.x, phyllotaxisPosition.y, 0));
            //
            // transform.localPosition = positions[number];

            transform.localPosition = new Vector3(phyllotaxisPosition.x, phyllotaxisPosition.y, 0);

            number+= stepSize;
            currentIteration++;
        }
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

    private void ClearPhyllyotaxis()
    {
        positions.Clear();

        currentIteration = 0;
        
        number = numberStart;
        
        _trailRenderer.Clear();

        transform.localPosition = Vector3.zero;
        startPosition = Vector3.zero;
        endPosition = Vector3.zero;
    }
}
