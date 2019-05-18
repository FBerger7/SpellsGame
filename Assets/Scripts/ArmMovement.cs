using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmMovement : MouseTracker
{
    // Start is called before the first frame update
    void Start()
    {
        SetCamera();
    }

    // Update is called once per frame
    void Update()
    {
        TrackMouse();
        transform.LookAt(new Vector3(pointToLook.x, pointToLook.y, pointToLook.z));
    }
}
