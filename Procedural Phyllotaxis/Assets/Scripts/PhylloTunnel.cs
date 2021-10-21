using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhylloTunnel : MonoBehaviour
{
    public Transform tunnel;

    public float tunnelSpeed, cameraDistance;
    

    // Update is called once per frame
    void FixedUpdate()
    {
        tunnel.position = new Vector3(tunnel.position.x, tunnel.position.y, tunnel.position.z + tunnelSpeed);

        transform.position = new Vector3(transform.position.x, transform.position.y,
            tunnel.position.z + cameraDistance);
    }
}
