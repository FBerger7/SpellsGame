using UnityEngine;

public class CameraController : MonoBehaviour
{
    public KeyCode moveLeft;
    public KeyCode moveRight;
    public float rotationSpeed;
    public float zoomSpeed;

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
        if (Input.mouseScrollDelta.y > 0)
        {
            camera.transform.Translate(0f, 0f, zoomSpeed * Time.deltaTime * 10f);
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            camera.transform.Translate(0f, 0f, -zoomSpeed * Time.deltaTime * 10f);
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
