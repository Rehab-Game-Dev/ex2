using UnityEngine;

public class CameraRotator2D : MonoBehaviour
{
    // Keys to rotate 90° clockwise / counter-clockwise
    [SerializeField] KeyCode rotateCW = KeyCode.E;
    [SerializeField] KeyCode rotateCCW = KeyCode.Q;

    int angleIndex = 0; // 0,1,2,3 → 0°,90°,180°,270°

    void Start()
    {
        // Ensure orthographic for 2D
        var cam = GetComponent<Camera>();
        if (cam) cam.orthographic = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(rotateCW))
            angleIndex = (angleIndex + 1) & 3; // mod 4
        else if (Input.GetKeyDown(rotateCCW))
            angleIndex = (angleIndex + 3) & 3; // -1 mod 4

        float targetZ = angleIndex * 90f;
        transform.rotation = Quaternion.Euler(0f, 0f, targetZ);
    }
}
