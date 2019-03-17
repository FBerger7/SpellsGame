using UnityEngine;

public class MouseTracker : MonoBehaviour
{
    protected Camera mainCamera;
    protected Vector3 pointToLook;

    protected void SetCamera()
    {
        mainCamera = FindObjectOfType<Camera>();
    }

    protected void TrackMouse()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        if (groundPlane.Raycast(cameraRay, out float rayLenght))
        {
            pointToLook = cameraRay.GetPoint(rayLenght);
        }
    }
}
