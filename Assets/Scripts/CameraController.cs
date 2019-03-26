using UnityEngine;

public class CameraController : MonoBehaviour
{
    public KeyCode moveLeft;
    public KeyCode moveRight;
    public float rotationSpeed;
    public float zoomSpeed;
    public float maxZoom;
    public float minZoom;

    private new GameObject camera;

    void Start()
    {
        camera = this.transform.Find("Main Camera").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        HandleRotation();
        HandleZoom();
    }

    private void HandleZoom()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            float cameraZPosition = camera.transform.localPosition.z;
            float zoomTranslation = 0f;
            if (Input.mouseScrollDelta.y > 0 && cameraZPosition < maxZoom)
            {
                zoomTranslation = zoomSpeed;
            }
            if (Input.mouseScrollDelta.y < 0 && cameraZPosition > minZoom)
            {
                zoomTranslation = -zoomSpeed;
            }
            zoomTranslation *= Time.deltaTime * 10f;
            camera.transform.Translate(0f, 0f, zoomTranslation);
        }
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
