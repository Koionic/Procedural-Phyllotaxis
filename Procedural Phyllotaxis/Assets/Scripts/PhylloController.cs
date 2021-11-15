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

    [Header("Trail Altering")]
    public bool allowTrailAmountChange = false;
    public int currentAmount;
    public int minAmount;
    public int maxAmount;
    
    
    void Awake()
    {
        
    }
    
    public void UpdateAngles(float newAngle)
    {
        if (angleMulti == 0)
            return;
        
        float angle = newAngle * angleMulti;

        for (int i = 0; i < trails.Count; i++)
        {
            trails[i].degreeDelta += angle;
        }    
    }
    
    public void UpdateScales(float newScale)
    {
        if (scaleMulti == 0)
            return;
        
        float scale = newScale * scaleMulti;
        
        for (int i = 0; i < trails.Count; i++)
        {
            trails[i].scale = Mathf.Clamp(trails[i].scale + scale, minScale, maxScale);
        }    
    }

    public void ChangeAmountOfTrails(int newAmount)
    {
        for (int i = 0; i < trails.Count; i++)
        {
            trails[i].enabled = false;
        }

        int newAngle = Mathf.RoundToInt(360 / newAmount);
        
        for (int i = 0; i < newAmount; i++)
        {
            trails[i].degreeDelta = newAngle;
            trails[i].stepSize = 1;
            trails[i].numberStart = i;
            trails[i].ClearPhyllyotaxis(false);
            trails[i].enabled = true;
        }
    }
}

public class PhylloController : MonoBehaviour
{
    public float angleSpeed;
    public float scaleSpeed;
    
    float deltaAngle = 0;
    float deltaScale = 0;

    private Vector2 desiredCameraPos;
    
    public List<PhylloGroup> groups = new List<PhylloGroup>();

    public GameObject camera;
    
    public float cameraRange;
    
    [Range(0f,1f)]
    public float cameraSpeed;
    
    [Range(0f,1f)]
    public float cameraRecoverSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateCameraPosition();
        
        UpdatePhylloGroups(deltaAngle * angleSpeed, deltaScale * scaleSpeed, 0);
    }

    void UpdatePhylloGroups(float angle, float scale, int newAmount)
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

            if (groups[i].allowTrailAmountChange && newAmount > 0)
            {
                groups[i].ChangeAmountOfTrails(newAmount);
            }
        }
    }

    public void UpdateScale(float input)
    {
        deltaScale = input;
    }
    public void UpdateAngle(float input)
    {
        deltaAngle = input;    
    }

    public void UpdatePosition(Vector2 newPos)
    {
        desiredCameraPos = newPos * cameraRange;
    }

    public void UpdateCameraPosition()
    {
        camera.transform.localPosition = Vector3.Lerp(camera.transform.localPosition, desiredCameraPos, cameraSpeed);
    }
}
