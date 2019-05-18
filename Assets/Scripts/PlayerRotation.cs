using UnityEngine;

public class PlayerRotation : MouseTracker
{
    void Start()
    {
        SetCamera();
    }
    // Update is called once per frame
    void Update()
    {
        TrackMouse();
        transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
    }
}
