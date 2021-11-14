using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PhylloGroup
{
    public string name;
    
    public float angleMulti = 1f;
    public float scaleMulti = 1f;
    
    public List<TrailPhyllotaxis> trails = new List<TrailPhyllotaxis>();

    public float minScale = 0.1f;
    public float maxScale = 4f;
    
    public void UpdateAngles(float newAngle)
    {
        float angle = newAngle * angleMulti;
        
        for (int i = 0; i < trails.Count; i++)
        {
            trails[i].degreeDelta += angle;
        }    
    }
    
    public void UpdateScales(float newScale)
    {
        float scale = newScale * scaleMulti;
        
        for (int i = 0; i < trails.Count; i++)
        {
            trails[i].scale = Mathf.Clamp(trails[i].scale + scale, minScale, maxScale);
        }    
    }
}

public class PhylloController : MonoBehaviour
{
    public float angleSpeed;
    public float scaleSpeed;
    
    public List<PhylloGroup> groups = new List<PhylloGroup>();
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float deltaAngle = 0;
        float deltaScale = 0;
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            deltaAngle = -1f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            deltaAngle = 1f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            deltaScale = 1f * Time.deltaTime;        
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            deltaScale = -1f * Time.deltaTime;
        }
        
        UpdatePhylloGroups(deltaAngle * angleSpeed, deltaScale * scaleSpeed);
    }

    void UpdatePhylloGroups(float angle, float scale)
    {
        bool updateAngle = Mathf.Abs(angle) > 0;
        bool updateScale = Mathf.Abs(scale) > 0;
        
        for (int i = 0; i < groups.Count; i++)
        {
            if (updateAngle)
            {
                groups[i].UpdateAngles(angle);
            }
            if (updateScale)
            {
                groups[i].UpdateScales(scale);
            }
        }
    }
}
