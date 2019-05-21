using UnityEngine;

public class MouseTracker : MonoBehaviour
{
    protected Camera mainCamera;
    protected Vector3 pointToLook;

    public void SetCamera()
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
            if(objectHit.tag != "Particles")
            {
                Debug.DrawRay(mainCamera.transform.position, pointToLook, Color.cyan, 2f, true);
                pointToLook = hit.point;
            }
        }
    }
}
