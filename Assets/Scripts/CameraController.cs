using UnityEngine;

public class CameraController : MonoBehaviour
{
    public KeyCode moveLeft;
    public KeyCode moveRight;
    public float rotationSpeed;
    public float zoomSpeed;
    public float zoomMax;
    public float zoomMin;
    public float zoomRoughness;

    private new GameObject camera;
    private float zoom;

    void Start()
    {
        camera = this.transform.Find("Main Camera").gameObject;
        zoom = Camera.main.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        HandleRotation();
        HandleZoom();
    }

    // Handle zoom by changing the field of view of the main camera
    private void HandleZoom()
    {
        zoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        zoom = Mathf.Clamp(zoom, zoomMax, zoomMin);
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, zoom, Time.deltaTime * zoomRoughness);
    }

    private void HandleRotation()
    {
        if (Input.GetKey(moveLeft))
        {
            transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime * 10f, Space.World);
        }
        else if (Input.GetKey(moveRight))
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * 10f, Space.World);
        }
    }
}
