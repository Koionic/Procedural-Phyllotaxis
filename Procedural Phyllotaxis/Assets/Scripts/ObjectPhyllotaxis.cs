using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPhyllotaxis : MonoBehaviour
{

    public GameObject dot;
    [Range(0f, 360f)]
    public float degreeDelta;
    public float scale;
    public int currentIndex;
    public float dotScale;

    public int colourIndex;
    public Color currentColour;
    public List<Color> gradientColours = new List<Color>();

    [Range(0f, 1f)]
    public float gradientLerpRate;
    
    private Vector2 phyllotaxisPosition;

    private List<Vector3> positions = new List<Vector3>();
    private List<GameObject> dots = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        ClearPhyllyotaxis();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            CreateNewPhyllotaxisPoint();
        }
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            ClearPhyllyotaxis();
        }
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
    
    private Vector2 CalculatePhyllotaxis(float inDegreeDelta, float inScale, int inCount, out float rotation)
    {
        double angle = inCount * (inDegreeDelta * Mathf.Deg2Rad);

        rotation = (float)angle * Mathf.Rad2Deg;

        float r = inScale * Mathf.Sqrt(inCount);

        //Calculating the coordinate of the new position
        float x = r * (float) System.Math.Cos(angle);
        float y = r * (float) System.Math.Sin(angle);

        Vector2 vec2 = new Vector2(x, y);
        
        return vec2;
    }

    void CreateNewPhyllotaxisPoint()
    {
        //Calculates 2D position for new dot
        phyllotaxisPosition = CalculatePhyllotaxis(degreeDelta, scale, currentIndex, out float dotRotateZ);

        //Creates and stores 3D position for new dot
        positions.Add(new Vector3(phyllotaxisPosition.x, phyllotaxisPosition.y, 0));

        Vector3 dotRotate = new Vector3(0f, 0f, dotRotateZ);
        
        //Spawns new dot
        GameObject dotInstance = Instantiate(dot, positions[currentIndex], Quaternion.Euler(dotRotate), transform);
            
        dots.Add(dotInstance);
            
        dotInstance.transform.localScale = new Vector3(dotScale, dotScale, dotScale);

        ColourPhyllotaxis(dotInstance);
        
        currentIndex++;
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
        foreach (var dot in dots)
        {
            Destroy(dot);
        }
        
        dots.Clear();
        positions.Clear();

        currentIndex = 0;
    }
}
