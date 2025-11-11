using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraZoom2D : MonoBehaviour
{
    [SerializeField] float zoomSpeed = 5f;   // units per second
    [SerializeField] float minSize = 2f;
    [SerializeField] float maxSize = 30f;

    Camera cam;

    void Awake()
    {
        cam = GetComponent<Camera>();
        cam.orthographic = true; // ensure 2D camera
    }

    void Update()
    {
        // Hold Up/Down to zoom in/out
        float input = 0f;
        if (Input.GetKey(KeyCode.I)) input = -1f; // zoom in
        if (Input.GetKey(KeyCode.O)) input = 1f;  // zoom out

        if (Mathf.Abs(input) > 0f)
        {
            cam.orthographicSize = Mathf.Clamp(
                cam.orthographicSize + input * zoomSpeed * Time.deltaTime,
                minSize, maxSize
            );
        }
    }
}
