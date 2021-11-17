using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PhylloGroup
{
    public string name;
    
    public float angleMulti = 1f;
    public float scaleMulti = 1f;
    
    public float minScale = 0.1f;
    public float maxScale = 4f;

    [Header("Trail Altering")]
    public bool allowTrailAmountChange = false;
    public int currentAmount;
    public int minAmount;
    public int maxAmount;

    public bool allowTrailInvert;

    public GameObject trailParent;

    [Header("Colour Altering")] 
    public float colorTimer;

    public float colorInterval;

    public Color currentColor;
    public Color nextColor;
    public Color previousColor;
    public int currentColorIndex;
    public List<Color> colors = new List<Color>();

    public List<TrailPhyllotaxis> trails = new List<TrailPhyllotaxis>();
    
    void Awake()
    {
        
    }

    public void UpdateColor()
    {
        if (colors.Count > 0)
        {
            colorTimer += Time.deltaTime;
            float percentageComplete = colorTimer / colorInterval;

            currentColor = Color.Lerp(previousColor, nextColor, percentageComplete);
            
            SetGradient(currentColor);

            if (percentageComplete >= 0.99f)
            {
                ChooseNewColour();
            }
        }
    }

    public void SetGradient(Color newColour)
    {
        for (int i = 0; i < trails.Count; i++)
        {
            trails[i]._trailRenderer.startColor = newColour;
        }
    }

    public void ChooseNewColour()
    {
        previousColor = nextColor;
        
        currentColorIndex = (currentColorIndex + 1) % colors.Count;

        nextColor = colors[currentColorIndex];

        colorTimer = 0f;
    }
    
    public void UpdateAngles(float newAngle)
    {
        if (angleMulti == 0)
            return;
        
        float angle = newAngle * angleMulti;

        for (int i = 0; i < trails.Count; i++)
        {
            if (!trails[i].enabled)
                continue;
                
            trails[i].degreeDelta += angle;
        }    
    }
    
    public void UpdateParentScale(float scaleChange)
    {
        if (scaleMulti == 0 || !trailParent)
            return;
        
        float deltaScale = scaleChange * scaleMulti;

        float newScale = Mathf.Clamp(trailParent.transform.localScale.x + deltaScale, minScale * (maxAmount - currentAmount + 1), maxScale * (maxAmount - currentAmount + 1));

        trailParent.transform.localScale = new Vector3(newScale, newScale, 1);
    }
    
    public void UpdateIndividualScales(float newScale)
    {
        if (scaleMulti == 0)
            return;
        
        float scale = newScale * scaleMulti;
        
        for (int i = 0; i < trails.Count; i++)
        {
            if (!trails[i].enabled)
                continue;
            
            trails[i].scale = Mathf.Clamp(trails[i].scale + scale, minScale, maxScale);
        }    
    }

    public void InvertTrails()
    {
        for (int i = 0; i < trails.Count; i++)
        {
            if (!trails[i].enabled)
                continue;
            
            trails[i].InvertPhyllotaxis();
            trails[i].StartLerping();
        }
    }
    
    public void ChangeAmountOfTrails(int amountChange)
    {
        int newAmount = Mathf.Clamp(currentAmount + amountChange, minAmount, maxAmount);

        if (newAmount == currentAmount)
            return;

        currentAmount = newAmount;
        
        
        for (int i = trails.Count - 1; i >= currentAmount; i--)
        {
            trails[i].enabled = false;
            trails[i]._trailRenderer.enabled = false;
        }
        
        int newAngle = Mathf.RoundToInt(360 / currentAmount);
        
        for (int i = 0; i < currentAmount; i++)
        {
            trails[i].degreeDelta = newAngle;
            trails[i].numberStart = i;
            trails[i].intervalLerp = 1.5f - (currentAmount / 5f);
            trails[i].enabled = true;
            trails[i]._trailRenderer.enabled = true;
            trails[i].ClearPhyllyotaxis(i >= ((currentAmount - amountChange)- 1));
        }
    }
}

public class PhylloController : MonoBehaviour
{
    public float angleSpeed;
    public float scaleSpeed;
    
    float deltaAngle = 0;
    float deltaScale = 0;
    int deltaAmount = 0;

    public bool invertNextFrame;
    
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
        for (int i = 0; i < groups.Count; i++)
        {
            for (int j = 0; j < groups[i].trails.Count; j++)
            {
                groups[i].trails[j].StartLogic();
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        LerpCameraPosition();
        
        UpdatePhylloGroups(deltaAngle * angleSpeed, deltaScale * scaleSpeed, deltaAmount);
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
                groups[i].UpdateParentScale(scale);
            }

            if (invertNextFrame && groups[i].allowTrailInvert)
            {
                groups[i].InvertTrails();
            }
            else if (groups[i].allowTrailAmountChange && newAmount != 0)
            {
                groups[i].ChangeAmountOfTrails(newAmount);
            }

            groups[i].UpdateColor();
        }
        
        deltaAmount = 0;
        
        invertNextFrame = false;
    }

    public void UpdateScale(float input)
    {
        deltaScale = input;
    }
    public void UpdateAngle(float input)
    {
        deltaAngle = input;    
    }

    public void UpdateCameraPosition(Vector2 newPos)
    {
        desiredCameraPos = newPos * cameraRange;
    }

    public void UpdateNumberOfTrails(int amountDelta)
    {
        deltaAmount = amountDelta;
    }
    
    public void LerpCameraPosition()
    {
        camera.transform.localPosition = Vector3.Lerp(camera.transform.localPosition, desiredCameraPos, cameraSpeed);
    }
    
    
}
