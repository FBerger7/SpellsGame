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
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            pointToLook = hit.point;
        }
    }
}
