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
        //Vector3 vector = new Vector3(0.0f, 0.0f, 0.);
        RaycastHit[] hit;
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        //if (Physics.Raycast(cameraRay, out float rayLenght))
        //{
        //    pointToLook = cameraRay.GetPoint(rayLenght);
        //}
        if (Physics.Raycast(cameraRay, Mathf.Infinity))
        {
            Debug.DrawLine(cameraRay, Color.black);
            Debug.DrawRay(cameraRay, Color.black,);
            Debug.
            Debug.DrawRay()
            hit = Physics.RaycastAll(cameraRay, Mathf.Infinity);
            //pointToLook = cameraRay.GetPoint(hit[0].point);
            pointToLook = hit[0].point;
        }


    }
}
