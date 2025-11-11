using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MinimapPos : MonoBehaviour
{
    [SerializeField] int widthPx = 256;   // mini-map width in pixels
    [SerializeField] int heightPx = 256;  // mini-map height in pixels
    [SerializeField] int marginPx = 16;   // margin from screen edges

    Camera cam;

    void Awake()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        // Convert pixels → normalized viewport (0..1)
        float w = (float)widthPx / Screen.width;
        float h = (float)heightPx / Screen.height;
        float x = 1f - w - (float)marginPx / Screen.width;   // top-right
        float y = 1f - h - (float)marginPx / Screen.height;

        cam.rect = new Rect(x, y, w, h);
    }
}
